using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Infrastructure.JwtServices;
using Uania.Tools.Services.RepositoryServices.SportsTestingAccount;
using Uania.Tools.Models.Wrapper;
using Uania.Tools.Models.Dtos.Reqs;
using Uania.Tools.Models.Dtos.Resps;

namespace Uania.Tools.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : UaniaBaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IJwtServices _jwtServices;

        private readonly ISportsTestingAccountServices _stAccountServices;
        public AccountController(ILogger<AccountController> logger
        , IJwtServices jwtServices
        , ISportsTestingAccountServices stAccountServices)
        {
            _logger = logger;
            _jwtServices = jwtServices;
            _stAccountServices = stAccountServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<RespWrapper<LoginResp>> SignIn(ReqWapper<LoginRes> res)
        {
            if (res == null || res.Params == null || res.Params.Phone == null)
            {
                return new RespWrapper<LoginResp>(code: -100, message: "入参为不能为null");
            }

            try
            {
                var userInfo = await _stAccountServices.GetUserInfo(res.Params.Phone);
                if (userInfo == null)
                {
                    return new RespWrapper<LoginResp>(code: -100, message: "未找到用户");
                }

                var claims = new Claim[]{
                        new Claim("Id", userInfo?.UserPhone??string.Empty),
                        new Claim("Name", userInfo?.UserName??string.Empty)
                    };

                var token = _jwtServices.CreateToken(claims);
                _logger.LogInformation($"用户{userInfo?.UserPhone}在{DateTime.Now:yyyy-MM-dd HH:mm:ss}时登录");

                return new RespWrapper<LoginResp>(code: 1, message: "登录成功")
                {
                    Data = new LoginResp
                    {
                        Token = token
                    }
                };

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "用户登录时发生异常");
                return new RespWrapper<LoginResp>(code: -100, message: "服务器异常，请稍后重试！");
            }
        }
    }
}