using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class UpdateChatMemberRequest : ChatTokenRequest
    {
        [JsonProperty("member")]
        public ChatMemberRef Member { get; set; }

        [JsonProperty("rights")]
        public string Rights { get; set; }

        [JsonProperty("permissions", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Permissions { get; set; }
    }
}
