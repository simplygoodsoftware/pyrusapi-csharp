using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatReaction
    {
        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("is_set_by_me")]
        public bool IsSetByMe { get; set; }
    }
}
