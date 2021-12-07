using Uania.Tools.Repository.Entities;
using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.Repositories
{
    public class UserGroupApplyRepository : Repository<UserGroupApply>, IUserGroupApplyRepository
    {
        public UserGroupApplyRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserGroupApplyRepository : IRepository<UserGroupApply>
    {

    }
}