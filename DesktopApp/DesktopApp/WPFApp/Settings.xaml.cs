using ClassLibrary.DataAccess;
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
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public WindowState winState;
        private string language;

        public Settings()
        {

            Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            
        }

       
        private void BtnPrikazWindow_Click(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();
            btn = sender as Button;
            btn.Background = Brushes.Blue;
            btn.Foreground = Brushes.White;

            btnPrikazFullScreen.Background = Brushes.Transparent;
            btnPrikazFullScreen.Foreground = Brushes.Black;

           

            //window
            var prikaz = (string)btn.Tag;
            FileManager.SaveWindowStateWPF(prikaz);


        }

        private void BtnPrikazFullScreen_Click(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();
            btn = sender as Button;
            btn.Background = Brushes.Blue;
            btn.Foreground = Brushes.White;
           
            btnPrikazWindow.Background = Brushes.Transparent;
            btnPrikazWindow.Foreground = Brushes.Black;

            


            //fullscreen
            var prikaz = (string)btn.Tag;
            FileManager.SaveWindowStateWPF(prikaz);

        }


        private void BtnLanguageHr_Click(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();
            btn = sender as Button;
            btn.Background = Brushes.Blue;
            btn.Foreground = Brushes.White;

            btnLanguageEn.Background = Brushes.Transparent;
            btnLanguageEn.Foreground = Brushes.Black;

            //FileManager.SaveLanguage("hr");
            language = "hr";
           
        }

        private void BtnLanguageEn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();
            btn = sender as Button;
            btn.Background = Brushes.Blue;
            btn.Foreground = Brushes.White;


            btnLanguageHr.Background = Brushes.Transparent;
            btnLanguageHr.Foreground = Brushes.Black;

            language = "en";
            
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindowState();

            if (!(File.Exists(FileManager.PATH_LANGUAGE)))
            {
                ChangeLanguage(language);
                MainWindow m = new MainWindow();
                m.Show();
            }
            else
                ChangeLanguage(language);
            
           
        }

        private void ChangeLanguage(string language)
        {
            FileManager.SaveLanguage(language);

        }

        private void BtnOdistani_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        

        private void ChangeWindowState()
        {


            if (FileManager.LoadWindowState() == "fullscreen")
            {
                winState = WindowState.Maximized;
            }
            else
                winState = WindowState.Normal;
            

            Close();
        }





        private void SettingsWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                ChangeWindowState();
                

            }

            else if (e.Key == Key.Escape)
            {
                Close();
            }
           
        }



    }
}
