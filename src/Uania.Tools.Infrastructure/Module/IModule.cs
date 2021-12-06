using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Uania.Tools.Infrastructure.Module
{
    public interface IModule : IDisposable
    {
        /// <summary>
        /// 获取模块的名称
        /// </summary>
        string GetName();

        /// <summary>
        /// 依赖注入事件
        /// </summary>
        /// <param name="builder"></param>
        void RegisterService(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// 模块初始化
        /// </summary>
        void Initialize();
    }
}