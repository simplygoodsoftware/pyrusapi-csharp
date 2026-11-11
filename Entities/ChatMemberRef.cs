using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMemberRef
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
