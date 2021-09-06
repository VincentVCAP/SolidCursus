using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLID_Start
{
    class Processor
    {

        public void Process()
        {
            List<Klant> klanten = new List<Klant>();
            string json = File.ReadAllText("./klant.json");
            klanten = JsonConvert.DeserializeObject<List<Klant>>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(klanten[0].Naam))
                Console.WriteLine("Klant moet een naam hebben");
            else            
                klanten[0].AddMovie(new Huur(new Movie("Godfather", 1), 3));

            if (String.IsNullOrEmpty(klanten[0].Naam))
                Console.WriteLine("Klant moet een naam hebben");
            else
                klanten[0].AddMovie(new Huur(new Movie("Lion King", 2), 2));

            if (String.IsNullOrEmpty(klanten[0].Naam))
                Console.WriteLine("Klant moet een naam hebben");
            else
                klanten[0].AddMovie(new Huur(new Movie("Rundskop", 1), 4));

            if (String.IsNullOrEmpty(klanten[0].Naam))
                Console.WriteLine("Klant moet een naam hebben");
            else
                klanten[0].AddMovie(new Huur(new Movie("Top Gun", 3), 1));

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
