
using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Export
{
    class ExportManager
    {
        private ConsoleLogger logger;
        private IExportableDocument exportDoc;
        public ExportManager(ConsoleLogger logger)
        {
            this.logger = logger;
        }

        public void ExportToText(Klant klant)
        {
            exportDoc = new KlantDocument(klant);
            Console.WriteLine(exportDoc.ToText());
        }

    }
}
