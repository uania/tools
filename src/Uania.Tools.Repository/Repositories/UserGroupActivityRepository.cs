using Uania.Tools.Repository.DataBase.Models;
using Uania.Tools.Repository.DataBase.DbContexts;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.Repositories
{
    public class UserGroupActivityRepository : RepositoryBase<UserGroupActivity>, IUserGroupActivityRepository
    {
        public UserGroupActivityRepository(BaseDbContext dbContext) : base(dbContext)
        {

        }

    }

    public interface IUserGroupActivityRepository : IRepository<UserGroupActivity>
    {

    }
}