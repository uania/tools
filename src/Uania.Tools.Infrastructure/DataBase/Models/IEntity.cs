namespace Uania.Tools.Infrastructure.DataBase.Models
{
    public interface IEntity<T> where T : struct
    {
        /// <summary>
        /// entity的id
        /// </summary>
        /// <value></value>
        public T Id { get; set; }
    }
}