using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ModelFull
{
    public class MatchFull 
    {

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

    

        [JsonProperty("fifa_id")]
        public long FifaId { get; set; }

        

        [JsonProperty("attendance")]
    
        public int Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string> Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public TeamFull HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public TeamFull AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEventFull> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEventFull> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatisticsFull HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatisticsFull AwayTeamStatistics { get; set; }

    }

}



