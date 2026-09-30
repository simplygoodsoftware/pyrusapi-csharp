using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatForwardRequest : ChatTokenRequest
    {
        [JsonProperty("source_chat_id")]
        public string SourceChatId { get; set; }

        [JsonProperty("source_message_id")]
        public string SourceMessageId { get; set; }
    }
}
