using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public enum Tactics { The3421, The343, The352, The4231, The4321, The433, The442, The451, The532, The541 };

    public class TeamStatistics
    {


        [JsonProperty("country")]
        public string Country { get; set; }

        //POSTAVA.....................................
        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
        //............................................


        [JsonProperty("attempts_on_goal")]
        public long AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long Blocked { get; set; }



        [JsonProperty("yellow_cards")]
        public int YellowCards { get; set; }


        [JsonProperty("tactics")]
        public string Tactics { get; set; }

        public List<Player> getAllPlayers { get { return StartingEleven.Union(Substitutes).ToList(); } set { } }

    }

}

