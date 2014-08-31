using System;
using RtmpSharp.IO;
using System.Collections.Generic;
using RiotRtmpDto.Leagues.Pojo;

namespace RiotRtmpDto.Platform.Leagues.Client.Dto
{
    [Serializable]
    [SerializedName("com.riotgames.platform.leagues.client.dto.SummonerLeaguesDTO")]
    public class SummonerLeaguesDTO
    {
        [SerializedName("summonerLeagues")]
        public List<RiotRtmpDto.Leagues.Pojo.LeagueListDTO> SummonerLeagues { get; set; }
    }
}
