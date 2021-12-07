using Uania.Tools.Models.UserGroup;

namespace Uania.Tools.Services.RepositoryServices.UserGroup
{
    public interface IUserGroupServices
    {
        public Task<List<UserGroupUsers>> GetUserGroups();
    }
}