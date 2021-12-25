using System.Security.Claims;
using Microsoft.Extensions.Options;
using Uania.Tools.Infrastructure.Configs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Uania.Tools.Infrastructure.JwtServices.Impl
{
    public class JwtServicesImpl : IJwtServices
    {
        private readonly JwtConfig? _jwtConfig;

        public JwtServicesImpl(IOptions<JwtConfig> options)
        {
            if (options == null)
            {
                throw new ArgumentException("JwtConfig 配置未找到");
            }
            _jwtConfig = options.Value;
        }
        public string CreateToken(IEnumerable<Claim> claims)
        {
            if (string.IsNullOrWhiteSpace(_jwtConfig?.SecretKey))
            {
                throw new ArgumentNullException("JwtConfig->SecretKey 未配置");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
            var expires = Convert.ToDouble(_jwtConfig.Expires);
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(secretKey, algorithm);

            var token = new JwtSecurityToken(_jwtConfig.Issuer, _jwtConfig.Audience, claims, DateTime.Now, DateTime.Now.AddDays(expires), signingCredentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}