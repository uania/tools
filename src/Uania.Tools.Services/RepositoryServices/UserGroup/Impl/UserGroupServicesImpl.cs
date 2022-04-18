using Uania.Tools.Models.UserGroup;
using Uania.Tools.Repository.Repositories;
using Uania.Tools.Infrastructure.RegValidator;
using Uania.Tools.Infrastructure.Rijndael;
using Uania.Tools.Infrastructure.FileUpdate;
using Uania.Tools.Infrastructure.HttpServices;

namespace Uania.Tools.Services.RepositoryServices.UserGroup.Impl
{
    public class UserGroupServicesImpl : IUserGroupServices
    {
        private readonly IUserGroupUsersRepository _userGroupUsersRepository;
        private readonly IUserGroupApplyRepository _userGroupApplyRepository;

        private readonly IRegValidatorServices _regValidatorServices;

        private readonly IRijndaelService _rijndaelService;

        private readonly IUserGroupActivityRepository _userGroupActivityRepository;

        private readonly IFileUpdateServices _fileUpdateServices;

        private readonly IHttpServices _httpServices;

        public UserGroupServicesImpl(IUserGroupUsersRepository userGroupUsersRepository
                                    , IUserGroupApplyRepository userGroupApplyRepository
                                    , IRegValidatorServices regValidatorServices
                                    , IRijndaelService rijndaelService
                                    , IUserGroupActivityRepository userGroupActivityRepository
                                    , IFileUpdateServices fileUpdateServices
                                    , IHttpServices httpServices)
        {
            _userGroupUsersRepository = userGroupUsersRepository;
            _userGroupApplyRepository = userGroupApplyRepository;
            _regValidatorServices = regValidatorServices;
            _rijndaelService = rijndaelService;
            _userGroupActivityRepository = userGroupActivityRepository;
            _fileUpdateServices = fileUpdateServices;
            _httpServices = httpServices;
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

        /// <summary>
        /// 获取加密数据解密后存储
        /// </summary>
        /// <returns></returns>
        public async Task<string> DetryptData()
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
                    if (!_regValidatorServices.IsPhoneNumber(user.MobilePhone) && !_regValidatorServices.IsEmail(user.Email))
                    {
                        if (!string.IsNullOrWhiteSpace(user.UserName))
                            user.UserName = _rijndaelService.DecryptString(user.UserName);
                        if (!string.IsNullOrWhiteSpace(user.Email))
                            user.Email = _rijndaelService.DecryptString(user.Email);
                        if (!string.IsNullOrWhiteSpace(user.MobilePhone))
                            user.MobilePhone = _rijndaelService.DecryptString(user.MobilePhone);
                        if (!string.IsNullOrWhiteSpace(user.CompanyName))
                            user.CompanyName = _rijndaelService.DecryptString(user.CompanyName);

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
                    if (!_regValidatorServices.IsPhoneNumber(apply.Phone) && !_regValidatorServices.IsEmail(apply.Email))
                    {
                        if (!string.IsNullOrWhiteSpace(apply.Name))
                            apply.Name = _rijndaelService.DecryptString(apply.Name);
                        if (!string.IsNullOrWhiteSpace(apply.Email))
                            apply.Email = _rijndaelService.DecryptString(apply.Email);
                        if (!string.IsNullOrWhiteSpace(apply.Phone))
                            apply.Phone = _rijndaelService.DecryptString(apply.Phone);
                        if (!string.IsNullOrWhiteSpace(apply.Company))
                            apply.Company = _rijndaelService.DecryptString(apply.Company);

                        applys.Add(apply);
                    }
                }
                applyAffected = await _userGroupApplyRepository.Update(applys);
            }

            return $"users表解密{userAffected}行；apply表解密{applyAffected}行；";
        }

        /// <summary>
        /// 使用aws存储替换本地文件
        /// </summary>
        /// <returns></returns>
        public async Task<string> ReplaceFileUrlWithAws()
        {
            //获取活动数据
            var id = Guid.Parse("3CB4DE30-FAE7-4782-8CDE-281A842D1D1B");
            var activities = await _userGroupActivityRepository.GetListAsync(r => r.Id == id);

            Func<string, Task<string>> action = async (originalUrl) =>
             {
                 var awsUrl = string.Empty;
                 if (!string.IsNullOrWhiteSpace(originalUrl))
                 {
                     try
                     {
                         var originalFile = await _httpServices.DownloadFile(originalUrl);
                         var fileName = Path.GetFileName(originalUrl);
                         awsUrl = await _fileUpdateServices.PutAsync(originalFile, "tool-test/", fileName);
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.Message);
                     }
                 }
                 return awsUrl;
             };

            //循环替换数据url
            foreach (var activity in activities)
            {
                var awsUrl = await action.Invoke(activity.BannerList);
                if (!string.IsNullOrEmpty(awsUrl))
                    activity.BannerList = awsUrl;
            }
            return activities?.FirstOrDefault()?.BannerList ?? string.Empty;
        }

        /// <summary>
        /// 加密指定id的leader申请表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<string> EntrytApplyData(List<Guid> ids)
        {
            int applyAffected = 0;
            //处理leader申请表
            var originApplyData = await _userGroupApplyRepository.GetListAsync(r => ids.Contains(r.Id));
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
                if (applys.Any())
                {
                    applyAffected = await _userGroupApplyRepository.Update(applys);
                }
            }

            return $"apply表加密{applyAffected}行；";
        }
    }
}