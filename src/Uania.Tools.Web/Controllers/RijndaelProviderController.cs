using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uania.Tools.Infrastructure.Rijndael;

namespace Uania.Tools.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class RijndaelProviderController : UaniaBaseController
    {
        private readonly IRijndaelService _rijndaelService;
        public RijndaelProviderController(IRijndaelService rijndaelService)
        {
            _rijndaelService = rijndaelService;
        }

        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>base64密文</returns>
        [HttpGet]
        public string EncryptString(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentException("入参不能为空，且长度必须大于0");
            }
            return _rijndaelService.EncryptString(plainText);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="cipherText">base64密文</param>
        /// <returns>明文</returns>
        [HttpGet]
        public string DecryptString(string cipherText)
        {
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentException("入参不能为空，且长度必须大于0");
            }
            return _rijndaelService.DecryptString(cipherText);
        }
    }
}