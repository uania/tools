using Uania.Tools.Models.UserGroup;
using Uania.Tools.Repository.Repositories;

namespace Uania.Tools.Services.RepositoryServices.UserGroup.Impl
{
    public class UserGroupServicesImpl : IUserGroupServices
    {
        private IUserGroupRepository _userGroupRepository;

        public UserGroupServicesImpl(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        /// <summary>
        /// 获取users列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserGroupUsers>> GetUserGroups()
        {
            var userEntities = await _userGroupRepository.GetListAsync();
            var userGroups = userEntities?.Select(r => new UserGroupUsers
            {
                Id = r.Id,
                UserName = r.UserName
            })
            ?.ToList() ?? new List<UserGroupUsers>();
            return userGroups;
        }
    }
}