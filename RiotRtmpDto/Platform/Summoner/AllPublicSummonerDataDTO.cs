﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RtmpSharp.IO;
using System.Threading.Tasks;
using RiotRtmpDto.Platform.Summoner.Spellbook;

namespace RiotRtmpDto.Platform.Summoner
{
    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.AllPublicSummonerDataDTO")]
    public class AllPublicSummonerDataDTO
    {
        [SerializedName("spellBook")]
        public SpellBookDTO SpellBook { get; set; }

        [SerializedName("summonerDefaultSpells")]
        public SummonerDefaultSpells SummonerDefaultSpells { get; set; }

        [SerializedName("summonerTalentsAndPoints")]
        public SummonerTalentsAndPoints SummonerTalentsAndPoints { get; set; }

        [SerializedName("summoner")]
        public BasePublicSummonerDTO Summoner { get; set; }

        [SerializedName("summonerLevelAndPoints")]
        public SummonerLevelAndPoints SummonerLevelAndPoints { get; set; }

        [SerializedName("summonerLevel")]
        public SummonerLevel SummonerLevel { get; set; }
    }
}
