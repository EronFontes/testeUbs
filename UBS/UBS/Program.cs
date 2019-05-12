using Infrastructure.Watcher;
using System;
using System.IO;

namespace UBS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("incio");

            var watcher = new Wacher();
            watcher.CreateWacher("D:\\Mock", "MOCK_DATA_1.json");

            File.Copy(Path.Combine("D:\\", "MOCK_DATA_1.json"), Path.Combine("D:\\Mock", "MOCK_DATA_1.json"), true);

            Console.ReadKey();
        }
    }
}
