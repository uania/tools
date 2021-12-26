using Microsoft.EntityFrameworkCore;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SideDbContext : DbContext
    {
        public SideDbContext(DbContextOptions<SideDbContext> options) : base(options)
        {

        }
    }
}