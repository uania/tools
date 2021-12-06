using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Infrastructure.DataBase.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 添加entitys
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currPath = AppDomain.CurrentDomain.BaseDirectory;
            var allFiles = Directory.GetFiles(currPath, "*.dll");
            var assemblies = allFiles?.Where(r => !r.StartsWith("Microsoft") || !r.StartsWith("System"))
                                     ?.Select(r => Assembly.Load(r));
            if (assemblies != null && assemblies.Any())
            {
                foreach (var assembly in assemblies)
                {
                    var entityTypes = assembly.GetTypes()
                        .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                        .Where(type => type.IsClass)
                        .Where(type => type.BaseType != null)
                        .Where(type => !type.IsAbstract)
                        .Where(type => typeof(IEntity<>).IsAssignableFrom(type));

                    foreach (var entityType in entityTypes)
                    {
                        if (modelBuilder.Model.FindEntityType(entityType) != null) continue;
                        modelBuilder.Model.AddEntityType(entityType);
                    }
                }
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}