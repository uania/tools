using System.ComponentModel.DataAnnotations.Schema;

namespace Uania.Tools.Repository.Entities
{
    [Table("sports_testing_users")]
    public class SportsTestingUser : SportsTestingBaseEntity
    {
        [Column("user_name")]
        public string? UserName { get; set; }

        [Column("user_phone")]
        public string? UserPhone { get; set; }

        [Column("user_email")]
        public string? UserEmail { get; set; }

        [Column("user_role")]
        public int UserRole { get; set; }

        [Column("user_state")]
        public int UserState { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("last_update_time")]
        public DateTime LastUpdateTime { get; set; }
    }
}