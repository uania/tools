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

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity?> GetInfo(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid>, IRepository where TEntity : class, IEntity<Guid>
    {

    }

    public interface ISportsTestingRepository<TEntity> : IRepository<TEntity, int>, IRepository where TEntity : class, IEntity<int>
    {

    }
}