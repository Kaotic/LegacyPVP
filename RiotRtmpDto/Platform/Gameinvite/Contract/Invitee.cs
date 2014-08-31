using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.Invitee")]
    public class Invitee
    {
        [SerializedName("inviteeStateAsString")]
        public String InviteeState { get; set; }

        [SerializedName("summonerName")]
        public String SummonerName { get; set; }

        [SerializedName("inviteeState")]
        public String inviteeState { get; set; }

        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
    }
}
