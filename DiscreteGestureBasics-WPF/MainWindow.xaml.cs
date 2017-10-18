//---------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <Description>
// This program tracks up to 6 people simultaneously.
// If a person is tracked, the associated gesture detector will determine if that person is seated or not.
// If any of the 6 positions are not in use, the corresponding gesture detector(s) will be paused
// and the 'Not Tracked' image will be displayed in the UI.
// </Description>
//----------------------------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Kinect;
    using Microsoft.Kinect.VisualGestureBuilder;

    /// <summary>
    /// Interaction logic for the MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        void OnTimed(object sender, EventArgs e)
        {

        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            
        }
    }
}
