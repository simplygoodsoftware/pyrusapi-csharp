using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class UpdateChatGroupRequest : ChatTokenRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("basic_permissions", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] BasicPermissions { get; set; }
    }
}
