using System;
using RtmpSharp.IO;
using System.Collections.Generic;

namespace RiotRtmpDto.Platform.Trade.Api.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.trade.api.contract.PotentialTradersDTO")]
    public class PotentialTradersDTO
    {
        [SerializedName("potentialTraders")]
        public List<String> PotentialTraders { get; set; }
    }
}
