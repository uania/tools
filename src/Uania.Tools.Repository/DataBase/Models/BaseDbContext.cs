using Uania.Tools.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Repository.DataBase.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }

        public DbSet<UserGroupUsers>? UserGroupUsers { get; set; }

        public DbSet<UserGroupApply>? UserGroupApply { get; set; }

    }
}