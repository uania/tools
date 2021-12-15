namespace Uania.Tools.Infrastructure.HttpServices.Impl
{
    public class HttpServicesImpl : IHttpServices
    {
        private readonly HttpClient _client;

        public HttpServicesImpl()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">资源文件地址</param>
        /// <returns></returns>
        public async Task<byte[]> DownloadFile(string url)
        {
            var response = await _client.GetAsync(url);
            var res = await response.Content.ReadAsByteArrayAsync();
            return res;
        }
    }
}