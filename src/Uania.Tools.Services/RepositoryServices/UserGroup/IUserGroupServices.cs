using Uania.Tools.Models.UserGroup;

namespace Uania.Tools.Services.RepositoryServices.UserGroup
{
    public interface IUserGroupServices
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public Task<List<UserGroupUsers>?> GetUserGroupUsers();

        /// <summary>
        /// 获取leader申请列表
        /// </summary>
        /// <returns></returns>
        public Task<List<UserGroupApply>?> GetUserGroupApplys();

        /// <summary>
        /// 获取未加密的数据进行加密后存储
        /// </summary>
        /// <returns></returns>
        public Task<string> EntryptData();

        /// <summary>
        /// 获取加密数据解密后存储
        /// </summary>
        /// <returns></returns>
        public Task<string> DetryptData();
    }
}