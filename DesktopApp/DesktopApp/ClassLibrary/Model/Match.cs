using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary.Model
{


    //public enum Position { Defender, Forward, Goalie, Midfield };


    public enum StageName { FirstStage, Final, PlayOffForThirdPlace, QuarterFinals, RoundOf16, SemiFinals };
    public class Match : IComparable<Match>
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }



        [JsonProperty("fifa_id")]

        public int FifaId { get; set; }



        [JsonProperty("attendance")]

        public int Attendance { get; set; }



        [JsonProperty("stage_name")]
        public string Stage { get; set; }

        [JsonProperty("home_team_country")]
        public string TeamCountry { get; set; }

        [JsonProperty("home_team")]
        public Team Team { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> TeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics TeamStatistics { get; set; }
        public int CompareTo(Match other) => Team.Country.CompareTo(other.Team.Country);

    }





}

