using Microsoft.EntityFrameworkCore;
using Uania.Tools.Repository.DataBase.Models;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.Repositories
{
    public class UserGroupRepository : Repository<UserGroupUsers>, IUserGroupRepository
    {
        public UserGroupRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserGroupRepository : IRepository<UserGroupUsers>
    {

    }
}