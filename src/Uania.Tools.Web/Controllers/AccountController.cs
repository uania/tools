using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Infrastructure.JwtServices;

namespace Uania.Tools.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : UaniaBaseController
    {
        private readonly IJwtServices _jwtServices;
        public AccountController(IJwtServices jwtServices)
        {
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
            return _jwtServices.CreateToken(claims);
        }
    }
}