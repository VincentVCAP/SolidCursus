using SOLID_Start.Loggen;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using System;
using System.Collections.Generic;

namespace SOLID_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo-Application
            ILogger logger = new ConsoleLogger();
            IKlantSource source = new FileKlantSource();
            IKlantSerializer serializer = new JsonKlantenSerializer();
            Processor processor = new Processor(logger,serializer,source);
            processor.Process();
        }
    }
}
