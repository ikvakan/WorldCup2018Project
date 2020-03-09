using ClassLibrary;
using ClassLibrary.Model;
using ClassLibrary.ModelFull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataAccess
{


    public static class GetApi
    {


        private static SortedSet<Match> kolekcija;

        private static List<MatchFull> kolekcijaFull; 

        private static List<TeamPartial> kolekcijaPartial { get; set; }



        public static async Task<List<MatchFull>> GetMatchFullAsync()
        {

            kolekcijaFull = new List<MatchFull>();

            string url = "https://world-cup-json-2018.herokuapp.com/matches";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<MatchFull>>();

                    foreach (var item in data)
                    {

                        kolekcijaFull.Add(new MatchFull
                        {
                            Attendance=item.Attendance,
                            AwayTeam=item.AwayTeam,
                            AwayTeamCountry=item.AwayTeamCountry,
                            AwayTeamEvents=item.AwayTeamEvents,
                            AwayTeamStatistics=item.AwayTeamStatistics,
                            Datetime=item.Datetime,
                            FifaId=item.FifaId,
                            HomeTeam=item.HomeTeam,
                            HomeTeamCountry=item.HomeTeamCountry,
                            HomeTeamEvents=item.HomeTeamEvents,
                            HomeTeamStatistics=item.HomeTeamStatistics,
                            Location=item.Location,
                            Officials=item.Officials,
                            StageName=item.StageName,
                            Venue=item.Venue,
                            Winner=item.Winner,
                            WinnerCode=item.WinnerCode


                        });
                    }
                    return kolekcijaFull;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }


        public static async Task<SortedSet<Match>> GetMatchAsync()
        {

            kolekcija = new SortedSet<Match>();

            string url = "https://world-cup-json-2018.herokuapp.com/matches";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<SortedSet<Match>>();

                    foreach (var item in data)
                    {

                        kolekcija.Add(new Match
                        {
                            Attendance = item.Attendance,
                        
                            FifaId = item.FifaId,
                            Team = item.Team,
                            TeamCountry = item.TeamCountry,
                            TeamEvents = item.TeamEvents,
                            TeamStatistics = item.TeamStatistics,
                            Location = item.Location,
                            Stage = item.Stage,
                            Venue = item.Venue
                            

                        });
                    }
                    return kolekcija;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
        //...............

        public static async Task<List<TeamPartial>> GetTeamAsync()
        {

            kolekcijaPartial = new List<TeamPartial>();
            string url = "https://world-cup-json-2018.herokuapp.com/teams/results";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<TeamPartial>>();

                    foreach (var item in data)
                    {
                        kolekcijaPartial.Add(new TeamPartial
                        {

                            Country = item.Country,
                            FifaCode = item.FifaCode,
                            GamesPlayed = item.GamesPlayed,
                            Draws = item.Draws,
                            GoalDifferential = item.GoalDifferential,
                            GoalsAgainst = item.GoalsAgainst,
                            GoalsFor = item.GoalsFor,
                            GroupId = item.GroupId,
                            Losses = item.Losses,
                            GroupLetter = item.GroupLetter,
                            Id = item.Id,
                            Points = item.Points,
                            Wins = item.Wins

                        });

                    }
                    return kolekcijaPartial;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        //.............



    }
}
