using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Uania.Tools.Infrastructure.Rijndael.Impl
{
    public class RijndaelServiceImpl : IRijndaelService
    {
        /// <summary>
        /// 加密用key
        /// </summary>
        private readonly byte[] _key;

        private readonly Configs.RijndaelConfig _rijndaelConfig;

        public RijndaelServiceImpl(IOptions<Configs.RijndaelConfig>? options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("key");
            }
            _rijndaelConfig = options.Value;

            if (_rijndaelConfig.Key == null || _rijndaelConfig.Key.Length <= 0)
                throw new ArgumentNullException("key");
            _key = Convert.FromBase64String(_rijndaelConfig.Key);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string DecryptString(string cipherText)
        {
            var cipher = Convert.FromBase64String(cipherText);
            var plaintext = DecryptString(cipher);
            return plaintext;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string DecryptString(byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = string.Empty;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = _key;
                rijAlg.Mode = CipherMode.ECB;
                rijAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor();

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string EncryptString(string plaintext)
        {
            var buffer = EncryptStringToBytes(plaintext);
            var res = Convert.ToBase64String(buffer);
            return res;
        }

        /// <summary>
        /// 加密并返回字节数组
        /// </summary>
        /// <param name="plaintext">待加密数据</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] EncryptStringToBytes(string plaintext)
        {
            // Check arguments.
            if (plaintext == null || plaintext.Length <= 0)
                throw new ArgumentNullException("text");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = _key;
                rijAlg.Mode = CipherMode.ECB;
                rijAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor();

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new MemoryStream();
                using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plaintext);
                }
                encrypted = msEncrypt.ToArray();
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}