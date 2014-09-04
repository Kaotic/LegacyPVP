using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.LegacyPVPLogic
{
    public class LegacyPatch
    {
        public static Int32 GetLatestChamp()
        {
            WebClient client = new WebClient();
            string LatestChamp = client.DownloadString(new Uri("http://eddy5641.github.io/LegacyPVP/LatestChamp"));
            return Convert.ToInt32(LatestChamp);
        }
        /// <summary>
        /// Sets the Latest LegendaryClient Version
        /// </summary>
        public static void CheckForUpdates()
        {
            WebClient client = new WebClient();
            string LatestUpdateData = client.DownloadString(new Uri("http://eddy5641.github.io/LegacyPVP/LatestVersion.json"));
            Update Updatedata = JsonConvert.DeserializeObject<Update>(LatestUpdateData);
            Client.DownloadList = Updatedata.downloads;
            foreach (Download Data in Updatedata.downloads)
            {
                if (Data.IsLatestPatch)
                {
                    if (Data.IsPre)
                    {
                        //Required patch for people using a pre-release, if there is a bug
                        if(Data.IsImportantPatch)
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LPRLPVPIVersion = Uri;
                        }
                        else
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LPRLPVPVersion = Uri;
                        }
                    }
                    else if (Data.IsBeta)
                    {
                        //Required patch for people using a beta, if there is a bug
                        if (Data.IsImportantPatch)
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LBLPVPIVersion = Uri;
                        }
                        else
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LBLPVPVersion = Uri;
                        }
                    }
                    else
                    {
                        //Required patch, adds enhansments
                        if (Data.IsImportantPatch)
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LBLPVPIVersion = Uri;
                        }
                        else
                        {
                            Uri Uri = new Uri(Data.DownloadLink);
                            Client.LBLPVPVersion = Uri;
                        }
                    }
                }
            }
        }
        //Put next code here
    }
}
