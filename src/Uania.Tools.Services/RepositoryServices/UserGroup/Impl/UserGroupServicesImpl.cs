using Uania.Tools.Models.UserGroup;
using Uania.Tools.Repository.Repositories;
using Uania.Tools.Infrastructure.RegValidator;
using Uania.Tools.Infrastructure.Rijndael;

namespace Uania.Tools.Services.RepositoryServices.UserGroup.Impl
{
    public class UserGroupServicesImpl : IUserGroupServices
    {
        private readonly IUserGroupUsersRepository _userGroupUsersRepository;
        private readonly IUserGroupApplyRepository _userGroupApplyRepository;

        private readonly IRegValidatorServices _regValidatorServices;

        private readonly IRijndaelService _rijndaelService;

        public UserGroupServicesImpl(IUserGroupUsersRepository userGroupUsersRepository
                                    , IUserGroupApplyRepository userGroupApplyRepository
                                    , IRegValidatorServices regValidatorServices
                                    , IRijndaelService rijndaelService)
        {
            _userGroupUsersRepository = userGroupUsersRepository;
            _userGroupApplyRepository = userGroupApplyRepository;
            _regValidatorServices = regValidatorServices;
            _rijndaelService = rijndaelService;
        }

        /// <summary>
        /// 获取users列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserGroupUsers>?> GetUserGroupUsers()
        {
            var userEntities = await _userGroupUsersRepository.GetListAsync();
            var userGroups = userEntities?.Select(r => new UserGroupUsers
            {
                Id = r.Id,
                UserName = r.UserName,
                MobilePhone = r.MobilePhone,
                Email = r.Email,
                CompanyName = r.CompanyName
            })
            ?.ToList();
            return userGroups;
        }

        /// <summary>
        /// leader申请列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserGroupApply>?> GetUserGroupApplys()
        {
            var applyEntities = await _userGroupApplyRepository.GetListAsync();
            var applys = applyEntities?.Select(r => new UserGroupApply
            {
                Id = r.Id,
                Phone = r.Phone,
                Email = r.Email,
                Name = r.Name,
                Company = r.Company
            })
            ?.ToList();
            return applys;
        }

        /// <summary>
        /// 获取未加密的数据进项加密后保存
        /// </summary>
        /// <returns></returns>
        public async Task<string> EntryptData()
        {
            int userAffected = 0;
            int applyAffected = 0;
            //处理用户表
            var originUsersData = await _userGroupUsersRepository.GetListAsync();
            if (originUsersData != null && originUsersData.Any())
            {
                var users = new List<Repository.Entities.UserGroupUsers>();
                foreach (var user in originUsersData)
                {
                    if (_regValidatorServices.IsPhoneNumber(user.MobilePhone) && _regValidatorServices.IsEmail(user.Email))
                    {
                        if (!string.IsNullOrWhiteSpace(user.UserName))
                            user.UserName = _rijndaelService.EncryptString(user.UserName);
                        if (!string.IsNullOrWhiteSpace(user.Email))
                            user.Email = _rijndaelService.EncryptString(user.Email);
                        if (!string.IsNullOrWhiteSpace(user.MobilePhone))
                            user.MobilePhone = _rijndaelService.EncryptString(user.MobilePhone);
                        if (!string.IsNullOrWhiteSpace(user.CompanyName))
                            user.CompanyName = _rijndaelService.EncryptString(user.CompanyName);

                        users.Add(user);
                    }
                }
                userAffected = await _userGroupUsersRepository.Update(users);
            }

            //处理leader申请表
            var originApplyData = await _userGroupApplyRepository.GetListAsync();
            if (originApplyData != null && originApplyData.Any())
            {
                var applys = new List<Repository.Entities.UserGroupApply>();
                foreach (var apply in originApplyData)
                {
                    if (_regValidatorServices.IsPhoneNumber(apply.Phone) && _regValidatorServices.IsEmail(apply.Email))
                    {
                        if (!string.IsNullOrWhiteSpace(apply.Name))
                            apply.Name = _rijndaelService.EncryptString(apply.Name);
                        if (!string.IsNullOrWhiteSpace(apply.Email))
                            apply.Email = _rijndaelService.EncryptString(apply.Email);
                        if (!string.IsNullOrWhiteSpace(apply.Phone))
                            apply.Phone = _rijndaelService.EncryptString(apply.Phone);
                        if (!string.IsNullOrWhiteSpace(apply.Company))
                            apply.Company = _rijndaelService.EncryptString(apply.Company);

                        applys.Add(apply);
                    }
                }
                applyAffected = await _userGroupApplyRepository.Update(applys);
            }

            return $"users表加密{userAffected}行；apply表加密{applyAffected}行；";
        }
    }
}