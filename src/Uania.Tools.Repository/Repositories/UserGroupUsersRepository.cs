using Uania.Tools.Repository.DataBase.DbContexts;
using Uania.Tools.Repository.DataBase.Models;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.Repositories
{
    public class UserGroupUsersRepository : RepositoryBase<UserGroupUsers>, IUserGroupUsersRepository
    {
        public UserGroupUsersRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserGroupUsersRepository : IRepository<UserGroupUsers>
    {

    }
}