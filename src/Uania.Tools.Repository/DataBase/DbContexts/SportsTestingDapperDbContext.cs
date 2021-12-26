using Uania.Tools.Infrastructure.Configs;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Uania.Tools.Repository.DataBase.DbContexts
{
    public class SportsTestingDapperDbContext
    {
        private readonly ConnectionConfig _connectionConfig;
        public SportsTestingDapperDbContext(IOptions<ConnectionConfig>? options)
        {
            if (options == null)
            {
                throw new ArgumentException("dapper配置异常");
            }
            _connectionConfig = options.Value;
        }

        public IDbConnection CreateConnection()
               => new SqlConnection(_connectionConfig.PostgresqlConnection);
    }
}