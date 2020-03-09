using ClassLibrary.Model;
using ClassLibrary.ModelFull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary.DataAccess
{

    public static class Repo
    {
        //async liste
        private static List<Match> kolekcija = new List<Match>();

        private static List<MatchFull> kolekcijaFull = new List<MatchFull>();

        //liste
        private static List<Player> listaIgraca = new List<Player>();

        private static List<Player> listaIgracaZaSort = new List<Player>();

        private static List<MatchFull> listaUtakmicaForSort = new List<MatchFull>();

        public async static Task SetList(Task<SortedSet<Match>> setList)
        {


            foreach (var item in await setList)
            {
                kolekcija.Add(item);
            }
            
        }

        public async static Task SetListFull(Task<List<MatchFull>> setListFull)
        {
            foreach (var item in await setListFull)
            {
                kolekcijaFull.Add(item);
            }
        }


   


        public static void SetFavouritePlayers(string name)
        {
            foreach (var item in kolekcija)
            {
                foreach (var i in item.TeamStatistics.getAllPlayers)
                {
                    if (i.Name == name)
                    {
                        i.Favorite = true;

                        listaIgraca.Add(i);
                    }
                }
            }
        }

        

        public static void SetSviIgraci(string name)
        {
            foreach (var item in kolekcija)
            {
                foreach (var i in item.TeamStatistics.getAllPlayers)
                {
                    if (i.Name == name)
                    {
                        i.Favorite = false;
                      
                        listaIgraca.Add(i);
                    }
                }
            }
        }

       

        public static List<Player> GetListaIgraca()
        {
            return listaIgraca;
        }

        public static List<Player> LoadListYellowCards()
        {
            return listaIgracaZaSort.OrderByDescending(x=>x.NumOfYellowCards).ToList();  

        }


        public static List<Player> LoadListGoalsScored()
        {
            return listaIgracaZaSort.OrderByDescending(x => x.GoalsScored).ToList();
        }

        public static List<MatchFull> LoadListAttendance()
        {
            return listaUtakmicaForSort.OrderByDescending(x => x.Attendance).ToList();
        }


       

       

        public static void setPlayerForSort(Player pl)
        {

            int brojZutih = 0;
            int brojGolova = 0;
            foreach (var item in kolekcijaFull)
            {
                foreach (var e in item.HomeTeamEvents.Union(item.AwayTeamEvents))
                {
                    if ( e.TypeOfEvent=="yellow-card" && e.Player==pl.Name )
                    {
                        brojZutih++;
                         
                    }
                   if ((e.TypeOfEvent=="goal" || e.TypeOfEvent=="goal-penalty") && e.Player==pl.Name )
                        {
                        brojGolova++;
                        }
                   

                }
            }

            listaIgracaZaSort.Add(new Player
            {
                Name = pl.Name,
                NumOfYellowCards = brojZutih,
                GoalsScored=brojGolova
            });

        }

        public static void ResetListaSort()
        {
            listaIgracaZaSort.Clear();
        }
        
        public static void SetMatchForSort(string countryName)
        {
            foreach (var item in kolekcijaFull)
            {
                if (item.HomeTeamCountry == countryName || item.AwayTeamCountry==countryName)
                {
                    listaUtakmicaForSort.Add(new MatchFull {
                        Attendance=item.Attendance,
                        Location=item.Location,
                        AwayTeamCountry=item.AwayTeamCountry,
                        HomeTeamCountry=item.HomeTeamCountry

                    });
                }
            }
        }
        

        public static void ResetListAttendance()
        {

            listaUtakmicaForSort.Clear();
           
        }

        public static Player GetPlayerByName(string name)
        {
             foreach (var item in listaIgraca)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
            
            throw new Exception("Nema traženog igrača.");
          
        }

        public static void ResetListaIgraca()
        {
            listaIgraca.Clear();
        }

        
    }
          
}

            
            
       



