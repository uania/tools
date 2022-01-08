using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uania.Tools.Infrastructure.Rijndael;
using Uania.Tools.Infrastructure.Rijndael.Impl;
using Uania.Tools.Infrastructure.Module;
using Uania.Tools.Infrastructure.RegValidator;
using Uania.Tools.Infrastructure.RegValidator.Impl;
using Uania.Tools.Infrastructure.FileUpdate;
using Uania.Tools.Infrastructure.FileUpdate.Impl;
using Microsoft.Extensions.Options;
using Uania.Tools.Infrastructure.HttpServices;
using Uania.Tools.Infrastructure.HttpServices.Impl;
using Uania.Tools.Infrastructure.JwtServices;
using Uania.Tools.Infrastructure.JwtServices.Impl;
using Uania.Tools.Infrastructure.MD5Services;
using Uania.Tools.Infrastructure.MD5Services.Impl;

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
            services.AddSingleton<IRijndaelService, RijndaelServiceImpl>(sp => new RijndaelServiceImpl(sp.GetService<IOptions<Configs.RijndaelConfig>>()));
            services.AddSingleton<IRegValidatorServices, RegValidatorServicesImpl>();
            services.AddSingleton<IFileUpdateServices, FileUpdateAwsServicesImpl>(sp => new FileUpdateAwsServicesImpl(sp.GetService<IOptions<Configs.AmazonS3Config>>()));
            services.AddSingleton<IHttpServices, HttpServicesImpl>();
            services.AddSingleton<IJwtServices, JwtServicesImpl>();
            services.AddSingleton<IMD5Service, MD5ServiceImpl>();
        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public override void Initialize()
        {

        }
    }
}