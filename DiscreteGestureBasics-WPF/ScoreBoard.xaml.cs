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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Page
    {
        List<UserScore> scoreBoard = new List<UserScore>();
        public ScoreBoard()
        {
            InitializeComponent();
            scoreBoard = getUserScores();

            foreach(UserScore us in scoreBoard)
            {
                us.show(ListBox_Score);
            }
        }


        public List<UserScore> getUserScores()
        {
            List<UserScore> list = new List<UserScore>();
            FileInfo[] Files = null;
            DirectoryInfo d = new DirectoryInfo(@"C:\LOTR\Scores");
            Files = d.GetFiles("*.bin");

            foreach (FileInfo f in Files)
            {
                list.Add(new UserScore(f.Name.Split('.').First()));
            }

            return list;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));

        }
    }
}
