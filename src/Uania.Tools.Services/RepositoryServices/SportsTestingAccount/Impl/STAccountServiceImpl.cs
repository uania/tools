using System.Linq.Expressions;
using AutoMapper;
using Uania.Tools.Models.SportsTesting;
using Uania.Tools.Repository.Repositories;

namespace Uania.Tools.Services.RepositoryServices.SportsTestingAccount.Impl
{
    public class STAccountServiceImpl : ISportsTestingAccountServices
    {
        private readonly ISportsTestingUsersRepository _stAccountRepo;
        private readonly IMapper _mapper;
        public STAccountServiceImpl(ISportsTestingUsersRepository stAccountRepo
        , IMapper mapper)
        {
            _stAccountRepo = stAccountRepo;
            _mapper = mapper;
        }

        public async Task<SportsTestingUsers?> GetUserInfo(string phone)
        {
            var entity = await _stAccountRepo.GetInfo(r => r.UserPhone == phone && !r.IsDelete);
            SportsTestingUsers res = null;
            if (entity != null)
            {
                res = _mapper.Map<SportsTestingUsers>(entity);
            }

            return res;
        }
    }
}