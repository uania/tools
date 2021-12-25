using System.Security.Claims;
using System.Collections.Generic;

namespace Uania.Tools.Infrastructure.JwtServices
{
    public interface IJwtServices
    {
        public string CreateToken(IEnumerable<Claim> claims);
    }
}