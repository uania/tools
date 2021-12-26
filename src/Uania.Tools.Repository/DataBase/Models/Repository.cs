using Uania.Tools.Repository.DataBase.DbContexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Repository.DataBase.Models
{
    public class Repository
    {

    }

    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        private BaseDbContext _dbContext;
        public RepositoryBase(BaseDbContext dbContext)
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

    public abstract class Repository<TEntity> : RepositoryBase<TEntity, Guid>, IRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        public Repository(BaseDbContext dbContext) : base(dbContext)
        {

        }
    }
}