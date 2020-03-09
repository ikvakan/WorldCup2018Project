using ClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormaZatvaranje : Form
    {
        public FormaZatvaranje()
        {
            LanguageHelper.SetCulture(FileManager.LoadLanguage());
            Controls.Clear();
            InitializeComponent();
        }
    }
}
