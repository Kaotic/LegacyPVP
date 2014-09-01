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
    /// Interaction logic for SelectAccountPage.xaml
    /// </summary>
    public partial class SelectAccountPage : Page
    {
        public SelectAccountPage()
        {
            InitializeComponent();
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccountOverlay Overlay = new AddAccountOverlay();
            PageLogic.DoNormalOverlay(Overlay, new Thickness(0, -2000, 0, 2000));
        }
    }
}
