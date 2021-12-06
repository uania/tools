namespace Uania.Tools.Infrastructure.Rijndael
{
    public interface IRijndaelService
    {
        /// <summary>
        /// 加密字符串并返回字节数组
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] EncryptStringToBytes(string text);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string EncryptString(string text);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string DecryptString(string text);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string DecryptString(byte[] cipherText);
    }
}