namespace Uania.Tools.Infrastructure.HttpServices
{
    public interface IHttpServices
    {
        /// <summary>
        /// 下载资源
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<byte[]> DownloadFile(string url);
    }
}