using Uania.Tools.Repository.DataBase.Models;
using Uania.Tools.Repository.DataBase.DbContexts;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.Repositories
{
    public class SportsTestingUsersRepository : SportsTestingRepositoryBase<SportsTestingUser>, ISportsTestingUsersRepository
    {
        public SportsTestingUsersRepository(SportsTestingDbContext dbContext) : base(dbContext)
        {

        }
    }

    public interface ISportsTestingUsersRepository : ISportsTestingRepository<SportsTestingUser>
    {

    }
}