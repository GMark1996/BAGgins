﻿using System;
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
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    /// <summary>
    /// Interaction logic for Gestures.xaml
    /// </summary>
    /// 

    public partial class GestureMenu : Page
    {
        KinectRecognise knr = null;
        private KinectSensor kinectSensor = null;
        private BodyFrameReader bodyFrameReader = null;

        ListBox lb = new ListBox();
        public GestureMenu()
        {
            InitializeComponent();

            this.kinectSensor = KinectSensor.GetDefault();

            // open the sensor
            this.kinectSensor.Open();

  
            // open the reader for the body frames
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();

            DirectoryInfo d = new DirectoryInfo(@"C:\LOTR\GIF");
            FileInfo[] Files = d.GetFiles("*.gif");


            foreach(FileInfo f in Files)
            {
                MediaElement melem = new MediaElement();

                melem.MediaEnded += new RoutedEventHandler(gif_MediaEnded);
                melem.Source = new Uri(f.FullName);
                melem.Name = f.Name.Split('.')[0];
                melem.UnloadedBehavior = MediaState.Manual;

                melem.MouseLeftButtonDown += new MouseButtonEventHandler(openGesture);
                melem.Height = 200;

                ListBoxItem item = new ListBoxItem();
                item.HorizontalAlignment = HorizontalAlignment.Center;
                item.Content = melem;           
                lb.Items.Add(item);               
            }
            lb.HorizontalAlignment = HorizontalAlignment.Center;
            gestureGifs.Children.Add(lb);
        }


        private void gif_MediaEnded(object sender, RoutedEventArgs e)
        {
            
            ((MediaElement)sender).Position = new TimeSpan(0, 0, 1);
            ((MediaElement)sender).Play();
        }

        private void openGesture(object sender, RoutedEventArgs e)
        {
            MediaElement litem = ((MediaElement)sender);
            Console.Out.WriteLine(litem.Name);
            Console.Out.WriteLine("FUUUUUUUUUUUUUUUUUUUUCK");
            knr = new KinectRecognise();

            knr.addDetector(@"Database\"+ litem.Name +".gbd", litem.Name);
            
           


            lb.Visibility = Visibility.Hidden;
            MediaElement mediaElement = new MediaElement();
            mediaElement.UnloadedBehavior = MediaState.Manual;
            mediaElement.MediaEnded += new RoutedEventHandler(gif_MediaEnded);           
            mediaElement.MouseDown += new MouseButtonEventHandler(closeGesture);
            mediaElement.Source = litem.Source;
            
            gestureGifs.Children.Add(mediaElement);
        }

        private void closeGesture(object sender,RoutedEventArgs e)
        {
            gestureGifs.Children.Remove((MediaElement)sender);
            lb.Visibility = Visibility.Visible;
        }


    }
}
