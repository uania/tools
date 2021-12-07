using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.Entities
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public virtual Guid Id { get; set; }
    }
}