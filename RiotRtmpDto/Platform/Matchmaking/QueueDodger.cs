﻿using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Matchmaking
{
    [Serializable]
    [SerializedName("com.riotgames.platform.matchmaking.QueueDodger")]
    public class QueueDodger
    {
        [SerializedName("reasonFailed")]
        public string ReasonFailed { get; set; }

        [SerializedName("summoner")]
        public Summoner.Summoner Summoner { get; set; }

        [SerializedName("dodgePenaltyRemainingTime")]
        public Int32 PenaltyRemainingTime { get; set; }
    }
}
