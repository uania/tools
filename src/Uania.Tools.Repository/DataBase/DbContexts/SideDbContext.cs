using Microsoft.EntityFrameworkCore;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SideDbContext : DbContext
    {
        public SideDbContext(DbContextOptions<SideDbContext> options) : base(options)
        {

        }

        public DbSet<SideUser>? SideUser { get; set; }
    }
}