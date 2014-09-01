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
using LegacyPVP.Logic;
using LegacyPVP.RtmpsLogic;
using RiotRtmpDto.Platform.Login;
using RtmpSharp.IO;
using RtmpSharp.Net;

namespace LegacyPVP.Overlays
{
    /// <summary>
    /// Interaction logic for AddAccountOverlay_.xaml
    /// </summary>
    public partial class AddAccountOverlay : Page
    {
        public AddAccountOverlay()
        {
            InitializeComponent();
        }
        public void AddAccount(object sender, RoutedEventArgs e)
        {
            AuthenticationCredentials newCredentials = new AuthenticationCredentials();
            var context = RiotCalls.RegisterObjects();
            Client.RtmpConnection = new RtmpClient(new Uri("rtmps://" + ""/*SelectedRegion.Server*/ + ":2099"), context, ObjectEncoding.Amf3);
            HintLabel.Visibility = Visibility.Visible;
        }
        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LOLUsername.WaterTextbox.Text.Length != 0)
            {
                if (LOLPassword.WaterTextbox.Password.Length != 0)
                {
                    HintLabel.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    HintLabel.Visibility = Visibility.Hidden;
                    HintLabel.IsEnabled = false;
                }
            }
            else
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
            if (LOLUsername.WaterTextbox.Text.Length == 0)
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
            if (LOLPassword.WaterTextbox.Password.Length == 0)
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
        }

        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {
            if (LOLUsername.WaterTextbox.Text.Length != 0)
            {
                if (LOLPassword.WaterTextbox.Password.Length != 0)
                {
                    HintLabel.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    HintLabel.Visibility = Visibility.Hidden;
                    HintLabel.IsEnabled = false;
                }
            }
            else
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
            if (LOLUsername.WaterTextbox.Text.Length == 0)
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
            if (LOLPassword.WaterTextbox.Password.Length == 0)
            {
                HintLabel.Visibility = Visibility.Hidden;
                HintLabel.IsEnabled = false;
            }
        }
    }
}
