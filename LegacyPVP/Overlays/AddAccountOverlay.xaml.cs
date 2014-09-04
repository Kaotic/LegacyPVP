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
using LegacyPVP.Logic.RiotLogic.Region;
using RiotRtmpDto.Platform.Clientfacade.Domain;
using System.Threading;
using System.Windows.Threading;
using agsXMPP;
using LegacyPVP.Logic.LegacyPVPLogic;
using LegacyPVP.Logic.PageLogic;
using LegacyPVP.Logic.RiotLogic.Patcher;
using RtmpSharp.Messaging;
using System.Windows.Media.Animation;

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
        public async void AddAccount(object sender, RoutedEventArgs e)
        {
            var context = RiotCalls.RegisterObjects();
            Region Regiondata = GetRegionFromTag.GetRegion(this.Region.Region.Tag.ToString());

            Client.RtmpConnection = new RtmpClient(new System.Uri("rtmps://" + Regiondata.Host + ":2099"), context, ObjectEncoding.Amf3);
            await Client.RtmpConnection.ConnectAsync();
            HintLabel1_Copy.Content = Regiondata.Host;
            HintLabel.Visibility = Visibility.Visible;

            AuthenticationCredentials newCredentials = new AuthenticationCredentials();
            newCredentials.Username = LOLUsername.WaterTextbox.Text;
            newCredentials.Password = LOLPassword.WaterTextbox.Password;
            newCredentials.ClientVersion = GetLatestVersions.GetLatestLolVersion(new System.Uri("http://ll.leagueoflegends.com/landingpage/data/na/en_US.js"));

            newCredentials.ClientVersion = "4.15.14";
            HintLabel1.Content = newCredentials.ClientVersion;

            newCredentials.IpAddress = RiotCalls.GetIpAddress();
            //more work later, Live with na local for now
            newCredentials.Locale = "en__US";
            HintLabel2.Content = newCredentials.Locale;
            newCredentials.Domain = "lolclient.lol.riotgames.com";

            try
            {
                newCredentials.AuthToken = RiotCalls.GetAuthKey(LOLUsername.WaterTextbox.Text, LOLPassword.WaterTextbox.Password, Regiondata.LoginQueue.ToString());
                HintLabel2.Content = newCredentials.AuthToken;
            }
            catch (Exception f)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                };

                if (f.Message.Contains("The remote name could not be resolved"))
                    HintLabel.Content = "Please make sure you are connected the internet!";
                else if (f.Message.Contains("(403) Forbidden"))
                    HintLabel.Content = "Your username or password is incorrect!";
                else
                    HintLabel.Content = f.Message;
                Client.RtmpConnection.Close();
            }

            Session login;
            try
            {
                login = await RiotCalls.Login(newCredentials);
                Logic.RtmpsLogic.Logic.PlayerSession = login;
                await Client.RtmpConnection.SubscribeAsync("my-rtmps", "messagingDestination", "bc", "bc-" + login.AccountSummary.AccountId.ToString());
                await Client.RtmpConnection.SubscribeAsync("my-rtmps", "messagingDestination", "gn-" + login.AccountSummary.AccountId.ToString(), "gn-" + login.AccountSummary.AccountId.ToString());
                await Client.RtmpConnection.SubscribeAsync("my-rtmps", "messagingDestination", "cn-" + login.AccountSummary.AccountId.ToString(), "cn-" + login.AccountSummary.AccountId.ToString());
                bool LoggedIn = await Client.RtmpConnection.LoginAsync(LOLUsername.WaterTextbox.Text.ToLower(), login.Token);
                LoginDataPacket packet = await RiotCalls.GetLoginDataPacketForUser();
                string State = await RiotCalls.GetAccountState();

                if (State != "ENABLED")
                {
                    return;
                }
                Login.AddLolAccount(LOLUsername.WaterTextbox.Text, LOLPassword.WaterTextbox.Password, packet.AllSummonerData.Summoner.Name, Regiondata.RegionTag);
                Client.RtmpConnection.Close();
            }
            catch (InvocationException getVersion)
            {
                /*
                object[] array = (object[])((AsObject)getVersion.RootCause)["substitutionArguments"];
                if (array.Length == 2 && (string)array[0] == newCredentials.ClientVersion)
                {
                    newCredentials.ClientVersion = (string)array[1];
                }
                //*/
            }    
            catch (ClientDisconnectedException error)
            {

            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageLogic.HideOverlay(new Thickness(1357, 0, -1357, 0));
        }
    }
}
