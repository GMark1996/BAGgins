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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Page
    {
        List<UserScore> Users = new List<UserScore>();

        public LoginWindow()
        {
            InitializeComponent();

            ScoreBoard scoreboard = new ScoreBoard();
            Users = scoreboard.getUserScores();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            UserScore user = new UserScore(Name.Text);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));

        }
    }
}
