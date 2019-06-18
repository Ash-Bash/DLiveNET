using System;
using DLiveNET;

namespace DLiveNET.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DLive dlive = new DLive("");

            Console.WriteLine("DLive.NET Library Test Application");
            Console.WriteLine("Application Version: 0.0.1");
            Console.WriteLine("Library Version: 0.0.1");
            dlive.TestConnection();
        }
    }
}
    