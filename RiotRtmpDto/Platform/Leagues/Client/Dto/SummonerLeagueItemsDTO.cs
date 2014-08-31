using System;
using RtmpSharp.IO;
using System.Collections.Generic;
using RiotRtmpDto.Leagues.Pojo;

namespace RiotRtmpDto.Platform.Leagues.Client.Dto
{
    [Serializable]
    [SerializedName("com.riotgames.platform.leagues.client.dto.SummonerLeagueItemsDTO")]
    public class SummonerLeagueItemsDTO
    {
        [SerializedName("summonerLeagues")]
        public List<LeagueItemDTO> SummonerLeagues { get; set; }
    }
}
