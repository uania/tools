using System.Linq.Expressions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Uania.Tools.Repository.DataBase.Models;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SideRepositoryBase
    {

    }

    public abstract class SideRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        private SideDbContext _dbContext;
        public SideRepositoryBase(SideDbContext dbContext)
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

    public abstract class SideRepositoryBase<TEntity> : SideRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>
    {
        public SideRepositoryBase(SideDbContext dbContext) : base(dbContext)
        {

        }
    }
}