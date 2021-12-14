namespace Uania.Tools.Infrastructure.FileUpdate.Impl
{
    public class FileUpdateServicesImpl : FileUpdateServicesBase, IFileUpdateServices
    {
        public override Task<bool> CreateFolder(string bucketName, string folderKey)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DoesFolderExist(string bucketName, string key)
        {
            throw new NotImplementedException();
        }

        public override Task<string> PutAsync(byte[] fileData, string? folderPath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}