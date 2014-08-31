using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.Inviter")]
    public class Inviter
    {
        [SerializedName("previousSeasonHighestTier")]
        public String PreviousSeasonHighestTier { get; set; }

        [SerializedName("summonerName")]
        public String SummonerName { get; set; }

        [SerializedName("summonerId")]
        public Int32 SummonerId { get; set; }
    }
}
