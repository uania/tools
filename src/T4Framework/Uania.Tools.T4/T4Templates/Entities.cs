using System.ComponentModel.DataAnnotations.Schema;

namespace Uania.Tools.Repository.Entities
{
    [Table("sports_testing_users")]
    public class SportsTestingUsers  : SportsTestingBaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("user_name")]
        public string UserName {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("user_phone")]
        public string UserPhone {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("user_email")]
        public string UserEmail {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("user_state")]
        public int UserState {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("user_role")]
        public int UserRole {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("is_delete")]
        public bool IsDelete {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("create_time")]
        public DateTime CreateTime {get; set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [Column("last_update_time")]
        public DateTime LastUpdateTime {get; set;}
        
    
    }
}      

