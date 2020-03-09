using ClassLibrary;
using ClassLibrary.DataAccess;
using ClassLibrary.Model;
using ClassLibrary.ModelFull;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace WindowsFormsApp
{

    public enum LabelNameInfo
    {

        NameInfo,
        ShirtNumberInfo,
        PositionInfo,
        FavouriteInfo,
        CaptainInfo
    }

    public enum LabelName
    {
        Name,
        ShirtNumber,
        Position,
        Favourite,
        Captain,
        NumOfYellowCards,
        GoalsScored,
        Lokacija,
        Posjetitelji,
        Domacin,
        Gost
    }



    public enum TipSortiranja
    {
        SortirajZute,
        SortirajGolove,
        SortirajPosjetitelje
    }


    public partial class MainForm : Form
    {

        private List<Match> matches = new List<Match>();

        private static List<Player> kolekcija = Repo.GetListaIgraca();


        private static Player oznaceniIgrac = new Player();

        private PictureBox loadPictureBox = null;


        //Panel
        private Panel oznacenaPanela;

        private PictureBox odabraniPictureBox;

        private ListBox oznaceniListBox;


        private int visina_panela = 150;

        private int pnl_lokacija_x = 800;
        private int pnl_lokacija_y = 160;

        private  TipSortiranja sortiranjePrint;
       
        //FORMA

        PrikaziIgraca prikazi;

        FormaObavijest obavijest;

        //PRINT

        private int printanoStranica;

         
        public MainForm()
        {
            
           
            APIHelper.InitializeClient();
            UseWaitCursor = true;

            if (!File.Exists(FileManager.PATH_LANGUAGE))
            {
                LanguageHelper.SetCulture("hr");
            }
            else
                LanguageHelper.SetCulture(FileManager.LoadLanguage());
           
            InitializeComponent();
            
        }

        private void SetLanguage()
        {
          
            FormaPostaviJezik jezik = new FormaPostaviJezik();
            if (!File.Exists(FileManager.PATH_LANGUAGE))
            {
                if (jezik.ShowDialog() == DialogResult.OK)
                {
                    
                    LanguageHelper.SetCulture(FileManager.LoadLanguage());
                    this.Controls.Clear();
                    InitializeComponent();
                    this.FormClosing -= MainForm_FormClosing;
                    this.Load -= MainForm_Load;
                }
            }
            


        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            do
            {
                SetLanguage();
            } while (!File.Exists(FileManager.PATH_LANGUAGE));

            await Repo.SetListFull(GetApi.GetMatchFullAsync());
            await LoadKolekcija();

            await Repo.SetList(GetApi.GetMatchAsync());

            UseWaitCursor = false;
            saveFileToolStripMenuItem.Enabled = false;

            if (!(!File.Exists(FileManager.PATH_TEAM_NAME)|| !File.Exists(FileManager.PATH_PLAYERS) || !File.Exists(FileManager.PATH_SELECTED_PLAYERS)))
            {
                SetLoadFormForContinue();
            }



        }

        private void SetLoadFormForContinue()
        {
            obavijest = new FormaObavijest();

            if (obavijest.ShowDialog() == DialogResult.OK)
            {
                LoadLbIgraci();
                LoadCbRep();
                LoadFlpIgraci();
                LoadPictures();

                btnSortdGoalsScored.Enabled = false;
                btnSortedAttendance.Enabled = false;
                btnSortYellowCards.Enabled = false;
            }
        }

        public async Task LoadKolekcija()
        {
            //kolekcija je SortedSet!!!
            var getMatchAsync = await GetApi.GetMatchAsync();

            foreach (var item in getMatchAsync)
            {
                matches.Add(item);
                cbReprezentacijie.Items.Add(item.Team.GetCountryAndCode());

            }

        }


        private T GetKontrola<T>(Control parent)
        {
            foreach (var ctrl in parent.Controls)
            {
                if (ctrl is T)
                    return (T)ctrl;
            }

            return default(T);
        }

        private void BtnOdaberi_Click(object sender, EventArgs e)
        {

            btnSortdGoalsScored.Enabled = true;
            btnSortedAttendance.Enabled = true;
            btnSortYellowCards.Enabled = true;

            //brisanje panele i liste omiljenih
            lbIgraci.Items.Clear();
            kolekcija.Clear();
            Repo.ResetListaSort();


            if (cbReprezentacijie.Items != null)
            {
                flpOmiljeniIgraci.Controls.Clear();

                foreach (var item in matches)
                {
                    if (item.Team.GetCountryAndCode() == (string)cbReprezentacijie.SelectedItem)
                    {

                        foreach (var i in item.TeamStatistics.getAllPlayers)
                        {

                            lbIgraci.Items.Add(i.Name);

                            Repo.setPlayerForSort(i);
                        }


                        Repo.SetMatchForSort(item.Team.Country);
                    }

                }
            }

            cbReprezentacijie.SelectedIndexChanged += CbReprezentacijie_SelectedIndexChanged;

            labelOdabrani.Visible = false;

        }

        private void CbReprezentacijie_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFileToolStripMenuItem.Enabled = false;
            Repo.ResetListAttendance();
        }

        public void CreatePanel(List<Player> lista)
        {


            flpOmiljeniIgraci.Controls.Clear();
            labelOdabrani.Visible = true;




            foreach (Player item in lista)
            {
                var sirina_panela = flpOmiljeniIgraci.Width - 30;

                Panel pnl = new Panel();
                pnl.Location = new Point(pnl_lokacija_x, pnl_lokacija_y);
                pnl.Size = new Size(sirina_panela, visina_panela);
                pnl.BorderStyle = BorderStyle.None;
                pnl.BackColor = Color.Transparent;
                pnl.Click += Pnl_Click;
                pnl.ContextMenuStrip = contextMenuStripOdabrani;

               

                int x = 20;
                int y = 20;


                Point nameLokacijaInfo = new Point(x, y);
                Point shirtNumberInfo = new Point(x, nameLokacijaInfo.Y + y);
                Point positionInfo = new Point(x, shirtNumberInfo.Y + y);
                Point favouriteInfo = new Point(x, positionInfo.Y + y);
                Point captainInfo = new Point(x, favouriteInfo.Y + y);


                

                if (FileManager.LoadLanguage()=="hr")
                {
                    pnl.Controls.Add(CreateLabelInfo("Ime igrača:", nameLokacijaInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Broj dresa:", shirtNumberInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Pozicija:", positionInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Omiljeni igrač:", favouriteInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Kapetan:", captainInfo, false));

                }

               else if (FileManager.LoadLanguage()=="en")
                {
                    pnl.Controls.Add(CreateLabelInfo("Player name:", nameLokacijaInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Shirt number:", shirtNumberInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Position:", positionInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Favourite player:", favouriteInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Captain:", captainInfo, false));

                }


                int pos_x = 150;
                int pos_y = 20;

                Point nameLokacija = new Point(pos_x, pos_y);
                Point shirtNumber = new Point(pos_x, nameLokacija.Y + pos_y);
                Point position = new Point(pos_x, shirtNumber.Y + pos_y);
                Point favourite = new Point(pos_x, position.Y + pos_y);
                Point captain = new Point(pos_x, favourite.Y + pos_y);


                pnl.Controls.Add(GetLabel(item.Name, nameLokacija, LabelName.Name));
                pnl.Controls.Add(GetLabel((item.ShirtNumber.ToString()), shirtNumber, LabelName.ShirtNumber));
                pnl.Controls.Add(GetLabel(item.Position, position, LabelName.Position));
                pnl.Controls.Add(GetLabel(item.Captain ? "Kapetan" : "---", captain, LabelName.Captain));
                pnl.Controls.Add(CreateFavouritePlayerIcon(item.Favorite, favourite));

                var picturePos_X = pos_x + 150;
                var picturePos_Y = pos_y;

                pnl.Controls.Add(CreatePicturBox(picturePos_X, picturePos_Y, false));  

                flpOmiljeniIgraci.Controls.Add(pnl);

            }

        }

        private void Pnl_Click(object sender, EventArgs e)
        {
            if (oznacenaPanela != null)
            {
                oznacenaPanela.BackColor = Color.Transparent;
            }



            if (sender is Label)
            {
                oznacenaPanela = ((sender as Label).Parent) as Panel;
                oznacenaPanela.BackColor = Color.LightBlue;

            }
            else if (sender is PictureBox)
            {
                oznacenaPanela = ((sender as PictureBox).Parent as Panel);
                oznacenaPanela.BackColor = Color.LightBlue;

            }
            else
            {
                oznacenaPanela = sender as Panel;
                oznacenaPanela.BackColor = Color.LightBlue;

            }

            SetOznaceniPictureBox(oznacenaPanela);

            SetOznaceniIgrac(oznacenaPanela);

        }

        private void SetOznaceniPictureBox(Panel oznacenaPanela)
        {
            foreach (Control ctrl in oznacenaPanela.Controls)
            {
                if (ctrl is PictureBox)
                {
                    if (ctrl.Name == "playerIcon")
                    {

                        odabraniPictureBox = ctrl as PictureBox;
                    }

                }
            }
        }

        private Control CreateFavouritePlayerIcon(bool isFavourite, Point loacation)
        {
            if (isFavourite)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = loacation;
                pictureBox.Size = new Size(20, 20);
                pictureBox.Image = Resource.StarIcon;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                return pictureBox;
            }
            else
                return null;
        }



        private Control CreateLabelInfo(string txt, Point lokacija, bool isForSort)
        {
            Label lbl = new Label();
            lbl.Text = txt;
            lbl.Location = lokacija;
            lbl.Width = 100;
            lbl.Height = 20;

            if (isForSort)
            {
                lbl.Click -= Pnl_Click;
            }
            else
                lbl.Click += Pnl_Click;



            return lbl;
        }

        private void LoadPictures()
        {
            

            List<string> lista = FileManager.LoadPicture();
            foreach (Control ctrl in flpOmiljeniIgraci.Controls)
            {
                if (ctrl is Panel)
                {
                    foreach (Control pic  in ctrl.Controls)
                    {
                        PictureBox pb = pic as PictureBox;

                        if (pb is PictureBox)
                        {
                            if (pb.Name == "playerIcon")
                            {
                                
                                foreach (var line in lista)
                                {
                                    
                                    pb.ImageLocation = line;

                                }
                            }
                        }
                    }
                }
                
            }
                
        }

   

        private Control CreatePicturBox(int picturePos_X, int picturePos_Y, bool isForSort)
        {



            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "playerIcon";
            pictureBox.Size = new Size(90, 90);
            pictureBox.Location = new Point(picturePos_X, picturePos_Y);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;



             pictureBox.Image = Resource.defaultPlayerImg;
            //pictureBox.ImageLocation = @"C:\Users\IgorKvakan\source\repos\WindowsFormsApp\WindowsFormsApp\Images\DefaultImg\defaultPlayerImg.png";


            if (isForSort)
            {

                pictureBox.Click -= Pnl_Click;
            }
            else
                pictureBox.Click += Pnl_Click;




            return pictureBox;
        }



        private Label GetLabel(string txt, Point loaction, LabelName lblName)
        {
            Label lbl = new Label();
            lbl.Name = ((int)lblName).ToString();
            lbl.Text = txt;
            lbl.Location = loaction;
            lbl.Width = 150;
            lbl.Height = 20;
            lbl.Click += Pnl_Click;

            return lbl;

        }

        private void DodajUOmiljeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileToolStripMenuItem.Enabled = true;

            var favoriti = kolekcija.Select(f => f).Where(f => f.Favorite == true).ToList();


            if (lbIgraci.SelectedItems.Count > 3)
            {


                if (FileManager.LoadLanguage()=="hr")
                {
                    MessageBox.Show("Potrebno označiti najviše 3 omiljena igrača !", "Upozorenje!");

                }

                else if (FileManager.LoadLanguage() == "en")
                {
                    MessageBox.Show("You have to select 3 favourite players !", "Attention !");

                }
                
                 return;
            }



            if (favoriti.Count >= 3)
            {
                if (FileManager.LoadLanguage()=="hr")
                {
                    MessageBox.Show("Odabrali ste već 3 omiljena igrača!", "Upozorenje!"); 
                }

                else if (FileManager.LoadLanguage()=="en")
                {
                    MessageBox.Show("You have already selected 3 favourite players", "Attention !");

                }
                
                return;

            }


            var selectedItems = lbIgraci.SelectedItems;

            foreach (var item in selectedItems)
            {
                Repo.SetFavouritePlayers(item.ToString());

            }


            foreach (var item in kolekcija)
            {
                lbIgraci.Items.Remove(item.Name);
            }



            CreatePanel(kolekcija);
        }

        private void DodajIgracaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            var selectedItems = lbIgraci.SelectedItems;

            foreach (var item in selectedItems)
            {
                Repo.SetSviIgraci(item.ToString());

            }

            foreach (var item in kolekcija)
            {
                lbIgraci.Items.Remove(item.Name);
                //sviIgraci.Remove(item);
            }


            CreatePanel(kolekcija);
        }

        private void ContextMenuStripOdabrani_Opened(object sender, EventArgs e)
        {
            if (oznacenaPanela != null)
            {
                oznacenaPanela.BackColor = Color.Transparent;
            }

            oznacenaPanela = (sender as ContextMenuStrip).SourceControl as Panel;
            oznacenaPanela.BackColor = Color.LightBlue;

            SetOznaceniPictureBox(oznacenaPanela);

            SetOznaceniIgrac(oznacenaPanela);

        }

        private void SetOznaceniIgrac(Panel oznacenaPanela)
        {
            foreach (Control ctrl in oznacenaPanela.Controls)
            {
                if (ctrl is Label && ctrl.Name == ((int)LabelName.Name).ToString())
                {
                    oznaceniIgrac = GetPlayerByName(((Label)ctrl).Text);
                    break;
                }
            }
        }

        private Player GetPlayerByName(string name)
        {


            foreach (var item in kolekcija)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new Exception("Nema traženog igrača.");
        }

        private void ToolStripMenuObrisiSve_Click(object sender, EventArgs e)
        {


            foreach (var item in kolekcija)
            {
                lbIgraci.Items.Add(item.Name);

            }


            kolekcija.Clear();

            flpOmiljeniIgraci.Controls.Clear();
        }

        private void ToolStripMenuItemObrisiIgraca_Click(object sender, EventArgs e)
        {


            List<Player> obrisaniIgraci = new List<Player>();

            foreach (var item in kolekcija)
            {
                if (item.Name == oznaceniIgrac.Name)
                {

                    obrisaniIgraci.Add(item);

                }
            }
            foreach (var item in obrisaniIgraci)
            {
                lbIgraci.Items.Add(item.Name);
                kolekcija.Remove(item);

            }


            flpOmiljeniIgraci.Controls.Remove(oznacenaPanela);
            oznacenaPanela = null;

        }

        private void LbIgraci_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                oznaceniListBox = sender as ListBox;

                if (oznaceniListBox.SelectedItem != null)
                {
                    lbIgraci.DoDragDrop(oznaceniListBox.SelectedItem.ToString(), DragDropEffects.Move);

                }

            }

        }
        private void FlpOmiljeniIgraci_DragEnter(object sender, DragEventArgs e)
        {


            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;

        }
        private void FlpOmiljeniIgraci_DragDrop(object sender, DragEventArgs e)
        {

            string name = (string)e.Data.GetData(DataFormats.Text);

            oznaceniListBox.Items.Remove(name);

            Repo.SetSviIgraci(name);
            CreatePanel(kolekcija);
            saveFileToolStripMenuItem.Enabled = true;
        }

        private void PrikaziIgračaToolStripMenuPrikaziIgraca_Click(object sender, EventArgs e)
        {
            prikazi = new PrikaziIgraca();
            prikazi.player = oznaceniIgrac;
            prikazi.pictureBox = odabraniPictureBox;

            if (prikazi.ShowDialog() == DialogResult.OK)
            {

                odabraniPictureBox = prikazi.GetPictureBox();
                SetPictureBox(oznacenaPanela);

            }


        }

        private void SetPictureBox(Panel oznacenaPanela)
        {

            foreach (var ctrl in oznacenaPanela.Controls)
            {
                if (ctrl is PictureBox)
                {
                    PictureBox pb = ctrl as PictureBox;
                    if (pb.Name == "playerIcon")
                    {
                        pb.ImageLocation = odabraniPictureBox.ImageLocation;
                        

                    }
                }

            }

        }


        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Tekstualne datoteke|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {

                foreach (var item in kolekcija)
                {
                    if (!item.Favorite)
                    {
                        if (FileManager.LoadLanguage()=="hr")
                        {
                            MessageBox.Show("Spremaju se samo omiljeni igrači", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
                       else if (FileManager.LoadLanguage() == "en")
                        {
                            MessageBox.Show("You can only save favourite players", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                    else
                    {

                        FileManager.SaveFile(kolekcija, save.FileName);
                    }

                }


            }

        }



        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Tekstualna datoteka|*.txt";
            open.InitialDirectory = open.FileName;


            if (open.ShowDialog() == DialogResult.OK)
            {
                kolekcija.Clear();

                var kolekcijaFileManager = FileManager.OpenFile(open.FileName);
                foreach (var item in kolekcijaFileManager)
                {

                    kolekcija.Add(item);

                }

                lbIgraci.Items.Clear();
                cbReprezentacijie.SelectedItem = null;

                CreatePanel(kolekcija);
                FileManager.ResetList();

            }

        }
        private void SaveLbIgraci()
        {
            var kolekcijaIgraci = new List<string>();
            foreach (var item in lbIgraci.Items)
            {
                kolekcijaIgraci.Add((string)item);
            }

            FileManager.SaveLbIgraci(kolekcijaIgraci);

        }

        private static void SaveFLPIgraci()
        {
            var kolekcijaFlp = new List<Player>();
            foreach (var item in kolekcija)
            {
                kolekcijaFlp.Add(item);
            }
            FileManager.SaveFlpIgraci(kolekcijaFlp);
        }

        private void LoadLbIgraci()
        {
            var kolekcijaLbIgraci = FileManager.LoadLbIgraci();
            if (kolekcijaLbIgraci != null)
            {
                foreach (var item in kolekcijaLbIgraci)
                {

                    lbIgraci.Items.Add(item);
                }
            }

        }

        private void LoadFlpIgraci()
        {
            var listaIgraci = FileManager.LoadFlpIgraci();
            if (listaIgraci!=null)
            {
                foreach (var item in listaIgraci)
                {
                    kolekcija.Add(item);
                }

                CreatePanel(kolekcija); 
            }
        }

        private void LoadCbRep()
        {
            var text = FileManager.LoadCbReprezentacija();

            cbReprezentacijie.SelectedItem = text;


        }

      

        private void SaveFLPPicture()
        {
            List<string> lista = new List<string>();

            

            foreach (Control item in flpOmiljeniIgraci.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control ctrl in item.Controls)
                    {
                        if (ctrl is PictureBox)
                        {
                            PictureBox pb = ctrl as PictureBox;

                            if (pb.Name == "playerIcon")
                            {
                                lista.Add(pb.ImageLocation);

                            } 
                        }
                    }
                }

                
            }

            FileManager.SavePicture(lista);

        }

        private void BtnSortYellowCards_Click(object sender, EventArgs e)
        {
            if (flpOmiljeniIgraci.Controls.Count > 0)
            {
                
                MovePlayerToListBox();

                flpOmiljeniIgraci.Controls.Clear();
            }

            NacinSortiranja(TipSortiranja.SortirajZute);

        }

        

        private void BtnSortdGoalsScored_Click(object sender, EventArgs e)
        {
            if (flpOmiljeniIgraci.Controls.Count > 0)
            {
                
                MovePlayerToListBox();
                flpOmiljeniIgraci.Controls.Clear();

            }

            NacinSortiranja(TipSortiranja.SortirajGolove);
        }

        private void BtnSortedAttendance_Click(object sender, EventArgs e)
        {
            if (flpOmiljeniIgraci.Controls.Count > 0)
            {
                
                MovePlayerToListBox();
                flpOmiljeniIgraci.Controls.Clear();

            }

            NacinSortiranja(TipSortiranja.SortirajPosjetitelje);

        }


        private void MovePlayerToListBox()
        {
            List<Player> lista = new List<Player>();

            foreach (var item in kolekcija)
            {
                lista.Add(item);
            }
            foreach (var item in lista)
            {
                lbIgraci.Items.Add(item.Name);
                kolekcija.Remove(item);
            }
        }

        private void SetTipSortiranjaPrint(TipSortiranja tipSortiranja)
        {
            sortiranjePrint = tipSortiranja;
        }

        private TipSortiranja GetTipSortiranjaPrint()
        {
            return sortiranjePrint;
        }


        private void NacinSortiranja(TipSortiranja odabirSortiranja)
        {
            switch (odabirSortiranja)
            {
                case TipSortiranja.SortirajZute:
                    CreatePanelForSort(odabirSortiranja);
                    SetTipSortiranjaPrint(odabirSortiranja);
                    break;
                case TipSortiranja.SortirajGolove:
                    CreatePanelForSort(odabirSortiranja);
                    SetTipSortiranjaPrint(odabirSortiranja);
                    break;
                case TipSortiranja.SortirajPosjetitelje:
                    CreatePanelForSort(odabirSortiranja);
                    SetTipSortiranjaPrint(odabirSortiranja);
                    break;
            }
        }


        private void CreatePanelForSort(TipSortiranja tipSortiranja)
        {

            List<Player> listaYellowCardsAndGoals = new List<Player>();
            List<MatchFull> listaAttendacneSort = new List<MatchFull>();

            if (tipSortiranja == TipSortiranja.SortirajZute)
            {
                saveFileToolStripMenuItem.Enabled = false;
                listaYellowCardsAndGoals = Repo.LoadListYellowCards();
                CreatePanelForYellowCardsAndGoals(tipSortiranja, listaYellowCardsAndGoals);


            }
            else if (tipSortiranja == TipSortiranja.SortirajGolove)
            {
                saveFileToolStripMenuItem.Enabled = false;
                listaYellowCardsAndGoals = Repo.LoadListGoalsScored();
                CreatePanelForYellowCardsAndGoals(tipSortiranja, listaYellowCardsAndGoals);

            }
            else if (tipSortiranja == TipSortiranja.SortirajPosjetitelje)
            {
                saveFileToolStripMenuItem.Enabled = false;
                listaAttendacneSort = Repo.LoadListAttendance();
                CreatePanelForAttendance(listaAttendacneSort);
                //Repo.ResetListAttendance();
            }


        }

        private void CreatePanelForAttendance(List<MatchFull> listaAttendacneSort)
        {

            foreach (var item in listaAttendacneSort)
            {
                var sirina_panela = flpOmiljeniIgraci.Width - 30;

                Panel pnl = new Panel();
                pnl.Location = new Point(pnl_lokacija_x, pnl_lokacija_y);
                pnl.Size = new Size(sirina_panela, visina_panela);
                pnl.BorderStyle = BorderStyle.None;
                pnl.BackColor = Color.Transparent;
                pnl.Click += Pnl_Click;


                int x = 20;
                int y = 20;


                Point loactionInfo = new Point(x, y);
                Point attendanceInfo = new Point(x, loactionInfo.Y + y);
                Point hometeamInfo = new Point(x, attendanceInfo.Y + y);
                Point awayTeamInfo = new Point(x, hometeamInfo.Y + y);



                if (FileManager.LoadLanguage()=="hr")
                {
                    pnl.Controls.Add(CreateLabelInfo("Stadion:", loactionInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Broj posjetitelja:", attendanceInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Domaćin:", hometeamInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Gost:", awayTeamInfo, false)); 
                }
                else if (FileManager.LoadLanguage() == "en")
                {
                    pnl.Controls.Add(CreateLabelInfo("Stadium:", loactionInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Attendance:", attendanceInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Host:", hometeamInfo, false));
                    pnl.Controls.Add(CreateLabelInfo("Guest:", awayTeamInfo, false));

                }


                int pos_x = 150;
                int pos_y = 20;

                Point loaction = new Point(pos_x, pos_y);
                Point attendance = new Point(pos_x, loaction.Y + pos_y);
                Point hometeam = new Point(pos_x, attendance.Y + pos_y);
                Point awayTeam = new Point(pos_x, hometeam.Y + pos_y);



                pnl.Controls.Add(GetLabel(item.Location, loaction, LabelName.Lokacija));
                pnl.Controls.Add(GetLabel((item.Attendance.ToString()), attendance, LabelName.Posjetitelji));
                pnl.Controls.Add(GetLabel(item.HomeTeamCountry, hometeam, LabelName.Domacin));
                pnl.Controls.Add(GetLabel(item.AwayTeamCountry, awayTeam, LabelName.Gost));

                flpOmiljeniIgraci.Controls.Add(pnl);

            }

        }

        private void CreatePanelForYellowCardsAndGoals(TipSortiranja tipSortiranja, List<Player> listaYellowCardsAndGoals)
        {
            foreach (var item in listaYellowCardsAndGoals)
            {
                var sirina_panela = flpOmiljeniIgraci.Width - 30;

                Panel pnl = new Panel();
                pnl.Location = new Point(pnl_lokacija_x, pnl_lokacija_y);
                pnl.Size = new Size(sirina_panela, visina_panela);
                pnl.BorderStyle = BorderStyle.None;
                pnl.BackColor = Color.Transparent;
                // pnl.Click += Pnl_Click;


                int x = 20;
                int y = 20;


                Point nameLokacijaInfo = new Point(x, y);
                Point drugaLabelaInfo = new Point(x, nameLokacijaInfo.Y + y);


                if (tipSortiranja == TipSortiranja.SortirajZute)
                {

                    if (FileManager.LoadLanguage()=="hr")
                    {
                        pnl.Controls.Add(CreateLabelInfo("Ime igrača:", nameLokacijaInfo, true));
                        pnl.Controls.Add(CreateLabelInfo("Broj zutih kartona:", drugaLabelaInfo, true));

                    }
                  else  if (FileManager.LoadLanguage() == "en")
                    {
                        pnl.Controls.Add(CreateLabelInfo("Player name:", nameLokacijaInfo, true));
                        pnl.Controls.Add(CreateLabelInfo("Yellow cards:", drugaLabelaInfo, true));

                    }

                }


                else if (tipSortiranja == TipSortiranja.SortirajGolove)
                {

                    if (FileManager.LoadLanguage()=="hr")
                    {
                        pnl.Controls.Add(CreateLabelInfo("Ime igrača:", nameLokacijaInfo, true));
                        pnl.Controls.Add(CreateLabelInfo("Broj golova:", drugaLabelaInfo, true)); 
                    }
                   else if (FileManager.LoadLanguage() == "en")
                    {
                        pnl.Controls.Add(CreateLabelInfo("Player name:", nameLokacijaInfo, true));
                        pnl.Controls.Add(CreateLabelInfo("Goals:", drugaLabelaInfo, true));
                    }


                }


                int pos_x = 150;
                int pos_y = 20;

                Point nameLokacija = new Point(pos_x, pos_y);
                Point yellowCards = new Point(pos_x, nameLokacija.Y + pos_y);



                if (tipSortiranja == TipSortiranja.SortirajZute)
                {

                    pnl.Controls.Add(CreateLabelForSort(item.Name, nameLokacija, LabelName.Name));
                    pnl.Controls.Add(CreateLabelForSort((item.NumOfYellowCards.ToString()), yellowCards, LabelName.NumOfYellowCards));

                }
                else if (tipSortiranja == TipSortiranja.SortirajGolove)
                {

                    pnl.Controls.Add(CreateLabelForSort(item.Name, nameLokacija, LabelName.Name));
                    pnl.Controls.Add(CreateLabelForSort((item.GoalsScored > 0 ? item.GoalsScored.ToString() : "Nije zabio gol"), yellowCards, LabelName.GoalsScored));

                }

                var picturePos_X = pos_x + 150;
                var picturePos_Y = pos_y;

                

                pnl.Controls.Add(CreatePicturBox(picturePos_X, picturePos_Y, true));
                

                flpOmiljeniIgraci.Controls.Add(pnl);
            }
        }

        private Label CreateLabelForSort(string txt, Point loaction, LabelName lblName)
        {
            Label lbl = new Label();
            lbl.Name = ((int)lblName).ToString();
            lbl.Text = txt;
            lbl.Location = loaction;
            lbl.Width = 150;
            lbl.Height = 20;


            return lbl;
        }

        private void PostavkeStraniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog.ShowDialog();
        }

        private void OdabirPrinteraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void PregledPrijeIspisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printanoStranica = 0;
            printPreviewDialog.ShowDialog();
        }

       
        private void IspisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printanoStranica =0;
            printDocument.Print();

        }


        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


                TipSortiranja testEnum = GetTipSortiranjaPrint();


            if (printanoStranica == 0 )
            {

                PripremaPrintaZaSort(e,testEnum);
                e.HasMorePages = true;
                printanoStranica++;
            }
            else
            {
                PripremaPrintaZaSortNext(e,testEnum);
            }
            
        }

        private void PripremaPrintaZaSortNext(PrintPageEventArgs e, TipSortiranja tipSortiranja)
        {
            switch (tipSortiranja)
            {
               
                case TipSortiranja.SortirajZute:
                    PrintIgraciZaSortNext(e, tipSortiranja);
                    break;
                case TipSortiranja.SortirajGolove:
                    PrintIgraciZaSortNext(e, tipSortiranja);
                    break;
                case TipSortiranja.SortirajPosjetitelje:
                    PrintIgraciZaSortNext(e, tipSortiranja);
                    break;

            }
        }

        private void PrintIgraciZaSortNext(PrintPageEventArgs e, TipSortiranja tipSortiranja)
        {
            Font f = new Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Pixel);
            int loc_Y = 80;
            int loc_X = 300;

            if (tipSortiranja == TipSortiranja.SortirajZute)
            {
                List<Player> listaIgracaBrojZutih = Repo.LoadListYellowCards();


                foreach (var item in listaIgracaBrojZutih)
                {
                    if (item.NumOfYellowCards == 0)
                    {
                       // e.Graphics.DrawString("Sortiranje igrača prema žutim kartonima:", f, Brushes.Black, new Point(25, 25));


                        e.Graphics.DrawString("Ime igrača:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.Name, f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;


                        e.Graphics.DrawString("Broj žutih kartona:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.NumOfYellowCards.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50; 
                    }
                }
            }

            else if (tipSortiranja == TipSortiranja.SortirajGolove)
            {
                List<Player> listaIgracaBrojGolova = Repo.LoadListGoalsScored();


                foreach (var item in listaIgracaBrojGolova)
                {
                    if (item.GoalsScored==0)
                    {
                        e.Graphics.DrawString("Igrači koji su zabili gol:", f, Brushes.Black, new Point(25, 25));

                        e.Graphics.DrawString("Ime igrača:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.Name, f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;


                        e.Graphics.DrawString("Broj zabijenih golova:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.GoalsScored.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50; 
                    }

                }
            }

            else if (tipSortiranja == TipSortiranja.SortirajPosjetitelje)
            {


                List<MatchFull> listaBrojaPosjetitelja = Repo.LoadListAttendance();



                for (int i = 4; i < listaBrojaPosjetitelja.Count; i++)
                {
                    e.Graphics.DrawString("Sortiraj po broju posjetitelja:", f, Brushes.Black, new Point(25, 25));
                    e.Graphics.DrawString("Stadion:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(listaBrojaPosjetitelja[i].Location, f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50;

                    e.Graphics.DrawString("Broj posjetitelja:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(listaBrojaPosjetitelja[i].Attendance.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50;

                    e.Graphics.DrawString("Domaćin:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(listaBrojaPosjetitelja[i].HomeTeamCountry, f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50;

                    e.Graphics.DrawString("Gost:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(listaBrojaPosjetitelja[i].AwayTeamCountry.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50;

                    e.Graphics.DrawString("-----------------------------------------------------------------------------------------------", f, Brushes.Black, new Point(25, loc_Y));
                    loc_Y += 50; 
                }

                

            }



        }

        private void PripremaPrintaZaSort(PrintPageEventArgs e, TipSortiranja tipSortiranja)
        {
            switch (tipSortiranja)
            {
                case TipSortiranja.SortirajZute:
                    PrintIgraciZaSort(e,tipSortiranja);
                    break;
                case TipSortiranja.SortirajGolove:
                    PrintIgraciZaSort(e, tipSortiranja);                
                    break;
                case TipSortiranja.SortirajPosjetitelje:
                    PrintIgraciZaSort(e,tipSortiranja);
                    break;
              
            }
        }

        

        private void PrintIgraciZaSort(PrintPageEventArgs e, TipSortiranja tipSortiranja)
        {
            Font f = new Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Pixel);
            int loc_Y = 80;
            int loc_X = 300;

            if (tipSortiranja==TipSortiranja.SortirajZute)
            {
                List<Player> listaIgracaBrojZutih = Repo.LoadListYellowCards();


                foreach (var item in listaIgracaBrojZutih)
                {
                    e.Graphics.DrawString("Sortiranje igrača prema žutim kartonima:", f, Brushes.Black, new Point(25, 25));


                    e.Graphics.DrawString("Ime igrača:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(item.Name, f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50;


                    e.Graphics.DrawString("Broj žutih kartona:", f, Brushes.Black, new Point(25, loc_Y));
                    e.Graphics.DrawString(item.NumOfYellowCards.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                    loc_Y += 50; 
                }
            }

           else if (tipSortiranja == TipSortiranja.SortirajGolove)
            {
                List<Player> listaIgracaBrojGolova = Repo.LoadListGoalsScored();


                foreach (var item in listaIgracaBrojGolova)
                {
                    e.Graphics.DrawString("Sortiraj igrače prema broju golova:", f, Brushes.Black, new Point(25, 25));

                        e.Graphics.DrawString("Ime igrača:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.Name, f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;


                        e.Graphics.DrawString("Broj zabijenih golova:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(item.GoalsScored.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;

                }


            }


            else if (tipSortiranja==TipSortiranja.SortirajPosjetitelje)
            {


                List<MatchFull> listaBrojaPosjetitelja = Repo.LoadListAttendance();

                e.Graphics.DrawString("Sortiraj po broju posjetitelja:",f,Brushes.Black,new Point(25,25));




                for (int i = 0; i < listaBrojaPosjetitelja.Count; i++)
                {

                    if (i < 4)
                    {
                        e.Graphics.DrawString("Stadion:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(listaBrojaPosjetitelja[i].Location, f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;

                        e.Graphics.DrawString("Broj posjetitelja:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(listaBrojaPosjetitelja[i].Attendance.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;

                        e.Graphics.DrawString("Domaćin:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(listaBrojaPosjetitelja[i].HomeTeamCountry, f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;

                        e.Graphics.DrawString("Gost:", f, Brushes.Black, new Point(25, loc_Y));
                        e.Graphics.DrawString(listaBrojaPosjetitelja[i].AwayTeamCountry.ToString(), f, Brushes.Black, new Point(loc_X, loc_Y));
                        loc_Y += 50;

                        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------", f, Brushes.Black, new Point(25, loc_Y));
                        loc_Y += 50;
                    }
                   
                    else return;
                }
                       
            }
        }
        


        private void EngleskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaPostavke fp = new FormaPostavke();
            
            if (fp.ShowDialog() == DialogResult.OK)
            {

                FileManager.SaveLanguage("en");

                LanguageHelper.SetCulture(FileManager.LoadLanguage());
                Controls.Clear();
                InitializeComponent();
                this.FormClosing -= MainForm_FormClosing;
                
                
                foreach (var item in matches)
                {
                    cbReprezentacijie.Items.Add(item.Team.GetCountryAndCode());
                }
                
               
            }
           
        }

      

        private void HrvatskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaPostavke fp = new FormaPostavke();
            if (fp.ShowDialog() == DialogResult.OK)
            {

                FileManager.SaveLanguage("hr");
               
                
                LanguageHelper.SetCulture(FileManager.LoadLanguage());
                Controls.Clear();
                InitializeComponent();
                this.FormClosing -= MainForm_FormClosing;

                foreach (var item in matches)
                {
                    cbReprezentacijie.Items.Add(item.Team.GetCountryAndCode());
                }
                
            }
           
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormaZatvaranje fp = new FormaZatvaranje();
            if (fp.ShowDialog() == DialogResult.OK)
            {
                e.Cancel = false;
                
            }
            else
                
                e.Cancel = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            SaveLbIgraci();
            SaveFLPIgraci();
            if (!flpOmiljeniIgraci.Controls.Contains(loadPictureBox))
            {

                SaveFLPPicture();
            }

            var select = (string)cbReprezentacijie.SelectedItem;
            FileManager.SaveCbReprezentacije(select);

        }
    }


}

