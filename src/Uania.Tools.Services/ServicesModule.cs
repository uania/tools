using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uania.Tools.Infrastructure;
using Uania.Tools.Infrastructure.Module;
using Uania.Tools.Repository;
using Uania.Tools.Services.RepositoryServices.UserGroup;
using Uania.Tools.Services.RepositoryServices.UserGroup.Impl;
using Uania.Tools.Services.RepositoryServices.SportsTestingAccount;
using Uania.Tools.Services.RepositoryServices.SportsTestingAccount.Impl;

namespace Uania.Tools.Services
{
    public class ServicesModule : ModuleBase, IModule
    {
        /// <summary>
        /// 获取模块的名称
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return this.GetType().FullName ?? "Uania.Tools.Services.ServicesModule";
        }

        /// <summary>
        /// 注册已引用的模块中的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public override void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            using IModule module = new InfrstructureModule();
            module.RegisterService(services, configuration);
            using IModule repositoryModule = new RepositoryModule();
            repositoryModule.RegisterService(services, configuration);

            services.AddScoped<IUserGroupServices, UserGroupServicesImpl>();
            services.AddScoped<ISportsTestingAccountServices, STAccountServiceImpl>();
        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public override void Initialize()
        {

        }
    }
}