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

        [HttpGet]
        public async Task<ResponseBase<List<UserGroupUsers>>> GetUsers()
        {
            var users = await _userGroupServices.GetUserGroups();
            var res = new ResponseBase<List<UserGroupUsers>>
            {
                Code = ResponseCodeEnum.Success,
                Message = "请求成功",
                Data = users
            };
            return res;
        }
    }
}