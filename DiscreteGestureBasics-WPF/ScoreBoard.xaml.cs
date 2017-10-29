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
using System.Windows.Markup;
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
            Dictionary<string, Dictionary<string, float>> topScores = new Dictionary<string, Dictionary<string, float>>();

            foreach (UserScore us in scoreBoard)
            {
                foreach(KeyValuePair<string,float> pair in us.getGestures())
                {
                    if (topScores.ContainsKey(pair.Key))
                    {
                        topScores[pair.Key].Add(us.Name, pair.Value);
                    }
                    else
                    {
                        topScores.Add(pair.Key, new Dictionary<string, float>() { { us.Name, pair.Value } });
                    }
                }         
            }


            foreach(KeyValuePair<string,Dictionary<string,float>> gestureScores in topScores)
            {
                int counter = 0;
                Expander expander = new Expander();
                StackPanel newstackPanel = new StackPanel();
                expander.Header = gestureScores.Key;

                foreach (KeyValuePair<string,float> scores in gestureScores.Value.OrderByDescending(x => x.Value))
                {
                    

                    ListBox listBox = new ListBox();
                    listBox.ItemsPanel = (ItemsPanelTemplate)XamlReader.Parse("<ItemsPanelTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><StackPanel Orientation=\"Horizontal\"/></ItemsPanelTemplate>");
                    listBox.IsEnabled = false;

                    
                    listBox.Items.Add(new ListBoxItem() { HorizontalAlignment = HorizontalAlignment.Left, Content = "Player: " + scores.Key });                  
                    listBox.Items.Add(new ListBoxItem() { HorizontalAlignment = HorizontalAlignment.Right, Content = "Score: " + scores.Value });

                    newstackPanel.Children.Add(listBox);
                    
                    if (++counter == 10)
                        break;
                }
                expander.Content = newstackPanel;
                ListBox_Score.Items.Add(expander);

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
