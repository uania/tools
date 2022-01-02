using System.Data;
using Npgsql;
using Uania.Tools.T4Sample.Common;

try
{
    IDatabase abc = new Portgres();
    var dt = abc.GetDataTableInfo("sports_testing_users");
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