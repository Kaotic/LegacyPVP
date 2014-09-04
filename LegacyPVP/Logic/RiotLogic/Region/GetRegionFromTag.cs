using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RiotLogic.Region
{
    public class GetRegionFromTag
    {
        public static Region GetRegion(string regionTag, bool Garnea = false)
        {
            Region region = new Region();
            if (!Garnea)
            {
                region.RegionTag = regionTag;
                int RegionId = GetRegionId(regionTag);
                if (RegionId != 0)
                {
                    region.PlatformId = regionTag + RegionId;
                }
                else if (RegionId == 1)
                {
                    region.PlatformId = regionTag;
                }
                else if (RegionId == 2)
                {

                }
                region.LadderUrl = new Uri("http://www.leagueoflegends.com/ladders");
                region.XmppServer = "chat." + region.PlatformId.ToLower() + ".lol.riotgames.com";
                region.Host = "prod." + region.PlatformId.ToLower() + ".lol.riotgames.com";
                region.LoginQueue = new Uri("https://lq." + region.PlatformId.ToLower() + ".lol.riotgames.com ");
                region.FeaturedGamesUrl = new Uri("http://spectator." + regionTag.ToLower() + ".lol.riotgames.com:80/observer-mode/rest/");
                region.NewsPage = new Uri("http://ll.leagueoflegends.com/landingpage/data/na/en_US.js");
            }
            else if (Garnea)
            {

            }
            return region;
        }
        public static Int32 GetRegionId(string RegionId)
        {
            if (RegionId == "NA")
                return 1;
            else if (RegionId == "BR")
                return 1;
            else if (RegionId == "EUN")
                return 1;
            else if (RegionId == "EUW")
                return 1;
            else if (RegionId == "KR")
                return 0;
            else if (RegionId == "OCE")
                return 1;
            else if (RegionId == "RU")
                return 0;
            else if (RegionId == "TR")
                return 2;
            return 1;
        }
    }
}
