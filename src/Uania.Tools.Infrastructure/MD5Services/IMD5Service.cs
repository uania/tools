namespace Uania.Tools.Infrastructure.MD5Services
{
    public interface IMD5Service
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public byte[] EncryptString(string plainText);

        /// <summary>
        /// 使用随机salt加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string EncryptStringWithSalt(string plainText);

        /// <summary>
        /// 对比随机salt加密的密文
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public bool CompairWithSaltText(string plainText, string cipherText);
    }
}