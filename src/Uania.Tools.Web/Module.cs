using Uania.Tools.Infrastructure;
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