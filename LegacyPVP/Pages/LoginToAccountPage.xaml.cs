using LegacyPVP.Logic;
using LegacyPVP.Logic.LegacyPVPLogic;
using LegacyPVP.Logic.PageLogic;
using LegacyPVP.Overlays;
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

namespace LegacyPVP.Pages
{
    /// <summary>
    /// Interaction logic for LoginToAccountPage.xaml
    /// </summary>
    public partial class LoginToAccountPage : Page
    {
        public LoginToAccountPage()
        {
            InitializeComponent(); Username.WaterTextbox.TextChanged += Username_TextChanged;
            Password.WaterTextbox.PasswordChanged += Password_TextChanged;
            HelpButton.Click += HelpButton_Click;
            EnterButton.Visibility = Visibility.Hidden;
            EnterButton.IsEnabled = false;
        }
        public void LoginHandler(object sender, RoutedEventArgs e)
        {
            string User = Username.WaterTextbox.Text;
            string Pass = Password.WaterTextbox.Password;
            byte[] UserHash = Security.Encrypt(System.Text.Encoding.ASCII.GetBytes(User));
            byte[] PassHash = Security.Encrypt(System.Text.Encoding.ASCII.GetBytes(Pass));
            Login.CreateLoginFile(UserHash, System.IO.Path.Combine(Client.ExecutingDirectory, "Login"), "LegacyLoginUser.Temp.Encrypted");
            Login.CreateLoginFile(PassHash, System.IO.Path.Combine(Client.ExecutingDirectory, "Login"), "LegacyLoginPass.Temp.Encrypted");

            string UserFile = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginUser.Encrypted"));
            string PassFile = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginPass.Encrypted"));

            string UserTempFile = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginUser.Temp.Encrypted"));
            string PassTempFile = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginPass.Temp.Encrypted"));
            
            if(UserFile == UserTempFile)
            {
                if(PassFile == PassTempFile)
                {
                    Client.Username = User;
                    Client.Password = Pass;
                    PageLogic.SwichMaserPage<SelectAccountPage>();
                }
                else
                {
                    Username.WaterTextbox.Text = "";
                    Password.WaterTextbox.Password = "";
                    HintLabel.Content = "Your Username or Password Is Incorrect";
                }
            }
            else
            {
                Username.WaterTextbox.Text = "";
                Password.WaterTextbox.Password = "";
                HintLabel.Content = "Your Username or Password Is Incorrect";
            }
            System.IO.File.Delete(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginUser.Temp.Encrypted"));
            System.IO.File.Delete(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", "LegacyLoginPass.Temp.Encrypted"));
        }

        public void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NotifyOverlay Overlay = new NotifyOverlay();
            Overlay.TitleBlock.Text = "Login into your account";
            Overlay.ContentBox.Text = "Login with the credentials you previously supplied";
            PageLogic.DoNormalOverlay(Overlay, new Thickness(1357, 0, -1357, 0));
            Overlay.CloseButton.Click += CloseButton;
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            PageLogic.HideOverlay(new Thickness(2000, 0, -2000, 0));
        }
        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            NotifyOverlay Overlay = new NotifyOverlay();
            Overlay.TitleBlock.Text = "Delete your LegacyPVP Account";
            Overlay.ContentBox.Text = "This will deleate LegacyPVP's Login Files." + Environment.NewLine + 
                "You will have to re-add all of you League Of Legends accounts";
            PageLogic.DoNormalOverlay(Overlay, new Thickness(1357, 0, -1357, 0));
            Overlay.CloseButton.Click += CloseButton;
            Overlay.OkayButton.Click += DeleteAccounts;
            Overlay.OkayButton.Content = "Delete my accounts";
        }
        private void DeleteAccounts(object sender, RoutedEventArgs e)
        {
            System.IO.Directory.Delete(System.IO.Path.Combine(Client.ExecutingDirectory, "Login"), true);
            PageLogic.HideOverlay(new Thickness(2000, 0, -2000, 0));
            PageLogic.SwichMaserPage<CreateAccountPage>();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Username.WaterTextbox.Text.Length != 0)
            {
                if (Password.WaterTextbox.Password.Length != 0)
                {
                    EnterButton.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    EnterButton.Visibility = Visibility.Hidden;
                    EnterButton.IsEnabled = false;
                }
            }
            else
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Username.WaterTextbox.Text.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Password.WaterTextbox.Password.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
        }

        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {
            if (Username.WaterTextbox.Text.Length != 0)
            {
                if (Password.WaterTextbox.Password.Length != 0)
                {
                    EnterButton.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    EnterButton.Visibility = Visibility.Hidden;
                    EnterButton.IsEnabled = false;
                }
            }
            else
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Username.WaterTextbox.Text.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Password.WaterTextbox.Password.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
        }

        
    }
}

