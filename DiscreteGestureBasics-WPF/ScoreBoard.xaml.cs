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
            FileInfo[] Files = null;

            InitializeComponent();
            DirectoryInfo d = new DirectoryInfo(@"C:\LOTR\Scores");
            Files = d.GetFiles("*.bin");

            foreach(FileInfo f in Files)
            {
                scoreBoard.Add(new UserScore(f.Name.Split('.').First()));
            }

            foreach(UserScore us in scoreBoard)
            {
                us.show(ListBox_Score);
            }
        }
    }
}
