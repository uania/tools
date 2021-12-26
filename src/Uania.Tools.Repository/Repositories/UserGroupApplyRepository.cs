using Uania.Tools.Repository.Entities;
using Uania.Tools.Repository.DataBase.Models;
using Uania.Tools.Repository.DataBase.DbContexts;

namespace Uania.Tools.Repository.Repositories
{
    public class UserGroupApplyRepository : RepositoryBase<UserGroupApply>, IUserGroupApplyRepository
    {
        public UserGroupApplyRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserGroupApplyRepository : IRepository<UserGroupApply>
    {

    }
}