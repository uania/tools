using System.ComponentModel.DataAnnotations.Schema;

namespace Uania.Tools.Repository.Entities
{
    [Table("sports_testing_users")]
    public class SportsTestingUser : SportsTestingBaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        [Column("user_name")]
        public string? UserName { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        /// <value></value>
        [Column("user_phone")]
        public string? UserPhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        /// <value></value>
        [Column("user_email")]
        public string? UserEmail { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        /// <value></value>
        [Column("user_role")]
        public int UserRole { get; set; }

        /// <summary>
        /// 状态
        /// 1=正常
        /// </summary>
        /// <value></value>
        [Column("user_state")]
        public int UserState { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        /// <value></value>
        [Column("is_delete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        [Column("password")]
        public string? Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        /// <value></value>
        [Column("last_update_time")]
        public DateTime LastUpdateTime { get; set; }
    }
}