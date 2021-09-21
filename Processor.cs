using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Export;
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
        ILogger logger;
        IKlantSource klantSource;
        IKlantSerializer klantSerializer;

        KlantValidatie klantValidatie;

        MailMessaging mailMessaging;
        MovieFactory movieFactory;
        ExportManager exportManager;
        public Processor(ILogger logger,IKlantSerializer serializer,IKlantSource source)
        {
            this.logger = logger;
            klantSource = source;
            klantSerializer = serializer;
            klantValidatie = new KlantValidatie(logger);
            mailMessaging = new MailMessaging(logger);
            movieFactory = new MovieFactory();
            exportManager = new ExportManager(logger);
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();
            string json = klantSource.GetKlantenFromSource();
            klanten = klantSerializer.GetKlantenFromSerialization(json);

            /*Is dit handiger? Wat zijn de nadelen hiervan?
             * Wat zijn de voordelen?
             */
            ProcessKlant(klanten[0], "Godfather", "RegularMovie", 3);
            ProcessKlant(klanten[1], "Lion King", "ChildrenMovie", 2);
            ProcessKlant(klanten[2], "Rundskop", "NewReleaseMovie", 4);
            ProcessKlant(klanten[3], "Top Gun", "RegularMovie", 1);

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {
                logger.Log(klant.GetRekening());
                mailMessaging.SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");
            Console.WriteLine($"export van {klanten[0].Naam}:");
            exportManager.ExportToText(klanten[0]);
            Console.ReadLine();
        }
        private void ProcessKlant(Klant klant, string movieName, string type, int aantalDagen)
        {
            if (klantValidatie.Validate(klant))
            {
                AddMovie(movieName, type, klant, aantalDagen);
            }
        }
        private void AddMovie(string movieName, string type, Klant klant, int aantalDagen)
        {
            Movie movie = movieFactory.Create(type, movieName);
            klant.AddMovie(new Huur(movie, aantalDagen));
        }
    }
}
