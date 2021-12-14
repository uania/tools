namespace Uania.Tools.Infrastructure.FileUpdate.Impl
{
    public abstract class FileUpdateServicesBase : IFileUpdateServices
    {
        public abstract Task<bool> CreateFolder(string bucketName, string folderKey);

        public abstract Task<bool> DoesFolderExist(string bucketName, string key);

        public abstract Task<string> PutAsync(byte[] fileData, string? folderPath, string fileName);
    }
}