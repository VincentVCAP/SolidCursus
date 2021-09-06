using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Loggen;
using SOLID_Start.Messaging;
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
        public Processor()
        {
            logger = new ConsoleLogger();
            source = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantenSerializer();
            klantValidatie = new KlantValidatie();
            mailMessaging = new MailMessaging();
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();
            string json = source.GetKlantenFromFile();
            klanten = jsonKlantSerializer.GetKlantenFromJsonString(json);

            if (klantValidatie.Validate(klanten[0]))
                klanten[0].AddMovie(new Huur(new Movie("Godfather", 1), 3));

            if (klantValidatie.Validate(klanten[1]))
                klanten[1].AddMovie(new Huur(new Movie("Lion King", 2), 2));

            if (klantValidatie.Validate(klanten[2]))
                klanten[2].AddMovie(new Huur(new Movie("Rundskop", 1), 4));

            if (klantValidatie.Validate(klanten[3]))
                klanten[3].AddMovie(new Huur(new Movie("Top Gun", 3), 1));

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {
                logger.Log(klant.GetRekening());
                mailMessaging.SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");

            Console.ReadLine();
        }

    }
}
