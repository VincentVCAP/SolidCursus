using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Loggen;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLID_Start
{
    class Processor
    {
        ConsoleLogger logger;
        FileKlantSource source;
        JsonKlantenSerializer jsonKlantSerializer;
        public Processor()
        {
            logger = new ConsoleLogger();
            source = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantenSerializer();
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();
            string json = source.GetKlantenFromFile();
            klanten = jsonKlantSerializer.GetKlantenFromJsonString(json);

            if (String.IsNullOrEmpty(klanten[0].Naam))
                logger.Log("Klant moet een naam hebben");
            else            
                klanten[0].AddMovie(new Huur(new Movie("Godfather", 1), 3));

            if (String.IsNullOrEmpty(klanten[1].Naam))
                logger.Log("Klant moet een naam hebben");
            else
                klanten[1].AddMovie(new Huur(new Movie("Lion King", 2), 2));

            if (String.IsNullOrEmpty(klanten[2].Naam))
                logger.Log("Klant moet een naam hebben");
            else
                klanten[2].AddMovie(new Huur(new Movie("Rundskop", 1), 4));

            if (String.IsNullOrEmpty(klanten[3].Naam))
                logger.Log("Klant moet een naam hebben");
            else
                klanten[3].AddMovie(new Huur(new Movie("Top Gun", 3), 1));

            Console.WriteLine("start berekenen prijs");
            foreach (Klant klant in klanten)
            {
                Console.WriteLine(klant.GetRekening());
                SendComfirmationMessage(klant);
            }
            Console.WriteLine("einde berekening...");

            Console.ReadLine();
        }

        private void SendComfirmationMessage(Klant klant)
        {
            Console.WriteLine("stuur een mail naar de klant");
            Console.WriteLine("SENDING MAIL...");
        }
    }
}
