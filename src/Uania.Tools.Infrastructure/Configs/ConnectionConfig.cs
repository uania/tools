namespace Uania.Tools.Infrastructure.Configs
{
    public class ConnectionConfig : ConfigBase
    {
        public new const string SectionName = "ConnectionStrings";

        public string? SqlServerConnection { get; set; }
    }
}