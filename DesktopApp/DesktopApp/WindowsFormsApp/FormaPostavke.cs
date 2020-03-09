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
    public partial class FormaPostavke : Form
    {

       

        public FormaPostavke()
        {
            LanguageHelper.SetCulture(FileManager.LoadLanguage());
            Controls.Clear();
            InitializeComponent();
            AcceptButton = btnPostavkeHDA;
            CancelButton = btnPostavkeHNE;
        }

        
    }
}
