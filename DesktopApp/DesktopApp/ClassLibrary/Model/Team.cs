using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class Team
    {
        public int ID { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]

        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }



        public string GetCountryAndCode() => $"{Country} {Code}";





    }
}
