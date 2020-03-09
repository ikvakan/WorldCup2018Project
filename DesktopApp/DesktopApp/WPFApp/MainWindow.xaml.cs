using ClassLibrary;
using ClassLibrary.DataAccess;

using ClassLibrary.ModelFull;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum PlayerPosition 
    {
        Goalie,
        Defender,
        Midfield,
        Forward
    }

    public enum PlayerSide
    {
        Home,
        Opposing
    }

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            APIHelper.InitializeClient();

            ClearPlayersCollection();
           // ChangeWindowState();
            LanguageHelper.SetCulture(FileManager.LoadLanguage());


            InitializeComponent();
            //ClearPlayersCollection();
           
             
        }

        private void ChangeWindowState()
        {

            if (FileManager.LoadWindowState() == "fullscreen")
            {
                WindowState = WindowState.Maximized;
            }
            else
                WindowState = WindowState.Normal;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // LanguageHelper.SetCulture(FileManager.LoadLanguage());
           
            ChangeWindowState();

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                DisableEnableControlsOnLoad(true);
                await WPFRepo.SetAllTeamsCollection(GetApi.GetMatchAsync());
                await WPFRepo.SetFullListCollection(GetApi.GetMatchFullAsync());
                await WPFRepo.SetTeamPartialCollection(GetApi.GetTeamAsync());

            }
            finally
            {
                Mouse.OverrideCursor = null;
                DisableEnableControlsOnLoad(false);
                DisableBtnPrikaziUtakmicu();
            }

            LoadFavouriteTeams();


            

        }

        private void DisableBtnPrikaziUtakmicu()
        {

            if (cbProtivnik.SelectedValue == null)
            {
                btnPrikaziUtakmicu.IsEnabled = false;
            }
           
           
        }

        private void DisableEnableControlsOnLoad(bool isEnable)
        {
            foreach (var ctr in mainGrid.Children)
            {
                if (ctr is Button)
                {
                    Button b = ctr as Button;
                    if (isEnable)
                    {
                        b.IsEnabled = false;

                    }
                    else if (!isEnable)
                    {
                        b.IsEnabled = true;
                    }
                }
              
            }
        }

        /// <summary>
        /// Ucitaj sve reprezentacije
        /// </summary>
        #region

        

        private void LoadFavouriteTeams()
        {

            foreach (var item in WPFRepo.GetAllTeamsCollection())
            {
                cbOmiljenaRep.Items.Add(item.GetCountryAndCode());
            }

            var loadTeam = FileManager.LoadCbReprezentacija();
            if (string.IsNullOrWhiteSpace(loadTeam))
            {
                cbOmiljenaRep.SelectedIndex = 0;
                loadTeam = (string)cbOmiljenaRep.SelectedValue;
                SearchOposingTeams(loadTeam);
                
            }
            else
            {
                cbOmiljenaRep.SelectedValue = loadTeam;
                SearchOposingTeams(loadTeam);
               


            }
        }

        private void SearchOposingTeams(string country)
        {
            
            var countryName =FilterContryNamesForSearch(country);
            WPFRepo.SetOposingTeams(countryName);
        }

        #endregion
        private string FilterContryNamesForSearch(string countryName)
        {
            string[] splitString = countryName.Split(null);

            var numberOfElements = splitString.GetLength(0);
            if (numberOfElements > 2)
            {
                var prvoIme = splitString[0];
                var drugIme = splitString[1];
                var combinedName = prvoIme + " " + drugIme;
                return combinedName;

            }
            else
            {
                string cName = splitString[0];
                return cName;

            }
        }


        /// <summary>
        /// Promjena indexa -> Event puni protivnicke timove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void CbOmiljenaRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbProtivnik.SelectedValue = null;

            ClearPlayersCollection();
            DisableBtnPrikaziUtakmicu();
            
            if (cbProtivnik != null)
            {
                cbProtivnik.Items.Clear();
            }

            ComboBox cb = sender as ComboBox;

            SearchOposingTeams(cb.SelectedValue.ToString());
            var countryName = cb.SelectedValue.ToString();

            foreach (var item in WPFRepo.GetOposingTeams(countryName))
            {
                cbProtivnik.Items.Add(item.GetCountryAndCodeFull());
            }
        }

        private static void ClearPlayersCollection()
        {
            WPFRepo.ClearHomePlayersCollection();
            WPFRepo.ClearOpposingPlayersCollection();
        }



        private void CbProtivnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ClearPlayersCollection();
            btnPrikaziUtakmicu.IsEnabled = true;

        }


        #endregion
        private void BtnlInfoOMiljeni_Click(object sender, RoutedEventArgs e)
        {
           

            var selectedTeam = (string)cbOmiljenaRep.SelectedValue;

            TeamInfo teamInfo = new TeamInfo(selectedTeam);
            teamInfo.Show();
            if (teamInfo.IsActive)
            {
                btnlInfoOMiljeni.IsEnabled = false;
                teamInfo.button = sender as Button;
            }

           
              

        }

        private void BtnInfoProtivnik_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedTeam = (string)cbProtivnik.SelectedValue;
            if (selectedTeam==null)
            {
                return;
            }

            TeamInfo teamInfo = new TeamInfo(selectedTeam);
            teamInfo.Show();

            if (teamInfo.IsActive)
            {
                btnInfoProtivnik.IsEnabled = false;
                teamInfo.button = sender as Button;
            }


        }
        private void BtnPrikaziUtakmicu_Click(object sender, RoutedEventArgs e)
        {
           
            ClearControls();
           
            var domacaReprezentacija=  FilterContryNamesForSearch(cbOmiljenaRep.SelectedValue.ToString());
            var protivnickaReprezentacija = FilterContryNamesForSearch(cbProtivnik.SelectedValue.ToString());

            CreatePlayersForGridField(domacaReprezentacija, protivnickaReprezentacija);

            btnPrikaziUtakmicu.IsEnabled = false;

        }
        private void Btn_ClickPlayer(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;

            var parent = (StackPanel)btn.Parent;
            var selectedPlayer = string.Empty;
            var domaca = FilterContryNamesForSearch(cbOmiljenaRep.SelectedValue.ToString());
            var protivnicka = FilterContryNamesForSearch(cbProtivnik.SelectedValue.ToString());

            foreach (var ctr in parent.Children)
            {
                if (ctr is Label )
                {
                    Label lbl = ctr as Label;
                    if ((string)lbl.Tag != "lblNumber")
                    {
                        selectedPlayer = (string)lbl.Tag;
                    }
                }
                else if (ctr is WrapPanel)
                {
                    var wrapPanel = ctr as WrapPanel;
                    foreach (var label in wrapPanel.Children)
                    {
                        Label lbl = label as Label;
                        if ((string)lbl.Tag!="lblNumber")
                        {
                            selectedPlayer = (string)lbl.Tag;
                        }
                    }
                }
            }

            PlayerFull player = WPFRepo.GetPlayerVM(selectedPlayer, domaca, protivnicka);
            PlayerInfo playerInfo = new PlayerInfo(player);
            playerInfo.Show();
        }


        private void ClearControls()
        {
            List<StackPanel> kolekcija = new List<StackPanel>();

            foreach (var ctr in gridContainer.Children)
            {
                if (ctr is StackPanel)
                {
                    StackPanel s = ctr as StackPanel;

                    kolekcija.Add(s);
                    
                    
                }
            }

            foreach (var item in kolekcija)
            {
                gridContainer.Children.Remove(item);

            }
            gridContainer.RowDefinitions.Clear();
            gridContainer.ColumnDefinitions.Clear();
        }

        private string SetPlayerNameForPlayerControl(string name)
        {
            var newName = string.Empty;

            string[] names = name.Split(null);
            var numberOfElements = names.GetLength(0);
            if (numberOfElements >= 3)
            {
                newName = names[2];
            }
            else if (numberOfElements == 2)
            {
                newName = names[1];

            }
            else if (numberOfElements == 1)
            {
                newName = names[0];
            }


            return newName;
        }


        private void CreatePlayersForGridField(string domacaReprezentacija, string protivnickaReprezentacija)
        {
            WPFRepo.SetPlayers(domacaReprezentacija, protivnickaReprezentacija);

            

            CreatePlayers(PlayerPosition.Goalie, PlayerSide.Home);
            CreatePlayers(PlayerPosition.Defender, PlayerSide.Home);
            CreatePlayers(PlayerPosition.Midfield, PlayerSide.Home);
            CreatePlayers(PlayerPosition.Forward, PlayerSide.Home);

            CreatePlayers(PlayerPosition.Goalie, PlayerSide.Opposing);
            CreatePlayers(PlayerPosition.Defender, PlayerSide.Opposing);
            CreatePlayers(PlayerPosition.Midfield, PlayerSide.Opposing);
            CreatePlayers(PlayerPosition.Forward, PlayerSide.Opposing);

        }


        private void CreatePlayers(PlayerPosition position, PlayerSide side)
        {
            switch (position)
            {
                case PlayerPosition.Goalie:
                    CreateGoalieControls(side);
                    break;
                case PlayerPosition.Defender:
                    CreateDefenderControls(side);
                    break;
                case PlayerPosition.Midfield:
                    CreateMidfieldControls(side);
                    break;
                case PlayerPosition.Forward:
                    CreateForwardControls(side);
                    break;

            }
        }

        private void CreateGoalieControls(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Home:
                    CreateControlHomeGoalie();
                    break;
                case PlayerSide.Opposing:
                    CreateControlOpposingGoalie();
                    break;

            }
        }

        private void CreateDefenderControls(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Home:
                    CreateHomeDefendersControls();
                    break;
                case PlayerSide.Opposing:
                    CreateOpposingDefendersControl();
                    break;

            }
        }

        private void CreateMidfieldControls(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Home:
                    CreateHomeMidfieldControls();
                    break;
                case PlayerSide.Opposing:
                    CreateOpposingMidfieldControls();
                    break;

            }
        }

        private void CreateForwardControls(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Home:
                    CreateControlHomeForward();
                    break;
                case PlayerSide.Opposing:
                    CreateControlOpposingForward();
                    break;

            }
        }




        /// <summary>
        /// Home player controls
        /// </summary>
        /// <param name="player"></param>
        #region
        private void CreateControlHomeGoalie()
        {
            PlayerFull player = WPFRepo.GetHomeGoalie();


            var colPos = 0;

            ColumnDefinition c = new ColumnDefinition();
           
            gridContainer.ColumnDefinitions.Add(c);

            StackPanel sp = new StackPanel();
            sp.VerticalAlignment = VerticalAlignment.Center;
            sp.HorizontalAlignment = HorizontalAlignment.Left;
            sp.Orientation = Orientation.Horizontal;
            sp.Tag = player.Position;
           
            sp.Margin = new Thickness(0);

            Button btn = new Button();
            btn.Width = 15;
            btn.Height = 15;
            btn.Background = Brushes.Red;
            btn.Click += Btn_ClickPlayer;

            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Vertical;
            Label lbl = new Label();
            lbl.Content = SetPlayerNameForPlayerControl(player.Name);
            lbl.Tag = player.Name;

            Label lblNumber = new Label();
            lblNumber.Content = player.ShirtNumber;
            lblNumber.Tag = "lblNumber";

            wp.Children.Add(lbl);
            wp.Children.Add(lblNumber);

            sp.SetValue(Grid.ColumnProperty, colPos);
            sp.SetValue(Grid.RowSpanProperty, 6);

            sp.Children.Add(btn);
            sp.Children.Add(wp);

            gridContainer.Children.Add(sp);
        }

        private void CreateHomeDefendersControls()
        {
            var rowPos = 0;
            var colPos = 1;


            var numOfRows = (int)WPFRepo.GetHomeDefenders().Count;

            if (numOfRows >= 5)
            {
                rowPos = 0;
            }
            else if (numOfRows == 4)
            {
                rowPos = 0;
            }
            else if (numOfRows == 3)
            {
                rowPos = 2;
            }

            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetHomeDefenders())
            {

                RowDefinition r = new RowDefinition();
                gridContainer.RowDefinitions.Add(r);

                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;


                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;
                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";

                sp.SetValue(Grid.RowProperty, rowPos++);
                sp.SetValue(Grid.ColumnProperty, colPos);

                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);

            }

        }

        private void CreateHomeMidfieldControls()
        {
            var rowPos = 0;
            var colPos = 2;

            var numOfRows = (int)WPFRepo.GetHomeMidfielders().Count;

            if (numOfRows==2)
            {
                rowPos = 2;
            }
            else if (numOfRows==3)
            {
                rowPos = 1;
            }

            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetHomeMidfielders())
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(0, GridUnitType.Auto);
                gridContainer.RowDefinitions.Add(r);


                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;


                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;

                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";



                sp.SetValue(Grid.RowProperty, rowPos++);
                sp.SetValue(Grid.ColumnProperty, colPos);

                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);

            }

        }

        private void CreateControlHomeForward()
        {

            var rowPos = 1;
            var colPos = 3;

            var numOfRows = (int)WPFRepo.GetHomeForwards().Count;


            if (numOfRows == 1)
            {
                rowPos = 2;
            }


            else if (numOfRows == 2)
            {
                rowPos = 1;
            }

            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetHomeForwards())
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(0, GridUnitType.Auto);
                gridContainer.RowDefinitions.Add(r);

                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;


                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;

                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";

 
                sp.SetValue(Grid.RowProperty, rowPos++); 
                sp.SetValue(Grid.ColumnProperty, colPos);

                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);


            }

        }

        #endregion

        /// <summary>
        /// Opposing player controls
        /// </summary>
        /// <param name="player"></param>
        #region
        private void CreateControlOpposingGoalie()
        {
            PlayerFull player = WPFRepo.GetOpposingGoalie();


            var colPos = 7;

            ColumnDefinition c = new ColumnDefinition();
            
            c.Width = new GridLength(0,GridUnitType.Auto);
            gridContainer.ColumnDefinitions.Add(c);

           

            StackPanel sp = new StackPanel();
            sp.VerticalAlignment = VerticalAlignment.Center;
            sp.HorizontalAlignment = HorizontalAlignment.Right;
            sp.Orientation = Orientation.Horizontal;
            sp.Tag = player.Position;
            sp.Margin = new Thickness(0);

            Button btn = new Button();
            btn.Width = 15;
            btn.Height = 15;
            btn.Background = Brushes.Red;
            btn.Click += Btn_ClickPlayer;
            


            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Vertical;
            
            
            Label lbl = new Label();
            lbl.Content = SetPlayerNameForPlayerControl(player.Name);
            lbl.Tag = player.Name;

            Label lblNumber = new Label();
            lblNumber.Content = player.ShirtNumber;
            lblNumber.Tag = "lblNumber";
            lblNumber.HorizontalAlignment = HorizontalAlignment.Right;
            wp.Children.Add(lbl);
            wp.Children.Add(lblNumber);

            sp.SetValue(Grid.ColumnProperty, colPos);
            sp.SetValue(Grid.RowSpanProperty, 6);

            sp.Children.Add(wp);
            sp.Children.Add(btn);


            gridContainer.Children.Add(sp);
            
        }

        private void CreateOpposingDefendersControl()
        {
            var rowPos = 0;
            var colPos = 6;

            var numOfRows = (int)WPFRepo.GetOpposingDefenders().Count;


            if (numOfRows >= 5)
            {
                rowPos = 0;
            }
            else if (numOfRows == 4)
            {
                rowPos = 0;
            }
            else if (numOfRows == 3)
            {
                rowPos = 2;
            }



            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetOpposingDefenders())
            {

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(0, GridUnitType.Auto);
                gridContainer.RowDefinitions.Add(row);

                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;


                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;

                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";
                sp.SetValue(Grid.RowProperty, rowPos++);
                sp.SetValue(Grid.ColumnProperty, colPos);


                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);


            }
        }


        private void CreateOpposingMidfieldControls()
        {
            var rowPos = 0;
            var colPos = 5;

            var numOfRows = (int)WPFRepo.GetOpposingMidfield().Count;

            if (numOfRows == 2)
            {
                rowPos = 2;
            }
            else if (numOfRows == 3)
            {
                rowPos = 1;
            }



            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetOpposingMidfield())
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(0, GridUnitType.Auto);
                gridContainer.RowDefinitions.Add(r);


                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;


                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;

                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";



                sp.SetValue(Grid.RowProperty, rowPos++);
                sp.SetValue(Grid.ColumnProperty, colPos);

                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);

            }

        }

        private void CreateControlOpposingForward()
        {
            var rowPos = 1;
            var colPos = 4;

            var numOfRows = (int)WPFRepo.GetOpposingForwards().Count;


            if (numOfRows == 1)
            {
                rowPos = 2;
            }


            else if (numOfRows == 2)
            {
                rowPos = 1;
            }

            ColumnDefinition c = new ColumnDefinition();
            gridContainer.ColumnDefinitions.Add(c);

            foreach (var item in WPFRepo.GetOpposingForwards())
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(0, GridUnitType.Auto);
                gridContainer.RowDefinitions.Add(r);

                StackPanel sp = new StackPanel();
                sp.VerticalAlignment = VerticalAlignment.Center;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.Orientation = Orientation.Vertical;
                sp.Tag = item.Position;

               

                Button btn = new Button();
                btn.Width = 15;
                btn.Height = 15;
                btn.Background = Brushes.Red;
                btn.Click += Btn_ClickPlayer;


                Label lbl = new Label();
                lbl.Content = SetPlayerNameForPlayerControl(item.Name);
                lbl.Tag = item.Name;

                Label lblNumber = new Label();
                lblNumber.Content = item.ShirtNumber;
                lblNumber.HorizontalAlignment = HorizontalAlignment.Center;
                lblNumber.Tag = "lblNumber";


                sp.SetValue(Grid.RowProperty, rowPos++);
                sp.SetValue(Grid.ColumnProperty, colPos);

                sp.Children.Add(btn);
                sp.Children.Add(lbl);
                sp.Children.Add(lblNumber);
                gridContainer.Children.Add(sp);


            }
        }




        #endregion

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
           
            btnSettings.IsEnabled = false;
            Settings settings = new Settings();
            settings.ShowDialog();
            mainWindow.WindowState = settings.winState;

            btnSettings.IsEnabled = true;

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowClosing windowClosing = new WindowClosing();
            windowClosing.ShowDialog();

           

            if (windowClosing.isClosing)
            {
                //DA
                e.Cancel = false;
                
                Application.Current.Shutdown();
               
            }
            else
            {
                //NE
                e.Cancel = true;
                mainWindow.Closing -= MainWindow_Closing;

            }

            mainWindow.Closing += MainWindow_Closing;
        }

       
    }
}
