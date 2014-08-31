using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Statistics.Team
{
    [Serializable]
    [SerializedName("com.riotgames.platform.statistics.team.TeamPlayerAggregatedStatsDTO")]
    public class TeamPlayerAggregatedStatsDTO
    {
        [SerializedName("playerId")]
        public Double PlayerId { get; set; }

        [SerializedName("aggregatedStats")]
        public AggregatedStats AggregatedStats { get; set; }
    }
}