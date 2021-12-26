using Uania.Tools.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }

        public DbSet<UserGroupUsers>? UserGroupUsers { get; set; }

        public DbSet<UserGroupApply>? UserGroupApply { get; set; }

        public DbSet<UserGroupActivity>? UserGroupActivity { get; set; }

    }
}