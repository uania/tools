namespace Uania.Tools.Infrastructure.Configs
{
    public class JwtConfig:ConfigBase
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public new const string SectionName = "JwtConfig";
        
        /// <summary>
        /// 加密key
        /// </summary>
        /// <value></value>
        public string? SecretKey { get; set; }

        /// <summary>
        /// 颁发者
        /// </summary>
        /// <value></value>
        public string? Issuer { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <value></value>
        public string? Expires { get; set; }

        /// <summary>
        /// 使用者
        /// </summary>
        /// <value></value>
        public string? Audience { get; set; }
    }
}