using System.Linq.Expressions;
using Dapper;
using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SideRepository
    {

    }

    public abstract class SideRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        private UaniaSideDbContext _dbContext;
        public SideRepositoryBase(UaniaSideDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 异步查询列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetListAsync()
        {
            //TODO: 使用特性 做成通用查询
            var query = "select * from side_user;";
            using (var connection = _dbContext.CreateConnection())
            {
                var list = await connection.QueryAsync<TEntity>(query);
                return list.ToList();
            }
        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> Update(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SideRepositoryBase<TEntity> : SideRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>
    {
        public SideRepositoryBase(UaniaSideDbContext dbContext) : base(dbContext)
        {

        }
    }
}