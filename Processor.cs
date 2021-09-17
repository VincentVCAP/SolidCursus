using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Factory;
using SOLID_Start.Loggen;
using SOLID_Start.Messaging;
using SOLID_Start.Movies;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using SOLID_Start.Validatie;
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
        KlantValidatie klantValidatie;
        MailMessaging mailMessaging;
        MovieFactory movieFactory;
        public Processor()
        {
            logger = new ConsoleLogger();
            source = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantenSerializer();
            klantValidatie = new KlantValidatie();
            mailMessaging = new MailMessaging();
            movieFactory = new MovieFactory();
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();
            string json = source.GetKlantenFromFile();
            klanten = jsonKlantSerializer.GetKlantenFromJsonString(json);

            ProcessKlant(klanten[0], "Godfather", 1, 3);
            ProcessKlant(klanten[1], "Lion King", 2, 2);
            ProcessKlant(klanten[2], "Rundskop", 1, 4);
            ProcessKlant(klanten[3], "Top Gun", 3, 1);

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {
                logger.Log(klant.GetRekening());
                mailMessaging.SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");

            Console.ReadLine();
        }
        private void ProcessKlant(Klant klant, string movieName, int priceCode, int aantalDagen)
        {
            if (klantValidatie.Validate(klant))
            {
                AddMovie(movieName, priceCode, klant, aantalDagen);
            }
        }
        private void AddMovie(string movieName, int movieType, Klant klant, int aantalDagen)
        {
            Movie movie = movieFactory.Create(movieType, movieName);
         
            if (movie != null)
            {
                klant.AddMovie(new Huur(movie, aantalDagen));
            }
        }
    }
}
