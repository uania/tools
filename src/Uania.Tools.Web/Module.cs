using Uania.Tools.Infrastructure.Rijndael;
using Uania.Tools.Infrastructure.Rijndael.Impl;

namespace Uania.Tools.Web
{
    public static class Module
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRijndaelService, RijndaelServiceImpl>(s => new RijndaelServiceImpl(configuration["RijndaelConfig:Key"]));

            return services;
        }
    }
}