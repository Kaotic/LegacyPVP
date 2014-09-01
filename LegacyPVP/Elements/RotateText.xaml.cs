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

namespace LegacyPVP.Elements
{
    /// <summary>
    /// Interaction logic for RotateText.xaml
    /// </summary>
    public partial class RotateText : UserControl
    {
        public RotateText()
        {
            InitializeComponent();
            Region.Tag = "NA";
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if(Region.Tag == "BR")
            {
                Region.Tag = "LAN";
                RegionLeft.Content = "Turkey (TR)";
                RegionRight.Content = Region.Content;
                Region.Content = "Latin America North (LAN)";
            }
            else if (Region.Tag == "EUN")
            {
                Region.Tag = "BR";
                RegionRight.Content = Region.Content;
                RegionLeft.Content = "Latin America North (LAN)";
                Region.Content = "Brazil (BR)";
            }
            else if (Region.Tag == "EUW")
            {
                Region.Tag = "EUN";
                RegionRight.Content = Region.Content;
                RegionLeft.Content = "Brazil (BR)";
                Region.Content = "European Union North (EUN)";
            }
            else if (Region.Tag == "KR")
            {
                Region.Tag = "EUW";
                RegionLeft.Content = "European Union North (EUN)";
                RegionRight.Content = Region.Content;
                Region.Content = "European Union West (EUW)";
            }
            else if (Region.Tag == "NA")
            {
                Region.Tag = "KR";
                RegionLeft.Content = "European Union West (EUW)";
                RegionRight.Content = Region.Content;
                Region.Content = "Korea (KR)";
            }
            else if (Region.Tag == "OCE")
            {
                Region.Tag = "NA";
                RegionLeft.Content = "Korea (KR)";
                RegionRight.Content = Region.Content;
                Region.Content = "North America (NA)";
            }
            else if (Region.Tag == "RU")
            {
                Region.Tag = "OCE";
                RegionLeft.Content = "North America (NA)";
                RegionRight.Content = Region.Content;
                Region.Content = "Oceania (OCE)";
            }
            else if (Region.Tag == "TR")
            {
                Region.Tag = "RU";
                RegionLeft.Content = "Oceania (OCE)";
                RegionRight.Content = Region.Content;
                Region.Content = "Russia (RU)";
            }
            else if (Region.Tag == "LAN")
            {
                Region.Tag = "TR";
                RegionLeft.Content = "Russia (RU)";
                RegionRight.Content = Region.Content;
                Region.Content = "Turkey (TR)";
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (Region.Tag == "BR")
            {
                Region.Tag = "EUN";
                RegionLeft.Content = Region.Content;
                RegionRight.Content = "European Union West (EUW)";
                Region.Content = "European Union North (EUN)";
            }
            else if (Region.Tag == "EUN")
            {
                Region.Tag = "EUW";
                RegionLeft.Content = Region.Content;
                Region.Content = "European Union West (EUW)";
                RegionRight.Content = "Korea (KR)";
            }
            else if (Region.Tag == "EUW")
            {
                Region.Tag = "KR";
                RegionLeft.Content = Region.Content;
                Region.Content = "Korea (KR)";
                RegionRight.Content = "North America (NA)";
            }
            else if (Region.Tag == "KR")
            {
                Region.Tag = "NA";
                RegionLeft.Content = Region.Content;
                RegionRight.Content = "Oceania (OCE)";
                Region.Content = "North America (NA)";
            }
            else if (Region.Tag == "NA")
            {
                Region.Tag = "OCE";
                RegionLeft.Content = Region.Content;
                RegionRight.Content = "Russia (RU)";
                Region.Content = "Oceania (OCE)";
            }
            else if (Region.Tag == "OCE")
            {
                Region.Tag = "RU";
                RegionLeft.Content = Region.Content;
                Region.Content = "Russia (RU)";
                RegionRight.Content = "Turkey (TR)";
            }
            else if (Region.Tag == "RU")
            {
                Region.Tag = "TR";
                RegionLeft.Content = Region.Content;
                Region.Content = "Turkey (TR)";
                RegionRight.Content = "Latin America North (LAN)";
            }
            else if (Region.Tag == "TR")
            {
                Region.Tag = "LAN";
                RegionLeft.Content = Region.Content;
                Region.Content = "Latin America North (LAN)";
                RegionRight.Content = "Brazil (BR)";
            }
            else if (Region.Tag == "LAN")
            {
                Region.Tag = "BR";
                RegionLeft.Content = Region.Content;
                Region.Content = "Brazil (BR)";
                RegionRight.Content = "European Union North (EUN)";
            }
        }
        private String GetRegion()
        {
            return Region.Tag.ToString();
        }
    }
}
