namespace Uania.Tools.Infrastructure.FileUpdate
{
    public interface IFileUpdateServices
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> PutAsync(byte[] fileData, string? folderPath, string fileName);

        /// <summary>
        /// 检查指定key是否存在
        /// </summary>
        /// <param name="bucketName">存储桶的名称</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> DoesFolderExist(string bucketName, string key);

        /// <summary>
        /// 检查指定文件夹key是否存在
        /// </summary>
        /// <param name="bucketName">存储桶的名称</param>
        /// <param name="folderKey">需以“/”结尾</param>
        /// <returns></returns>
        public Task<bool> CreateFolder(string bucketName, string folderKey);
    }
}