using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Serialisatie
{
    class JsonKlantenSerializer : IKlantSerializer
    {
        public List<Klant> GetKlantenFromSerialization(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<Klant>>(jsonString, new StringEnumConverter());
        }
    }
}
