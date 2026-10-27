using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMessage : ChatMessageBase
    {
        [JsonProperty("reactions")]
        public ChatReaction[] Reactions { get; set; }
    }
}
