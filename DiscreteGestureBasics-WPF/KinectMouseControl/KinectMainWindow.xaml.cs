using System.Windows;
using System.Windows.Input;

namespace DiscreteGestureBasicsWPF
{
    public partial class KinectMainWindow : Window
    {
        KinectControl kinectCtrl = new KinectControl();

        public KinectMainWindow()
        {
            InitializeComponent();
        }

        private void MouseSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MouseSensitivity.IsLoaded)
            {
                kinectCtrl.mouseSensitivity = (float)MouseSensitivity.Value;
                txtMouseSensitivity.Text = kinectCtrl.mouseSensitivity.ToString("f2");

                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.MouseSensitivity = kinectCtrl.mouseSensitivity;
                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
            }
        }

        private void PauseToClickTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PauseToClickTime.IsLoaded)
            {
                kinectCtrl.timeRequired = (float)PauseToClickTime.Value;
                txtTimeRequired.Text = kinectCtrl.timeRequired.ToString("f2");

                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.PauseToClickTime = kinectCtrl.timeRequired;
                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
            }
        }

        private void txtMouseSensitivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtMouseSensitivity.Text, out v))
                {
                    MouseSensitivity.Value = v;
                    kinectCtrl.mouseSensitivity = (float)MouseSensitivity.Value;
                }
            }
        }

        private void txtTimeRequired_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtTimeRequired.Text, out v))
                {
                    PauseToClickTime.Value = v;
                    kinectCtrl.timeRequired = (float)PauseToClickTime.Value;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MouseSensitivity.Value = Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.MouseSensitivity;
            PauseToClickTime.Value = Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.PauseToClickTime;
            PauseThresold.Value = Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.PauseThresold;
            chkNoClick.IsChecked = !Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.DoClick;
            CursorSmoothing.Value = Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.CursorSmoothing;
            if (Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.GripGesture)
            {
                rdiGrip.IsChecked = true;
            }
            else
            {
                rdiPause.IsChecked = true;
            }

        }

        private void PauseThresold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PauseThresold.IsLoaded)
            {
                kinectCtrl.pauseThresold = (float)PauseThresold.Value;
                txtPauseThresold.Text = kinectCtrl.pauseThresold.ToString("f2");

                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.PauseThresold = kinectCtrl.pauseThresold;
                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
            }
        }

        private void txtPauseThresold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtPauseThresold.Text, out v))
                {
                    PauseThresold.Value = v;
                    kinectCtrl.timeRequired = (float)PauseThresold.Value;
                }
            }
        }

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            MouseSensitivity.Value = KinectControl.MOUSE_SENSITIVITY;
            PauseToClickTime.Value = KinectControl.TIME_REQUIRED;
            PauseThresold.Value = KinectControl.PAUSE_THRESOLD;
            CursorSmoothing.Value = KinectControl.CURSOR_SMOOTHING;

            chkNoClick.IsChecked = !KinectControl.DO_CLICK;
            rdiGrip.IsChecked = KinectControl.USE_GRIP_GESTURE;
        }

        private void chkNoClick_Checked(object sender, RoutedEventArgs e)
        {
            chkNoClickChange();
        }


        public void chkNoClickChange()
        {
            kinectCtrl.doClick = !chkNoClick.IsChecked.Value;
            Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.DoClick = kinectCtrl.doClick;
            Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
        }

        private void chkNoClick_Unchecked(object sender, RoutedEventArgs e)
        {
            chkNoClickChange();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            kinectCtrl.Close();
        }

        public void rdiGripGestureChange()
        {
            kinectCtrl.useGripGesture = rdiGrip.IsChecked.Value;
            Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.GripGesture = kinectCtrl.useGripGesture;
            Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
        }

        private void rdiGrip_Checked(object sender, RoutedEventArgs e)
        {
            rdiGripGestureChange();
        }

        private void rdiPause_Checked(object sender, RoutedEventArgs e)
        {
            rdiGripGestureChange();
        }

        private void CursorSmoothing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CursorSmoothing.IsLoaded)
            {
                kinectCtrl.cursorSmoothing = (float)CursorSmoothing.Value;
                txtCursorSmoothing.Text = kinectCtrl.cursorSmoothing.ToString("f2");

                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.CursorSmoothing = kinectCtrl.cursorSmoothing;
                Microsoft.Samples.Kinect.GestureBasics.Properties.Settings.Default.Save();
            }
        }


    }


}
