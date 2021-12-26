using System.Linq.Expressions;
using Uania.Tools.Models.SportsTesting;
using Uania.Tools.Repository.Repositories;

namespace Uania.Tools.Services.RepositoryServices.SportsTestingAccount.Impl
{
    public class STAccountServiceImpl : ISportsTestingAccountServices
    {
        private readonly ISportsTestingUsersRepository _stAccountRepo;
        public STAccountServiceImpl(ISportsTestingUsersRepository stAccountRepo)
        {
            _stAccountRepo = stAccountRepo;
        }

        public async Task<SportsTestingUsers?> GetUserInfo(string phone)
        {
            var entity = await _stAccountRepo.GetInfo(r => r.UserPhone == phone && !r.IsDelete);
            SportsTestingUsers res = null;
            if (entity != null)
            {
                res = new SportsTestingUsers
                {
                    Id = entity.Id,
                    UserName = entity.UserName,
                    UserEmail = entity.UserEmail,
                    UserPhone = entity.UserPhone,
                    UserRole = entity.UserRole,
                    UserState = entity.UserState,
                    CreateTime = entity.CreateTime,
                    LastUpdateTime = entity.LastUpdateTime
                };
            }

            return res;
        }
    }
}