namespace Uania.Tools.Models.UserGroup
{
    public class UserGroupUsers
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string? UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string? MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        /// <value></value>
        public string? CompanyName { get; set; }
    }
}