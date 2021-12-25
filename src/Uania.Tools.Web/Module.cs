using Uania.Tools.Infrastructure;
using Uania.Tools.Infrastructure.Configs;
using Uania.Tools.Services;

namespace Uania.Tools.Web
{
    public static class Module
    {
        /// <summary>
        /// 注册已引用的模块中的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            //注入加密配置
            services.Configure<RijndaelConfig>(configuration.GetSection(RijndaelConfig.SectionName));
            //注入数据库配置
            services.Configure<ConnectionConfig>(configuration.GetSection(ConnectionConfig.SectionName));
            //注入存储配置
            services.Configure<AmazonS3Config>(configuration.GetSection(AmazonS3Config.SectionName));
            //注入jwt配置
            services.Configure<JwtConfig>(configuration.GetSection(JwtConfig.SectionName));

            //调用依赖的服务注入模块
            using var module = new InfrstructureModule();
            module.RegisterService(services, configuration);
            using var servicesModule = new ServicesModule();
            servicesModule.RegisterService(services, configuration);
            return services;
        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public static void Initialize()
        {

        }
    }
}