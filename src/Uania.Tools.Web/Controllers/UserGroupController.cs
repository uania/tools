using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Services.RepositoryServices.UserGroup;
using Uania.Tools.Models.UserGroup;
using Uania.Tools.Web.Models.Response;

namespace Uania.Tools.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserGroupController
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
        public async Task<ResponseBase<List<UserGroupUsers>>> GetUsers()
        {
            var users = await _userGroupServices.GetUserGroupUsers();
            var res = new ResponseBase<List<UserGroupUsers>>
            {
                Code = ResponseCodeEnum.Success,
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
        public async Task<ResponseBase<List<UserGroupApply>>> GetApplys()
        {
            var applys = await _userGroupServices.GetUserGroupApplys();
            var res = new ResponseBase<List<UserGroupApply>>
            {
                Code = ResponseCodeEnum.Success,
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
        public async Task<ResponseBase<string>> EntryptData()
        {
            var message = await _userGroupServices.EntryptData();
            var res = new ResponseBase<string>
            {
                Code = ResponseCodeEnum.Success,
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
        public async Task<ResponseBase<string>> DetryptData()
        {
            var message = await _userGroupServices.DetryptData();
            var res = new ResponseBase<string>
            {
                Code = ResponseCodeEnum.Success,
                Message = "请求成功",
                Data = message
            };
            return res;
        }
    }
}