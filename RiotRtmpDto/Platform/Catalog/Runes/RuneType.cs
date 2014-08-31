using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Catalog.Runes
{
    [Serializable]
    [SerializedName("com.riotgames.platform.catalog.runes.RuneType")]
    public class RuneType
    {
        [SerializedName("runeTypeId")]
        public Int32 RuneTypeId { get; set; }

        [SerializedName("name")]
        public String Name { get; set; }
    }
}
