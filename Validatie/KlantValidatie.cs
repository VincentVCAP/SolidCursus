﻿using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Validatie
{
    class KlantValidatie
    {
        ConsoleLogger logger;
        public KlantValidatie()
        {
            logger = new ConsoleLogger();
        }
        public bool Validate(Klant klant)
        {
            if (String.IsNullOrEmpty(klant.Naam))
            {
                logger.Log("Klant moet een naam hebben");
                return false;
            }
            return true;
        }
    }
}
