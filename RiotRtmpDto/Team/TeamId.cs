using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Team
{
    [Serializable]
    [SerializedName("com.riotgames.team.TeamId")]
    public class TeamId
    {
        [SerializedName("broadcastMessages")]
        public object[] BroadcastMessages { get; set; }
    }
}