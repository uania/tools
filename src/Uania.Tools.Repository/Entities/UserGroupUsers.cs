using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.Entities
{
    public class UserGroupUsers : BaseEntity, IEntity<Guid>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string UserName { get; set; } = string.Empty;
    }
}