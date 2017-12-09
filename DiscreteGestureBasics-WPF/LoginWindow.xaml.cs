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
using DiscreteGestureBasicsWPF;
using System.Windows.Shapes;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Page
    {
        public static DiscreteGestureBasicsWPF.KinectMainWindow kinectMainWindow;
        List<Button> buttons = new List<Button>();
        List<UserScore> Users = new List<UserScore>();
        Boolean useUpperCase = false;
        Boolean useCapsLock = false;

        public LoginWindow()
        {
            InitializeComponent();

            kinectMainWindow = DiscreteGestureBasicsWPF.KinectMainWindow.getInstance();
            
            ScoreBoard scoreboard = new ScoreBoard();
            Users = scoreboard.getUserScores();

            buttons.Add(ö); buttons.Add(ü); buttons.Add(ó);
            buttons.Add(q); buttons.Add(w); buttons.Add(e);
            buttons.Add(r); buttons.Add(t); buttons.Add(z);
            buttons.Add(u); buttons.Add(i); buttons.Add(o);
            buttons.Add(p); buttons.Add(ő); buttons.Add(ú);
            buttons.Add(a); buttons.Add(s); buttons.Add(d);
            buttons.Add(f); buttons.Add(g); buttons.Add(h);
            buttons.Add(j); buttons.Add(k); buttons.Add(l);
            buttons.Add(é); buttons.Add(á); buttons.Add(ű);
            buttons.Add(í); buttons.Add(y); buttons.Add(x);
            buttons.Add(c); buttons.Add(v); buttons.Add(b);
            buttons.Add(n); buttons.Add(m);
            SetKeyBoardToUpperCase();
            useUpperCase = true;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
               UserScore user = new UserScore(Name.Text);
               NavigationService ns = NavigationService.GetNavigationService(this);
               ns.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }

        private void KeyBoard(object sender, RoutedEventArgs e)
        {
            var keyword = (e.Source as Button).Content.ToString();
            Name.Text += keyword;
            if (useCapsLock)
            {
                SetKeyBoardToUpperCase();
            }
            if (useUpperCase)
            {
                SetKeyBoardToLowerCase();
                useUpperCase = false;
            }
        }

        private void SetKeyBoardToUpperCase()
        {
            foreach (var button in buttons)
            {
                var stri = button.Content as string;
                button.Content = stri.ToUpper();
            }
        }

        private void SetKeyBoardToLowerCase()
        {
            foreach (var button in buttons)
            {
                var stri = button.Content as string;
                button.Content = stri.ToLower();
            }
        }

        private void ShiftPress(object sender, RoutedEventArgs e)
        {
            if (useUpperCase || useCapsLock)
            {
                SetKeyBoardToLowerCase();
                useUpperCase = false;
            }
            else
            {
                SetKeyBoardToUpperCase();
                useUpperCase = true;
            }
        }

        private void CapsLockButton(object sender, RoutedEventArgs e)
        {
            if (useCapsLock)
            {
                SetKeyBoardToLowerCase();
                useCapsLock = false;
            }
            else
            {
                SetKeyBoardToUpperCase();
                useCapsLock = true;
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Name.Text = Name.Text.Remove(Name.Text.Length - 1);
        }
    }
}
