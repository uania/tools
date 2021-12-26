using Microsoft.EntityFrameworkCore;
using Uania.Tools.Repository.Entities;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SportsTestingDbContext : DbContext
    {
        public SportsTestingDbContext(DbContextOptions<SportsTestingDbContext> options) : base(options)
        {

        }

        public DbSet<SportsTestingUser>? SportsTestingUser { get; set; }
    }
}