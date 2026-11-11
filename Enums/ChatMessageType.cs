using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    [JsonConverter(typeof(StringEnumWithDefaultConverter), (int)Unknown)]
    public enum ChatMessageType
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "forward")]
        Forward,

        [EnumMember(Value = "poll")]
        Poll,

        [EnumMember(Value = "group_created")]
        GroupCreated,

        [EnumMember(Value = "members_added")]
        MembersAdded,

        [EnumMember(Value = "members_removed")]
        MembersRemoved,

        [EnumMember(Value = "member_rights_changed")]
        MemberRightsChanged,

        [EnumMember(Value = "group_info_changed")]
        GroupInfoChanged,

        [EnumMember(Value = "message_pinned")]
        MessagePinned,

        [EnumMember(Value = "message_unpinned")]
        MessageUnpinned,

        [EnumMember(Value = "group_avatar_changed")]
        GroupAvatarChanged,

        [EnumMember(Value = "joined_via_invite")]
        JoinedViaInvite
    }
}
