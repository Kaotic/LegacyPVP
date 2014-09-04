using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RiotLogic.Region
{
    public class Region
    {
        //NA1
        internal String InternalName { get; set; }

        //prod.na1.lol.riotgames.com
        internal String Host { get; set; }

        //chat.na1.lol.riotgames.com
        internal String XmppServer { get; set; }

        //http://www.leagueoflegends.com/ladders
        internal Uri LadderUrl { get; set; }

        //http://www.leagueoflegends.com/story
        internal Uri StoryPageUrl { get; set; }

        //https://lq.na1.lol.riotgames.com 
        internal Uri LoginQueue { get; set; }

        //na
        internal String RegionTag { get; set; }

        //http://spectator.na.lol.riotgames.com:80/observer-mode/rest/featured
        internal Uri FeaturedGamesUrl { get; set; }

        //NA1
        internal String PlatformId { get; set; }

        //http://ll.leagueoflegends.com/landingpage/data/na/en_US.js
        internal Uri NewsPage { get; set; }
    }
}
