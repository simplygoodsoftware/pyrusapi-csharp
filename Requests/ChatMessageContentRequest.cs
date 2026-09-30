using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMessageContentRequest : ChatTokenRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments", DefaultValueHandling = DefaultValueHandling.Include)]
        public ChatUpload[] Attachments { get; set; }

        [JsonProperty("reply_to_message_id")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty("reply_quote")]
        public string ReplyQuote { get; set; }
    }
}
