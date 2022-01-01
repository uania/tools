// See https://aka.ms/new-console-template for more information
using Uania.Tools.TestConsole.T4;

//获取表
var entitiesT4 = new EntitiesT4();
await entitiesT4.ConsoleTables();
await entitiesT4.ConsoleColumn("sports_testing_users");
Console.WriteLine("Hello, World!");
