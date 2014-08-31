using System;
using System.Collections.Generic;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.LobbyStatus")]
    public class LobbyStatus
    {
        [SerializedName("chatKey")]
        public String ChatKey { get; set; }

        [SerializedName("gameMetaData")]
        public String GameData { get; set; }

        [SerializedName("owner")]
        public Player Owner { get; set; }

        [SerializedName("members")]
        public List<Member> Members { get; set; }

        [SerializedName("invitees")]
        public List<Invitee> Invitees { get; set; }

        [SerializedName("invitationId")]
        public String InvitationID { get; set; }
    }
}
