using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Harassment
{
    [Serializable]
    [SerializedName("com.riotgames.platform.harassment.LcdsResponseString")]
    public class LcdsResponseString
    {
        [SerializedName("value")]
        public String Value { get; set; }
    }
}
