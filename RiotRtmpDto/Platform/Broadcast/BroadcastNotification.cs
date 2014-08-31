using System;
using RtmpSharp.IO;
using RtmpSharp.IO.AMF3;
using Newtonsoft.Json;
using System.Text;
using System.Collections;

namespace RiotRtmpDto.Platform.Broadcast
{
    [Serializable]
    [SerializedName("com.riotgames.platform.broadcast.BroadcastNotification", Canonical = true)]
    public class BroadcastNotification : IExternalizable
    {
        public ArrayList broadcastMessages { get; set; }

        public string Json { get; set; }

        public BroadcastNotification()
        {
        }

        public void ReadExternal(IDataInput input)
        {
            string str = input.ReadUtf(input.ReadInt32());
            this.broadcastMessages = JsonConvert.DeserializeObject<ArrayList>(str);
        }

        public void WriteExternal(IDataOutput output)
        {
            var bytes = Encoding.UTF8.GetBytes(Json);

            output.WriteInt32(bytes.Length);
            output.WriteBytes(bytes);
        }
    }
}