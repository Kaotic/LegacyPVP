using LegacyPVP.Elements;
using LegacyPVP.Logic;
using LegacyPVP.Logic.PageLogic;
using LegacyPVP.Overlays;
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

namespace LegacyPVP.Pages
{
    /// <summary>
    /// Interaction logic for SelectAccountPage.xaml
    /// </summary>
    public partial class SelectAccountPage : Page
    {
        public SelectAccountPage()
        {
            InitializeComponent();

            if(Directory.Exists(Path.Combine(Client.ExecutingDirectory, "Login")))
            {
                string[] Directorys = Directory.GetDirectories(Path.Combine(Client.ExecutingDirectory, "Login"));
                foreach(string dir in Directorys)
                {
                    string[] Dir2 = Directory.GetDirectories(Path.Combine(Client.ExecutingDirectory, "Login", dir));
                    foreach(string dir2 in Dir2)
                    {
                        LoginAccount acc = new LoginAccount();
                        acc.Name = dir2;
                        Accounts.Items.Add(acc);
                    }
                }
            }
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccountOverlay Overlay = new AddAccountOverlay();
            PageLogic.DoNormalOverlay(Overlay, new Thickness(0, -2000, 0, 2000));
        }
    }
}
