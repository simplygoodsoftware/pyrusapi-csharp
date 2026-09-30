using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class RemoveChatMemberRequest : ChatTokenRequest
    {
        [JsonProperty("member")]
        public ChatMemberRef Member { get; set; }
    }
}
