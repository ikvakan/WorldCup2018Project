using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary.DataAccess
{

    
    public static class FileManager
    {

        private static string rootFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));


        public static string PATH_TEAM_NAME = $"{rootFolderPath}\\podaci.txt";
        public static string PATH_PLAYERS = $"{rootFolderPath}\\igraci.txt";
        public static string PATH_SELECTED_PLAYERS = $"{rootFolderPath}\\odabrani.txt";
        public static string PATH_LANGUAGE= $"{rootFolderPath}\\jezik.txt";

        public const string FILE_PICTURES = "pictures.txt";

        //WPF
        public static string PATH_WINDOW_STATE= $"{rootFolderPath}\\windowState.txt";





        static List<Player> listFromFile = new List<Player>();

        public static string Reprezentacija { get; set; }

        static List<string> listaLbIgraci = new List<string>();

        static List<Player> listaFlpIgraci = new List<Player>();


        public static void SaveFile(List<Player> kolekcija,string path)
        {
           
                try
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Player item in kolekcija)
                        {

                       
                            writer.WriteLine($"{item.Name}|{item.ShirtNumber}|{item.Position}|{item.Captain}|{item.Favorite}"); 
                        
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Greška: {ex.Message}");
                }
            
        }

       

        public static List<Player> OpenFile(string path)
        {



            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split('|');
                        listFromFile.Add(new Player
                        {
                            Name = data[0],
                            ShirtNumber = int.Parse(data[1]),
                            Position = data[2],
                            Captain = bool.Parse(data[3]),
                            Favorite = bool.Parse(data[4])
                            
                        });
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show($"Greška: {ex.Message}");
            }

            return listFromFile;
        }

       

        public static void SaveLanguage(string cultureName)
        {

          
            try
            {
                using (StreamWriter writer = new StreamWriter(PATH_LANGUAGE))
                {
                    writer.WriteLine(cultureName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        public static string LoadLanguage()
        {
            var language = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(PATH_LANGUAGE))
                {
                    language = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greška:" + ex.Message);
            }


            return language;
        }

        public static void ResetList()
        {
            listFromFile.Clear();
        }

        public static void SaveCbReprezentacije(string selectedRep)
        {

           
            try
            {
                using (StreamWriter wr = new StreamWriter(PATH_TEAM_NAME))
                {
                    
                    wr.WriteLine(selectedRep);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greška:"+ ex.Message );
            }
        }

       

        public static string LoadCbReprezentacija()
        {

            try
            {
                using (StreamReader reader=new StreamReader(PATH_TEAM_NAME))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        Reprezentacija = reader.ReadLine();
                    }

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

            return Reprezentacija;
        }

        public static void SaveLbIgraci(List<string> kolekcija)
        {
            try
            {
                using (StreamWriter writer=new StreamWriter(PATH_PLAYERS))
                {

                    foreach (var line in kolekcija)
                    {
                        writer.Write($"{line},");

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static List<string> LoadLbIgraci()
        {
            try
            {
                using (StreamReader reader=new StreamReader(PATH_PLAYERS))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] podaci = reader.ReadLine().Split(',');
                        foreach (var line in podaci)
                        {
                            listaLbIgraci.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return listaLbIgraci;

        }

        public static void SaveFlpIgraci(List<Player> kolekcijaFlp)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(PATH_SELECTED_PLAYERS))
                {
                    foreach (var item in kolekcijaFlp)
                    {

                        writer.WriteLine($"{item.Name}|{item.ShirtNumber}|{item.Position}|{item.Captain}|{item.Favorite}");
                    }
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show("Grška:" + ex.Message);
            }
        }

        public static List<Player> LoadFlpIgraci()
        {
            try
            {
                using (StreamReader reader = new StreamReader(PATH_SELECTED_PLAYERS))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split('|');
                        listaFlpIgraci.Add(new Player
                        {
                            Name = data[0],
                            ShirtNumber = int.Parse(data[1]),
                            Position = data[2],
                            Captain = bool.Parse(data[3]),
                            Favorite = bool.Parse(data[4])
                            
                        });
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show($"Greška: {ex.Message}");
            }

            return listaFlpIgraci;
        }

        public static void SavePicture(List<string> location)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(FILE_PICTURES))
                {

                    foreach (var line in location)
                    {
                        wr.WriteLine(line);
                        
                    }
                       
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greška:" + ex.Message);
            }
        }

        public static List<string> LoadPicture()
        {
            List<string> lokacija = new List<string>();
            //string lokacija = null;
            try
            {
                using (StreamReader reader = new StreamReader(FILE_PICTURES))
                {
                    while (!reader.EndOfStream)
                    {
                        lokacija.Add(reader.ReadLine());

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greška kod load picture !:" +ex.Message);
            }

            return lokacija;

        }


        public static void SaveWindowStateWPF(string winState)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(PATH_WINDOW_STATE))
                {
                    writer.WriteLine(winState);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Grska:" + ex.Message);
            }
        }

        public static string LoadWindowState()
        {
            string winState = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(PATH_WINDOW_STATE))
                {

                   winState= reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska:" + ex.Message);
            }

            return winState;
        }



    }
     
    
        
}








