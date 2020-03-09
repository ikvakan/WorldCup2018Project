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
    public partial class FormaPostaviJezik : Form
    {
        

        public FormaPostaviJezik()
        {
            InitializeComponent();
        }

        private void BtnHrvatski_Click(object sender, EventArgs e)
        {
            FileManager.SaveLanguage("hr");
            
        }

        private void BtnEngleski_Click(object sender, EventArgs e)
        {
            FileManager.SaveLanguage("en");
           

        }

        
    }
}
