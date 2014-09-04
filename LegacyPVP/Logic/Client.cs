using LegacyPVP.Logic.LegacyPVPLogic;
using RiotRtmpDto.Platform.Clientfacade.Domain;
using RtmpSharp.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LegacyPVP.Logic
{
    /// <summary>
    /// Only super inportant stuff goes here
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Where LegacyPVP is Located
        /// </summary>
        internal static String ExecutingDirectory;

        /// <summary>
        /// LegacyPVP Password
        /// </summary>
        internal static String Username;

        /// <summary>
        /// LegacyPVP Password
        /// </summary>
        internal static String Password;

        /// <summary>
        /// Main Connection to current logged in account
        /// </summary>
        internal static RtmpClient RtmpConnection;

        /// <summary>
        /// Allows users to connect to multiple accounts VIA RTMPS
        /// </summary>
        internal static List<RtmpClient> AlternateAccounts;

        /// <summary>
        /// Latest Version
        /// </summary>
        internal static String Version;

        /// <summary>
        /// List of latest LegacyPVP Download
        /// </summary>
        internal static List<Download> DownloadList;

        /// <summary>
        /// Normal
        /// </summary>
        internal static Uri LLPVPVersion;

        /// <summary>
        /// Beta
        /// </summary>
        internal static Uri LBLPVPVersion;

        /// <summary>
        /// PreRelease
        /// </summary>
        internal static Uri LPRLPVPVersion;

        /// <summary>
        /// Normal IMPORTANT
        /// </summary>
        internal static Uri LLPVPIVersion;

        /// <summary>
        /// Beta IMPORTANT
        /// </summary>
        internal static Uri LBLPVPIVersion;

        /// <summary>
        /// PreRelease IMPORTANT
        /// </summary>
        internal static Uri LPRLPVPIVersion;

        /// <summary>
        /// Packet recieved when initially logged on. Cached so the packet doesn't
        /// need to requested multiple times, causing slowdowns
        /// </summary>
        internal static LoginDataPacket LoginPacket;

        public static BitmapImage GetImage(string Address)
        {
            Uri UriSource = new Uri(Address, UriKind.RelativeOrAbsolute);            
            if (!File.Exists(Address) && !Address.StartsWith("/LegacyPVP;component"))
            {
                Log("Cannot find " + Address, "WARN");
                UriSource = new Uri("/LegacyPVP;component/NONE.png", UriKind.RelativeOrAbsolute);
            }
            return new BitmapImage(UriSource);
        }

        public static void Log(String lines, String type = "LOG")
        {

        }

        public static bool IsLoggedIn = false;
    }
}
