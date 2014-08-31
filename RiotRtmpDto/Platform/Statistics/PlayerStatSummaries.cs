using System;
using RtmpSharp.IO;
using System.Collections.Generic;

namespace RiotRtmpDto.Platform.Statistics
{
    [Serializable]
    [SerializedName("com.riotgames.platform.statistics.PlayerStatSummaries")]
    public class PlayerStatSummaries
    {
        [SerializedName("playerStatSummarySet")]
        public List<PlayerStatSummary> PlayerStatSummarySet { get; set; }

        [SerializedName("userId")]
        public Double UserId { get; set; }
    }
}
