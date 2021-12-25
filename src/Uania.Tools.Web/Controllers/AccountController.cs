using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Infrastructure.JwtServices;

namespace Uania.Tools.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : UaniaBaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IJwtServices _jwtServices;
        public AccountController(ILogger<AccountController> logger, IJwtServices jwtServices)
        {
            _logger = logger;
            _jwtServices = jwtServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public string SignIn(string email)
        {
            var claims = new Claim[]
            {
                new Claim("Id",email),
                new Claim("Name",email)
            };
            var token = _jwtServices.CreateToken(claims);
            _logger.LogInformation($"用户{email}在{DateTime.Now:yyyy-MM-dd HH:mm:ss}时登录");
            return token;
        }
    }
}