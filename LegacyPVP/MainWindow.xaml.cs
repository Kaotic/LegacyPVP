using LegacyPVP.Logic;
using LegacyPVP.Logic.LegacyPVPLogic;
using LegacyPVP.Logic.PageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace LegacyPVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageLogic.MainGrid = MainContent;
            PageLogic.OverlayGrid = OverlayContent;
            PageLogic.Win = this;
            Client.ExecutingDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Login.GetPreviousAccounts();
        }
    }
}
