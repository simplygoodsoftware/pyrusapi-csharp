using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class AddChatMembersRequest : ChatTokenRequest
    {
        [JsonProperty("members", DefaultValueHandling = DefaultValueHandling.Include)]
        public ChatMemberInput[] Members { get; set; }
    }
}
