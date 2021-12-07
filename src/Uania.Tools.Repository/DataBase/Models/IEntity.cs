namespace Uania.Tools.Repository.DataBase.Models
{
    public interface IEntity
    {

    }

    public interface IEntity<T> : IEntity where T : struct
    {
        /// <summary>
        /// entity的id
        /// </summary>
        /// <value></value>
        public T Id { get; set; }
    }
}