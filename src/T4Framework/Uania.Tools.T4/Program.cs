using System;

namespace Uania.Tools.T4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var fileHelp = new Common.SaveFile();
            fileHelp.Save(@"/home/yifan/abc.cs", "sfdfdgdf");
            Console.WriteLine("Hello World!");
        }
    }
}
