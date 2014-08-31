using System;
using RtmpSharp.IO;
using System.Collections.Generic;
using RiotRtmpDto.Platform.Catalog.Icon;

namespace RiotRtmpDto.Platform.Summoner.Icon
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.icon.SummonerIconInventoryDTO")]
    public class SummonerIconInventoryDTO
    {
        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }

        [SerializedName("summonerIcons")]
        public List<RiotRtmpDto.Platform.Catalog.Icon.Icon> SummonerIcons { get; set; }
    }
}