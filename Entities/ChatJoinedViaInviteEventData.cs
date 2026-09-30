using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatJoinedViaInviteEventData : ChatSystemEventData
    {
        [JsonProperty("user_id")]
        public int? UserId { get; set; }
    }
}
