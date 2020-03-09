using ClassLibrary.Model;
using ClassLibrary.ModelFull;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataAccess
{
   public static class WPFRepo
    {
        private static List<Match> AllTeamsCollection = new List<Match>();

        private static List<MatchFull> FullTeamsCollection = new List<MatchFull>();

        private static List<TeamPartial> TeamPartials = new List<TeamPartial>();

        private static List<MatchFull> oposingTeamsCollection = new List<MatchFull>();

        private static List<PlayerFull> homePlayersCollection = new List<PlayerFull>();

       

        private static List<PlayerFull> opposingPlayersCollection = new List<PlayerFull>();

        public async static Task SetAllTeamsCollection(Task<SortedSet<Match>> setList)
        {
            foreach (var item in await setList)
            {
                AllTeamsCollection.Add(item);
            }
        }

       

        public async static Task SetFullListCollection(Task<List<MatchFull>> setListFull)
        {
            foreach (var item in await setListFull)
            {
                FullTeamsCollection.Add(item);
            }
        }


        public async static Task SetTeamPartialCollection(Task<List<TeamPartial>> setTeamPartial)
        {
            foreach (var item in await setTeamPartial)
            {
                TeamPartials.Add(item);
            }
        }


        public static List<Team> GetAllTeamsCollection()
        {

            List<Team> teams = new List<Team>();

            foreach (var item in AllTeamsCollection)
            {
                teams.Add(item.Team);
            }

            return teams;
        }

       

        public static void SetOposingTeams(string countraName)
        {
            oposingTeamsCollection.Clear();

            //List<MatchFull> matchFulls = new List<MatchFull>();
            foreach (var item in FullTeamsCollection)
            {
                if (item.HomeTeamCountry==countraName || item.AwayTeamCountry==countraName)
                {
                    oposingTeamsCollection.Add(new MatchFull
                    {
                        HomeTeam = item.HomeTeam,
                        AwayTeam = item.AwayTeam
                    });
                }
            }

        }

        public static List<TeamFull> GetOposingTeams(string countryName)
        {

            List<TeamFull> teamFulls = new List<TeamFull>();
            foreach (var item in oposingTeamsCollection)
            {
                if (item.HomeTeam.GetCountryAndCodeFull()==countryName)
                {
                    teamFulls.Add(item.AwayTeam);
                }
                 if (item.AwayTeam.GetCountryAndCodeFull()==countryName)
                {
                    teamFulls.Add(item.HomeTeam);
                }
            }

            return teamFulls;
        }

        public static TeamPartial GetTeamVM(string selectFavouriteTeam)
        {
            TeamPartial team = new TeamPartial();

            try
            {
                foreach (var item in TeamPartials)
                {
                    if (item.GetCountryAndCode() == selectFavouriteTeam)
                    {
                        team = item;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Nema podatka o momčadi.");
            }

            return team;
        }

        public static PlayerFull GetPlayerVM(string selectedPlayer, string domaca, string protivnicka)
        {
            PlayerFull player = new PlayerFull();

            int numberOfYellowCards = 0;
            int numberOfGoals = 0;
            foreach (var item in FullTeamsCollection)
            {

                if ((item.AwayTeamCountry == domaca || item.HomeTeamCountry == domaca)
                            && (item.AwayTeamCountry == protivnicka || item.HomeTeamCountry == protivnicka))
                {
                    foreach (var e in item.HomeTeamEvents.Union(item.AwayTeamEvents))
                    {
                        if ((e.TypeOfEvent == "yellow-card") && e.Player == selectedPlayer)
                        {
                            numberOfYellowCards++;
                        }
                        if ((e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty") && e.Player == selectedPlayer)
                        {
                            numberOfGoals++;
                        }
                    }
                }
            }

            foreach (var item in homePlayersCollection.Union(opposingPlayersCollection))
            {
                if (item.Name == selectedPlayer)
                {

                    player.Name = selectedPlayer;
                    player.ShirtNumber = item.ShirtNumber;
                    player.Captain = item.Captain;
                    player.Position = item.Position;
                    player.GoalsScored = numberOfGoals;
                    player.NumOfYellowCards = numberOfYellowCards;
                }
            }

            return player;

        }



        public static void SetPlayers(string domacaReprezentacija, string protivnickaReprezentacija)
        {

            foreach (var item in FullTeamsCollection)
            {
                if ((item.HomeTeamCountry==domacaReprezentacija || item.AwayTeamCountry==domacaReprezentacija)
                    && (item.HomeTeamCountry==protivnickaReprezentacija || item.AwayTeamCountry==protivnickaReprezentacija))
                {
                    foreach (var player in item.HomeTeamStatistics.StartingEleven)
                    {
                        homePlayersCollection.Add(player);
                    }
                    foreach (var player in item.AwayTeamStatistics.StartingEleven)
                    {
                        opposingPlayersCollection.Add(player);
                    }

                }
            }
        }


        public static void ClearHomePlayersCollection()
        {
           
                homePlayersCollection.Clear();
          
        }

        public static void ClearOpposingPlayersCollection()
        {
            
                opposingPlayersCollection.Clear();
        
        }

        public static PlayerFull GetHomeGoalie()
        {
            PlayerFull player = new PlayerFull();

            foreach (var item in homePlayersCollection)
            {
                if (item.Position=="Goalie")
                {
                    player = item;
                    break;
                }
            }

            return player;
        }

        public static PlayerFull GetOpposingGoalie()
        {
            PlayerFull player = new PlayerFull();

            foreach (var item in opposingPlayersCollection)
            {
                if (item.Position == "Goalie")
                {
                    player = item;
                    break;
                }
            }

            return player;
        }

        public static List<PlayerFull> GetHomeDefenders()
        {

            List<PlayerFull> defenderCollection = new List<PlayerFull>();

            foreach (var item in homePlayersCollection)
            {
                if (item.Position=="Defender")
                {
                    defenderCollection.Add(item);
                }
            }

            return defenderCollection;
        }

        public static List<PlayerFull> GetHomeMidfielders()
        {
            List<PlayerFull> midfieldCollection = new List<PlayerFull>();
            


            foreach (var item in homePlayersCollection)
            {
                if (item.Position=="Midfield")
                {
                    midfieldCollection.Add(item);
                }
            }

            return midfieldCollection;
        }

        public static List<PlayerFull> GetOpposingDefenders()
        {
            List<PlayerFull> defenderCollection = new List<PlayerFull>();

            foreach (var item in opposingPlayersCollection)
            {
                if (item.Position == "Defender")
                {
                    defenderCollection.Add(item);
                }
            }

            return defenderCollection;
        }

        public static List<PlayerFull> GetHomeForwards()
        {
            List<PlayerFull> forwardCollection = new List<PlayerFull>();

            foreach (var item in homePlayersCollection)
            {
                if (item.Position=="Forward")
                {
                    forwardCollection.Add(item);
                }
            }

            return forwardCollection;
        }

        public static List<PlayerFull> GetHomePlayers()
        {
            return homePlayersCollection;
        }

        public static List<PlayerFull> GetOpposingMidfield()
        {
            List<PlayerFull> midfieldCollection = new List<PlayerFull>();

            foreach (var item in opposingPlayersCollection)
            {
                if (item.Position == "Midfield")
                {
                    midfieldCollection.Add(item);
                }
            }

            return midfieldCollection;
        }

        public static List<PlayerFull> GetOpposingForwards()
        {
            List<PlayerFull> forwardCollection = new List<PlayerFull>();

            foreach (var item in opposingPlayersCollection)
            {
                if (item.Position == "Forward")
                {
                    forwardCollection.Add(item);
                }
            }

            return forwardCollection;
        }
    }
}
