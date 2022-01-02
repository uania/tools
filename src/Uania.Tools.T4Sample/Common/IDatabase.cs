using System.Data;
using System.Collections.Generic;

namespace Uania.Tools.T4Sample.Common
{
    public interface IDatabase
    {
         DataTable GetDataTableInfo(string tableName);

         DataTableCollection GetDataTables();
    }
}