using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMember : ChatMemberRef
    {
        [JsonProperty("rights")]
        public string Rights { get; set; }

        [JsonProperty("permissions")]
        public string[] Permissions { get; set; }

        [JsonProperty("is_bot")]
        public bool? IsBot { get; set; }
    }
}
