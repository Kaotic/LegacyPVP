using RiotRtmpDto.Platform.Catalog.Champion;
using RiotRtmpDto.Platform.Game;
using RiotRtmpDto.Platform.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.RtmpsLogic
{
    public class Logic
    {
        /// <summary>
        /// The database of all the champions
        /// </summary>
        //internal static List<champions> Champions;

        internal static ChampionDTO[] PlayerChampions;

        /// <summary>
        /// All enabled game configurations for the user
        /// </summary>
        internal static List<GameTypeConfigDTO> GameConfigs;

        internal static Session PlayerSession;
    }
}
