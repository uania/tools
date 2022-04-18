using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Services.RepositoryServices.UserGroup;
using Uania.Tools.Models.UserGroup;
using Uania.Tools.Models.Wrapper;
using Microsoft.AspNetCore.Authorization;

namespace Uania.Tools.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserGroupController : UaniaBaseController
    {
        private IUserGroupServices _userGroupServices;
        public UserGroupController(IUserGroupServices userGroupServices)
        {
            _userGroupServices = userGroupServices;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespListWrapper<UserGroupUsers>> GetUsers()
        {
            var users = await _userGroupServices.GetUserGroupUsers();
            var res = new RespListWrapper<UserGroupUsers>
            {
                Code = 1,
                Message = "请求成功",
                Data = users
            };
            return res;
        }

        /// <summary>
        /// 获取leader申请列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespListWrapper<UserGroupApply>> GetApplys()
        {
            var applys = await _userGroupServices.GetUserGroupApplys();
            var res = new RespListWrapper<UserGroupApply>
            {
                Code = 1,
                Message = "请求成功",
                Data = applys
            };
            return res;
        }

        /// <summary>
        /// 加密users、apply表的手机号、邮箱、姓名、公司字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespWrapper<string>> EntryptData()
        {
            var message = await _userGroupServices.EntryptData();
            var res = new RespWrapper<string>
            {
                Code = 1,
                Message = "请求成功",
                Data = message
            };
            return res;
        }

        /// <summary>
        /// 解密users、apply表的手机号、邮箱、姓名、公司字段
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespWrapper<string>> DetryptData()
        {
            var message = await _userGroupServices.DetryptData();
            var res = new RespWrapper<string>
            {
                Code = 1,
                Message = "请求成功",
                Data = message
            };
            return res;
        }

        /// <summary>
        /// 使用aws存储替换本地存储
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<RespWrapper<string>> ReplaceFileUrlWithAws()
        {
            var awsUrl = await _userGroupServices.ReplaceFileUrlWithAws();
            return new RespWrapper<string>
            {
                Code = 1,
                Message = "请求成功",
                Data = awsUrl
            };
        }

        /// <summary>
        /// 加密指定id的leader申请数据
        /// </summary>
        /// /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<RespWrapper<string>> DetryptApplyData(List<Guid> ids)
        {
            var message = await _userGroupServices.EntrytApplyData(ids);
            var res = new RespWrapper<string>
            {
                Code = 1,
                Message = "请求成功",
                Data = message
            };
            return res;
        }
    }
}