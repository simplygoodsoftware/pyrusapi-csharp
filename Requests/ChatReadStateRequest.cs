using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatReadStateRequest
    {
        [JsonProperty("read_through_message_id")]
        public string ReadThroughMessageId { get; set; }

        [JsonProperty("mark_unread")]
        public bool? MarkUnread { get; set; }
    }
}
