using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class SendChatMessageRequest : ChatMessageContentRequest
    {
        [JsonProperty("poll")]
        public CreateChatPoll Poll { get; set; }
    }
}
