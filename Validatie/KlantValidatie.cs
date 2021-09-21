using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Validatie
{
    class KlantValidatie : Validator<Klant>
    {
        ILogger logger;
        public KlantValidatie(ILogger logger) : base(logger)
        { }

        public override bool Validate(Klant type)
        {
            if (type != null)
            {
                if (String.IsNullOrEmpty(type.Naam))
                {
                    logger.Log("Klant moet een naam hebben");
                    return false;
                }
                return true;
            }
            else
            {
                logger.Log("no customer set!");
                return false;
            }
        }
    }
}
