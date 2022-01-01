using Xunit;
using Npgsql;

namespace Uania.Tools.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var connstring = "Server=42.192.81.162;Port=5432;Database=sports_testing;User Id=postgres;Password=123456;Timeout=30;Pooling=true;MaxPoolSize=100;";
        using var conn = await OpenConnectionAsync(connstring);
        using var command = new NpgsqlCommand("SELECT 1", conn);
        var da = new NpgsqlDataAdapter();
        da.SelectCommand = command;
        var ds = new DataSet();
        da.Fill(ds);
        Assert.NotNull(ds);
        Assert.Equal("啥几把玩意", "啥几把玩意");
    }
}