using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Messaging
{
    class MailMessaging
    {
        ILogger logger;
        public MailMessaging(ILogger logger)
        {
            this.logger = logger;
        }
        public void SendComfirmationMessage(Klant klant)
        {
            logger.Log("stuur een mail naar de klant");
            logger.Log("SENDING MAIL..."); //fake
        }
    }
}
