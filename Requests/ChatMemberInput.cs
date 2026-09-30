using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMemberInput : ChatMemberRef
    {
        [JsonProperty("rights")]
        public string Rights { get; set; }

        [JsonProperty("permissions", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Permissions { get; set; }
    }
}
