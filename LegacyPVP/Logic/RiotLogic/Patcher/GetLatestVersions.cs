using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RiotLogic.Patcher
{
    public class GetLatestVersions
    {
        /// <summary>
        /// Riots News Gives Me The Lol Version :l
        /// </summary>
        /// <param name="NewsUri"></param>
        /// <returns>Latest Lol Version</returns>
        internal static string GetLatestLolVersion(Uri NewsUri)
        {
            WebClient client = new WebClient();
            string LolNews = client.DownloadString(NewsUri);
            RootObject news = JsonConvert.DeserializeObject<RootObject>(LolNews);
            foreach (News versionData in news.news)
            {
                if (versionData.title.Contains("Patch "))
                {
                    if (versionData.title.Contains(" notes"))
                    {
                        string VerionPre = versionData.title.Replace("Patch ", "");
                        string Version = VerionPre.Replace(" notes", "");
                        return Version + ".14_08_33_13_33";
                    }
                }
            }
            return GetDragon();
        }
        public static string GetDragon()
        {
            string dragonJSON = "";
            using (WebClient client = new WebClient())
            {
                dragonJSON = client.DownloadString("http://ddragon.leagueoflegends.com/realms/na.js");
            }
            dragonJSON = dragonJSON.Replace("Riot.DDragon.m=", "").Replace(";", "");
            Dictionary<string, object> deserializedJSON = JsonConvert.DeserializeObject<Dictionary<string, object>>(dragonJSON);
            string Version = (string)deserializedJSON["v"];
            string CDN = (string)deserializedJSON["cdn"];
            string s = CDN + "/dragontail-" + Version + ".tgz";
            return Version;
        }
    }
}
