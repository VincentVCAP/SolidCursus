using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Serialisatie
{
    class JsonKlantenSerializer
    {
        public List<Klant> GetKlantenFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<Klant>>(jsonString, new StringEnumConverter());
        }
    }
}
