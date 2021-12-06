using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uania.Tools.Infrastructure.Rijndael;
using Uania.Tools.Infrastructure.Rijndael.Impl;
using Uania.Tools.Infrastructure.Module;
using Uania.Tools.Infrastructure.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Infrastructure
{
    public class InfrstructureModule : ModuleBase, IModule
    {
        /// <summary>
        /// 获取模块的名称
        /// </summary>
        /// <returns></returns>
        public override string GetName()
        {
            return this.GetType().FullName ?? "Uania.Tools.Infrastructure.InfrstructureModule";
        }

        /// <summary>
        /// 注册已引用的模块中的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public override void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRijndaelService, RijndaelServiceImpl>(sp => new RijndaelServiceImpl(configuration["RijndaelConfig:Key"]));
            services.AddDbContext<BaseDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings:SqlServerConnection"]);
            });
        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public override void Initialize()
        {

        }
    }
}