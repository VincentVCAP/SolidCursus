using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Loggen
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message) ;
        }
    }
}
