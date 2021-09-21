using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Serialisatie
{
    interface IKlantSerializer
    {
        List<Klant> GetKlantenFromSerialization(string jsonString);
    }
}
