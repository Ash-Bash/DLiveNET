using System;
using DLiveNET;

namespace DLiveNET.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DLive dlive = new DLive("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImRsaXZlLTUzMDkzNzE4IiwiZGlzcGxheW5hbWUiOiJPYmxpdmlmcmVrIiwiYXZhdGFyIjoiaHR0cHM6Ly9pbWFnZXMucHJkLmRsaXZlY2RuLmNvbS9hdmF0YXIvM2U3MmQ1ZDMtNWFmMC0xMWU5LWFiMTctODY1NjM0Zjk1YjZiIiwicGFydG5lcl9zdGF0dXNfc3RyaW5nIjoiTk9ORSIsImlkIjoiMTExMDg2OTE5OTEwMTkyMDY4NjA5IiwibGlkIjowLCJ0eXBlIjoiZ29vZ2xlIiwicm9sZSI6Ik5vbmUiLCJvYXV0aF9hcHBpZCI6IiIsImV4cCI6MTU2MDcwNzA3NywiaWF0IjoxNTU4MDI4Njc3LCJpc3MiOiJMaW5vQXBwIn0.s-48WvfyvU-GpQGlEmKrbkyaWQj7QfyBL5noFlo0EGQ");

            Console.WriteLine("DLive.NET Library Test Application");
            Console.WriteLine("Application Version: 0.0.1");
            Console.WriteLine("Library Version: 0.0.1");
            Console.Write(dlive.TestConnection());
        }
    }
}
