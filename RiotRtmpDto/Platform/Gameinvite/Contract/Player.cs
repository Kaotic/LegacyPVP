using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.LobbyStatus")]
    public class Player
    {
        [SerializedName("summonerName")]
        public String SummonerName { get; set; }

        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
    }
}
