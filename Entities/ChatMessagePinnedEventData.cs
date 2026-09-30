using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMessagePinnedEventData : ChatSystemEventData
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
    }
}
