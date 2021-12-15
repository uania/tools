using System.Net;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;


namespace Uania.Tools.Infrastructure.FileUpdate.Impl
{
    public class FileUpdateAwsServicesImpl : FileUpdateServicesBase, IFileUpdateServices
    {
        private readonly AmazonS3Client _s3Client;

        private readonly Configs.AmazonS3Config _awsConfigs;

        public FileUpdateAwsServicesImpl(IOptions<Configs.AmazonS3Config>? options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("缺少AWS存储所需配置，请检查配置");
            }
            _awsConfigs = options.Value;
            if (_awsConfigs == null || string.IsNullOrWhiteSpace(_awsConfigs.AwsAccessKeyId) || string.IsNullOrWhiteSpace(_awsConfigs.AwsEndPoint)
            || string.IsNullOrWhiteSpace(_awsConfigs.AwsSecretAccessKey) || string.IsNullOrWhiteSpace(_awsConfigs.BucketName) || string.IsNullOrWhiteSpace(_awsConfigs.FilePerfix))
            {
                throw new ArgumentNullException("缺少AWS存储所需配置，请检查配置");
            }

            var tmpBucketRegion = typeof(RegionEndpoint).GetField(_awsConfigs.AwsEndPoint)?.GetValue(null);
            if (tmpBucketRegion == null)
            {
                throw new ArgumentNullException("AWS存储所需配置AmazonS3Config.BucketName不在范围内，请检查配置");
            }
            var region = tmpBucketRegion as RegionEndpoint;
            _s3Client = new AmazonS3Client(_awsConfigs.AwsAccessKeyId, _awsConfigs.AwsSecretAccessKey, region);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="folderKey"></param>
        /// <returns></returns>
        public override async Task<bool> CreateFolder(string bucketName, string folderKey)
        {
            var requestFolder = new PutObjectRequest
            {
                BucketName = _awsConfigs.BucketName,
                Key = folderKey,
                ContentBody = string.Empty,
                CannedACL = S3CannedACL.PublicRead,
            };

            var response = await _s3Client.PutObjectAsync(requestFolder);
            if (response.HttpStatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        /// <summary>
        /// 检测指定key是否存在
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public override async Task<bool> DoesFolderExist(string bucketName, string key)
        {
            try
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = _awsConfigs.BucketName,
                    MaxKeys = 1,
                    Prefix = key,
                };

                var response = await _s3Client.ListObjectsV2Async(request);

                return (response.S3Objects.Count > 0);
            }
            catch (AmazonS3Exception ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                    return false;

                throw;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="fileData"></param>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public override async Task<string> PutAsync(byte[] fileData, string? folderPath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(_awsConfigs.BucketName))
            {
                throw new ArgumentNullException("AWS存储所需配置AmazonS3Config.BucketName为空，请检查配置");
            }
            //检查存储路径是否存在
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                var folderExists = await DoesFolderExist(_awsConfigs.BucketName, folderPath);
                if (!folderExists)
                {
                    var isOk = await CreateFolder(_awsConfigs.BucketName, folderPath);
                    if (!isOk)
                        throw new Exception("创建aws文件夹失败，文件上传失败，请重试！");
                }
            }
            var request = new PutObjectRequest()
            {
                BucketName = _awsConfigs?.BucketName,
                Key = $"{folderPath}{fileName}",
                InputStream = new MemoryStream(fileData),
                ContentType = "text/plain",
                CannedACL = S3CannedACL.PublicRead
            };

            var response = await _s3Client.PutObjectAsync(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return $"{_awsConfigs?.FilePerfix ?? string.Empty}{folderPath ?? string.Empty}{fileName}";
            }

            return "";
        }
    }
}