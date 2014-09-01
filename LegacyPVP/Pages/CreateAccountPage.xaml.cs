using LegacyPVP.Logic;
using LegacyPVP.Logic.LegacyPVPLogic;
using LegacyPVP.Logic.PageLogic;
using LegacyPVP.Overlays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for CreateAccountPage.xaml
    /// </summary>
    public partial class CreateAccountPage : Page
    {
        public CreateAccountPage()
        {
            InitializeComponent();
            Username.WaterTextbox.TextChanged += Username_TextChanged;
            Password.WaterTextbox.PasswordChanged += Password_TextChanged;
            HelpButton.Click += HelpButton_Click;
            EnterButton.Visibility = Visibility.Hidden;
            EnterButton.IsEnabled = false;
        }
        public void LoginHandler(object sender, RoutedEventArgs e)
        {
            //This secures the account intead of creating a plain text file
            //This will create a file such as ‘.È²ÎIä¥AIZµp if the imput was asdf
            string User = Username.WaterTextbox.Text;
            string Pass = Password.WaterTextbox.Password;
            byte[] UserHash = Security.Encrypt(System.Text.Encoding.ASCII.GetBytes(User));
            byte[] PassHash = Security.Encrypt(System.Text.Encoding.ASCII.GetBytes(Pass));
            Login.CreateLoginFile(UserHash, System.IO.Path.Combine(Client.ExecutingDirectory, "Login"), "LegacyLoginUser.Encrypted");
            Login.CreateLoginFile(PassHash, System.IO.Path.Combine(Client.ExecutingDirectory, "Login"), "LegacyLoginPass.Encrypted");
            Client.Username = User;
            Client.Password = Pass;
            PageLogic.SwichMaserPage<SelectAccountPage>();
        }

        public void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NotifyOverlay Overlay = new NotifyOverlay();
            Overlay.TitleBlock.Text = "Creating an account";
            Overlay.ContentBox.Text = "When you create an account you should:" + Environment.NewLine + Environment.NewLine +
                "1. Not have the same cridentials as you lol login" + Environment.NewLine +
                "2. Make sure that All .Encrypted Files are not readable, to ensure account security.";
            PageLogic.DoNormalOverlay(Overlay, new Thickness(1357, 0, -1357, 0));
            Overlay.OkayButton.Click += OkayButton;
            Overlay.CloseButton.Click += OkayButton;
        }
        private void OkayButton(object sender, RoutedEventArgs e)
        {
            PageLogic.HideOverlay(new Thickness(2000, 0, -2000, 0));
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
