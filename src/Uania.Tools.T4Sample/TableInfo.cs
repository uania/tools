using System.Collections.Generic;

namespace Uania.Tools.T4Sample
{
    public class TableInfo
    {
        public string Name { get; set; }

        public IEnumerable<ColumnInfo> Columns { get; set; }

        public string Description { get; set; }
    }
}