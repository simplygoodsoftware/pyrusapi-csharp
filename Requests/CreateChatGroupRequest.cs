using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class CreateChatGroupRequest : ChatTokenRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("members", DefaultValueHandling = DefaultValueHandling.Include)]
        public ChatMemberInput[] Members { get; set; }

        [JsonProperty("basic_permissions", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] BasicPermissions { get; set; }
    }
}
