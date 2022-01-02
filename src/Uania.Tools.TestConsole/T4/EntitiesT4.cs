using Npgsql;
using System.Data;

namespace Uania.Tools.TestConsole.T4
{
    public class EntitiesT4
    {
        public async Task ConsoleTables()
        {
            try
            {
                var connString = "Server=42.192.81.162;Port=5432;Database=sports_testing;User Id=postgres;Password=123456;Timeout=30;Pooling=true;MaxPoolSize=100;";
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                using var command = new NpgsqlCommand("SELECT table_catalog,table_schema,table_name FROM INFORMATION_SCHEMA.TABLES where table_catalog = 'sports_testing' and table_schema = 'public';", conn);
                var da = new NpgsqlDataAdapter();
                da.SelectCommand = command;
                var ds = new DataSet();
                da.Fill(ds);
                var dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    System.Console.WriteLine(dr[0]);
                    System.Console.WriteLine(dr[1]);
                    System.Console.WriteLine(dr[2]);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public async Task ConsoleColumn(string tableName)
        {
            try
            {
                var connString = "Server=42.192.81.162;Port=5432;Database=sports_testing;User Id=postgres;Password=123456;Timeout=30;Pooling=true;MaxPoolSize=100;";
                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();
                var querySql = @$"SELECT
  c.relname,
 A.attname,
 col_description(A.attrelid,A.attnum) AS description,
 format_type ( A.atttypid, A.atttypmod ) AS atttype,
 CASE WHEN A.attnotnull='f' THEN '0' ELSE '1' END AS isrequired,
 a.attnum 
FROM
 pg_class AS c,
 pg_attribute AS a
WHERE
 A.attrelid = C.oid 
 AND A.attnum > 0
 and c.relname = '{tableName}'
 ORDER BY c.relname,a.attnum;";
                using var command = new NpgsqlCommand(querySql, conn);
                var da = new NpgsqlDataAdapter();
                da.SelectCommand = command;
                var ds = new DataSet();
                da.Fill(ds);
                var dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    System.Console.WriteLine($"relname:{dr["relname"]}");
                    System.Console.WriteLine($"attname:{dr["attname"]}");
                    System.Console.WriteLine($"description:{dr["description"]}");
                    System.Console.WriteLine($"atttype:{dr["atttype"]}");
                    System.Console.WriteLine($"isrequired:{dr["isrequired"]}");
                    System.Console.WriteLine($"attnum:{dr["attnum"]}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}