using Uania.Tools.Infrastructure.MD5Services;
using AutoMapper;
using Uania.Tools.Models.SportsTesting;
using Uania.Tools.Repository.Repositories;

namespace Uania.Tools.Services.RepositoryServices.SportsTestingAccount.Impl
{
    public class STAccountServiceImpl : ISportsTestingAccountServices
    {
        private readonly ISportsTestingUsersRepository _stAccountRepo;
        private readonly IMapper _mapper;
        private readonly IMD5Service _md5Service;
        public STAccountServiceImpl(ISportsTestingUsersRepository stAccountRepo
        , IMapper mapper
        , IMD5Service mD5Service)
        {
            _stAccountRepo = stAccountRepo;
            _mapper = mapper;
            _md5Service = mD5Service;
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

        public bool ValidPassword(string plainPassword, string cipherPassword)
        {
            var isValid = _md5Service.CompairWithSaltText(plainPassword, cipherPassword);

            return isValid;
        }
    }
}