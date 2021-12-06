using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Uania.Tools.Infrastructure.Module
{
    public abstract class ModuleBase : IModule
    {
        /// <summary>
        /// 获取模块的名称
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// 注册模块中的服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public virtual void RegisterService(IServiceCollection services, IConfiguration configuration)
        {

        }

        /// <summary>
        /// 模块初始化
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {

        }
    }
}