using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.Member")]
    public class Member
    {
        [SerializedName("hasDelegatedInvitePower")]
        public bool hasDelegatedInvitePower { get; set; }

        [SerializedName("summonerName")]
        public String SummonerName { get; set; }

        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
    }
}
