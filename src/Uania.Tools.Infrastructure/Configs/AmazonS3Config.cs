namespace Uania.Tools.Infrastructure.Configs
{
    public class AmazonS3Config : ConfigBase
    {
        public new const string SectionName = "AwsStorageConfig";
        public string? AwsAccessKeyId { get; set; }

        public string? AwsSecretAccessKey { get; set; }

        public string? AwsEndPoint { get; set; }

        public string? BucketName { get; set; }

        public string? FilePerfix { get; set; }

    }
}