using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ModelFull
{
   public class PlayerFull 
    {


        [JsonProperty("name")]
        public  string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public int GoalsScored { get; set; }

        public int NumOfYellowCards { get; set; }


       

    }
}
