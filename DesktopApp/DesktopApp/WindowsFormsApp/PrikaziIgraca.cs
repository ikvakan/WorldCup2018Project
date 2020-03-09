using ClassLibrary;
using ClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp
{
    public partial class PrikaziIgraca : Form
    {
        public Player player;

        public PictureBox pictureBox;

        

        public PrikaziIgraca()
        {
            LanguageHelper.SetCulture(FileManager.LoadLanguage());
            Controls.Clear();
            InitializeComponent();

        }


        public void Prikazi()
        {
            lblImeIgraca.Text = player.Name;
            lblPozicija.Text = player.Position;
            lblBrojDresa.Text = player.ShirtNumber.ToString();
            lblKapetan.Text = player.Captain ? "Kapetan" : "---";
            pictureBoxFavourite.Image = player.Favorite ? Resource.StarIcon : null;
            pictureBoxIgrac.ImageLocation =pictureBox.ImageLocation;
            pictureBoxIgrac.Image = pictureBox.Image;
        }

        private void PrikaziIgraca_Load(object sender, EventArgs e)
        {
            Prikazi();

        }

        private void BtnUrediSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.InitialDirectory = @"C:\Users\IgorKvakan\source\repos\WindowsFormsApp\WindowsFormsApp\Images\PlayerIcon";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                pictureBoxIgrac.Image = Image.FromFile(ofd.FileName);
                pictureBoxIgrac.ImageLocation = ofd.FileName;
                
               
            }



        }



        public PictureBox GetPictureBox()
        {
            pictureBox = pictureBoxIgrac;
            return pictureBox;
        }

    }
}
