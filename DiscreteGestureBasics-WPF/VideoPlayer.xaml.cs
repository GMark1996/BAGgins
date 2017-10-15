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

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class VideoPlayer : Window
    {
        FileInfo[] Files = null;
        //string recognisedMovement = "edsh";
        public VideoPlayer()
        {
            InitializeComponent();
            DirectoryInfo d = new DirectoryInfo(@"C:\LOTR");
            Files = d.GetFiles("*.mp4");

            //playVideo(recognisedMovement);
        }

        public void playVideo(String movement)
        {
            foreach (FileInfo f in Files)
            {
                if (f.Name.Split('.').First() == movement)
                    VideoControl.Source = new Uri(f.FullName);
            }
        }
    }
}
