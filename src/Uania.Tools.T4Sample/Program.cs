using System;
using System.Collections.Generic;
using Uania.Tools.T4Sample;
using Uania.Tools.T4Sample.EntitiesT4;

// DB Type => .NET Type
var typeDef = new Dictionary<string, string>()
            {
                { "integer", "int" },
                { "varchar", "string" },
                { "date", "DateTime" },
            };

// Mock Table Data
var table = new TableInfo()
{
    Name = "staff_master",
    Description = "Stores employee information.",
    Columns = new[]
    {
                    new ColumnInfo() { Name = "staff_id", Type = "integer", IsPrimary = true, NotNull = true },
                    new ColumnInfo() { Name = "staff_name", Type = "varchar", NotNull = true },
                    new ColumnInfo() { Name = "address", Type = "varchar", Description = "Home Address." },
                    new ColumnInfo() { Name = "created_date", Type = "date" },
                }
};

// This variable type should be an interface because avoid CS1061 compile error.
// At runtime, the implementation's TransformText() is called.
ITextTemplate template = new demo(typeDef, "MyNameSpace", table);

// Actually, you can output to a file like "StaffMaster.cs".
Console.WriteLine(template.TransformText());