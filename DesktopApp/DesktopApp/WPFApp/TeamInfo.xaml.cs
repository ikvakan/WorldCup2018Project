using ClassLibrary.DataAccess;
using ClassLibrary.Model;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for TeamInfo.xaml
    /// </summary>
    /// 


    public partial class TeamInfo : Window
    {

       

        private TeamPartial teamPartial = new TeamPartial();
        public Button button;
        public TeamInfo(string selectedTeam)
        {
            teamPartial = WPFRepo.GetTeamVM(selectedTeam);
            Topmost = true;
            
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = teamPartial;
            CreateWindowAnimation();
        }

        private void CreateWindowAnimation()
        {

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 50;
            doubleAnimation.To = 400;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.5);

            QuarticEase quarticEase= new QuarticEase();
            quarticEase.EasingMode = EasingMode.EaseOut;

            doubleAnimation.EasingFunction = quarticEase;
            
            teamInfoGrid.BeginAnimation(HeightProperty, doubleAnimation);
        }

        private void WindowTeamInfo_Closed(object sender, EventArgs e)
        {
            button.IsEnabled = true;
        }
    }
}
