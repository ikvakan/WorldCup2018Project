using ClassLibrary.DataAccess;
using ClassLibrary.ModelFull;
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
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        private PlayerFull playerInfo = new PlayerFull();

        public PlayerInfo(PlayerFull player)
        {
            playerInfo = player; 
            Topmost = true;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = playerInfo;
            CreateWindowAnimation();
        }

        private void CreateWindowAnimation()
        {

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double windowWidth = Width;

            var center =(screenWidth /2) - (windowWidth/2);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To =center;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.3);

            doubleAnimation.EasingFunction = new QuarticEase();

            this.BeginAnimation(LeftProperty, doubleAnimation);
        }
    }
}
