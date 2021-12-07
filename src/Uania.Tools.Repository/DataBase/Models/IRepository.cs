namespace Uania.Tools.Repository.DataBase.Models
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        /// <summary>
        /// 异步查询列表
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync();
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid>, IRepository where TEntity : class, IEntity<Guid>
    {

    }
}