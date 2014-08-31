using System;
using RtmpSharp.IO;

namespace RiotRtmpDto.Platform.Gameinvite.Contract
{
    [Serializable]
    [SerializedName("com.riotgames.platform.gameinvite.contract.InvitationRequest")]
    public class InvitationRequest
    {
        [SerializedName("gameMetaData")]
        public String GameMetaData { get; set; }

        [SerializedName("invitationStateAsString")]
        public String InvitationStateAsString { get; set; }

        [SerializedName("invitationState")]
        public String InvitationState { get; set; }

        [SerializedName("invitationId")]
        public String InvitationId { get; set; }

        [SerializedName("inviter")]
        public Inviter Inviter { get; set; }

        [SerializedName("owner")]
        public Member Owner { get; set; }
    }
}
