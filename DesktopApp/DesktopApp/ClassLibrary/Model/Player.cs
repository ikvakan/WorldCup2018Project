using ClassLibrary.DataAccess;
using ClassLibrary.Model;
using ClassLibrary.ModelFull;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public enum Pozicija { Defender, Forward, Goalie, Midfield };
    public class Player 
    {

       

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
        public bool Favorite { get; set; }

        public int GoalsScored { get; set; }

        public int NumOfYellowCards { get; set; }

        


    }
}