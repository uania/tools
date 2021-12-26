using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.Entities
{
    public class SideBaseEntity : IEntity<int>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }
}