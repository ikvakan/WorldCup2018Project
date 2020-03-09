using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;




namespace WPFApp
{
    /// <summary>
    /// Interaction logic for WindowClosing.xaml
    /// </summary>
    /// 

    public  enum DialogCheck
    {
        Yes,
        No
    }

    public partial class WindowClosing : Window
    {

       public bool isClosing = true;


        public WindowClosing()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        

        private void BtnDA_Click(object sender, RoutedEventArgs e)
        {
            GetDialogAnswer(DialogCheck.Yes);
            Close();
        }

       

        private void BtnNE_Click(object sender, RoutedEventArgs e)
        {
            GetDialogAnswer(DialogCheck.No);
            Close();
        }

        public void GetDialogAnswer(DialogCheck dialogCheck)
        {
           

            switch (dialogCheck)
            {
                case DialogCheck.Yes:
                    isClosing = true;
                    break;
                case DialogCheck.No:
                    isClosing = false;
                    break;
            }

        }

        private void ClosingWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                GetDialogAnswer(DialogCheck.Yes);
                Close();


            }

            else if (e.Key == Key.Escape)
            {
                GetDialogAnswer(DialogCheck.No);
                Close();
            }
        }
    }
}
