using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMessageContent
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public ChatAttachment[] Attachments { get; set; }

        [JsonProperty("reply_quote")]
        public string ReplyQuote { get; set; }

        [JsonProperty("forward")]
        public ChatForwardOrigin Forward { get; set; }

        [JsonProperty("poll")]
        public ChatPoll Poll { get; set; }

        [JsonProperty("group_created", NullValueHandling = NullValueHandling.Ignore)]
        public ChatGroupCreatedEventData GroupCreated { get; set; }

        [JsonProperty("members_added", NullValueHandling = NullValueHandling.Ignore)]
        public ChatMemberRef[] MembersAdded { get; set; }

        [JsonProperty("members_removed", NullValueHandling = NullValueHandling.Ignore)]
        public ChatMemberRef[] MembersRemoved { get; set; }

        [JsonProperty("member_rights_changed", NullValueHandling = NullValueHandling.Ignore)]
        public ChatMemberRightsChangedEventData MemberRightsChanged { get; set; }

        [JsonProperty("group_info_changed", NullValueHandling = NullValueHandling.Ignore)]
        public ChatGroupInfoChangedEventData GroupInfoChanged { get; set; }

        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }

        [JsonProperty("group_avatar_changed", NullValueHandling = NullValueHandling.Ignore)]
        public ChatGroupAvatarChangedEventData GroupAvatarChanged { get; set; }

        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserId { get; set; }
    }
}
