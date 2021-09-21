
using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Export
{
    class ExportManager
    {
        private ILogger logger;
        private IExportableDocument exportDoc;
        public ExportManager(ILogger logger)
        {
            this.logger = logger;
        }

        public void ExportToText(Klant klant)
        {
            exportDoc = new KlantDocument(klant);
            Console.WriteLine((string)exportDoc.Export());
        }
    }
}
