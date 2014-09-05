using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RiotLogic.Region.Regions
{
    public sealed class OCE : BaseRegion
    {
        public override string RegionName
        {
            get { return "OCE"; }
        }

        public override string InternalName
        {
            get { return "OC1"; }
        }

        public override string ChatName
        {
            get { return "oc1"; }
        }

        public override Uri NewsAddress
        {
            get { return new Uri("http://ll.leagueoflegends.com/landingpage/data/oce/en_AU.js"); }
        }

        public override string Server
        {
            get { return "prod.oc1.lol.riotgames.com"; }
        }

        public override string LoginQueue
        {
            get { return "https://lq.oc1.lol.riotgames.com/"; }
        }

        public override string Locale
        {
            get { return "en_US"; }
        }

        public override IPAddress[] PingAddresses
        {
            get
            {
                return new IPAddress[]
                {
                    //No known IP address
                };
            }
        }

        public override Uri SpectatorLink
        {
            get { return new Uri("http://spectator.oc1.lol.riotgames.com/observer-mode/rest/"); }
        }

        public override string SpectatorIpAddress
        {
            get { return "192.64.169.29"; }
        }
    }
}
