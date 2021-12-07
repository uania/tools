using System.Linq.Expressions;

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

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> Update(List<TEntity> entities);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid>, IRepository where TEntity : class, IEntity<Guid>
    {

    }
}