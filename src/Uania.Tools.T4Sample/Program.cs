using System.Data;
using Npgsql;

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