using ClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            Settings settings = new Settings();

            if (!File.Exists(FileManager.PATH_LANGUAGE) )
            {
               
                settings.Show();


            }
                else
                   window.Show();

        }


      
        
    }
}
