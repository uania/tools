using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uania.Tools.Infrastructure.Module;
using Uania.Tools.Repository.Repositories;
using Uania.Tools.Repository.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Repository
{
    public class RepositoryModule : ModuleBase, IModule
    {
        /// <summary>
        /// 获取模块的名称
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return this.GetType().FullName ?? "Uania.Tools.Repository.RepositoryModule";
        }

        /// <summary>
        /// 注册已引用的模块中的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public override void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings:SqlServerConnection"]);
            });
            
            services.AddScoped<IUserGroupUsersRepository, UserGroupUsersRepository>();
            services.AddScoped<IUserGroupApplyRepository, UserGroupApplyRepository>();
            services.AddScoped<IUserGroupActivityRepository, UserGroupActivityRepository>();
        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public override void Initialize()
        {

        }
    }
}