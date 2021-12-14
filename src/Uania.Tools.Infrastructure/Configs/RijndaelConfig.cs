namespace Uania.Tools.Infrastructure.Configs
{
    public class RijndaelConfig : ConfigBase
    {
        public new const string SectionName = "RijndaelConfig";

        public string? Key { get; set; }
    }
}