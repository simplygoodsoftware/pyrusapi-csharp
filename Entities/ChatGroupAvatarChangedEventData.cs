using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatGroupAvatarChangedEventData
    {
        [JsonProperty("old_avatar_id")]
        public int? OldAvatarId { get; set; }

        [JsonProperty("new_avatar_id")]
        public int? NewAvatarId { get; set; }
    }
}
