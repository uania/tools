namespace Uania.Tools.Models.UserGroup
{
    public class UserGroupApply
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
        public string? Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string? Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        /// <value></value>
        public string? Company { get; set; }
    }
}