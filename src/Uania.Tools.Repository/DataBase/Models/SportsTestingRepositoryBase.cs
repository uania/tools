using System.Linq.Expressions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Uania.Tools.Repository.DataBase.DbContexts;

namespace Uania.Tools.Repository.DataBase.Models
{
    public class SportsTestingRepositoryBase
    {

    }

    public abstract class SportsTestingRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        private SportsTestingDbContext _dbContext;
        public SportsTestingRepositoryBase(SportsTestingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        /// <summary>
        /// 异步查询列表
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<TEntity>> GetListAsync()
        {
            return Table.Where(r => 1 == 1).ToListAsync();
        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToListAsync();
        }

        public virtual async Task<int> Update(List<TEntity> entities)
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }
    }
    public abstract class SportsTestingRepositoryBase<TEntity> : SportsTestingRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>
    {
        public SportsTestingRepositoryBase(SportsTestingDbContext dbContext) : base(dbContext)
        {

        }
    }
}