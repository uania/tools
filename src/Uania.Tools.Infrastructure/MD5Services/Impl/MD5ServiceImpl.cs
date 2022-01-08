using System.Security.Cryptography;
using System.Text;

namespace Uania.Tools.Infrastructure.MD5Services.Impl
{
    public class MD5ServiceImpl : IMD5Service
    {
        private readonly MD5 _md5;
        private readonly Random _random;
        public MD5ServiceImpl()
        {
            _md5 = MD5.Create();
            _random = new Random();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        public byte[] EncryptString(string plainText)
        {
            var bytes = Encoding.UTF8.GetBytes(plainText);
            var cipherBytes = _md5.ComputeHash(bytes);
            return cipherBytes;
        }

        /// <summary>
        /// 使用随机salt加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string EncryptStringWithSalt(string plainText)
        {
            var salts = new byte[1];
            _random.NextBytes(salts);
            var salt = salts[0];
            plainText += salt;
            var cipherBytes = EncryptString(plainText);
            cipherBytes[0] = salt;
            var cipherText = Convert.ToBase64String(cipherBytes);
            return cipherText;
        }

        /// <summary>
        /// 对比加盐之后的密码是否相同
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public bool CompairWithSaltText(string plainText, string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var salt = cipherBytes[0];
            plainText += salt;
            var compairBytes = EncryptString(plainText);
            if (cipherBytes.Length != compairBytes.Length)
            {
                return false;
            }

            for (var i = 1; i < compairBytes.Length; i++)
            {
                if (compairBytes[i] != cipherBytes[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}