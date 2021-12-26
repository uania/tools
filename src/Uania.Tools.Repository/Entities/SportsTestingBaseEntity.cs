using Uania.Tools.Repository.DataBase.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uania.Tools.Repository.Entities
{
    public class SportsTestingBaseEntity : IEntity<int>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Column("id")]
        public int Id { get; set; }
    }
}