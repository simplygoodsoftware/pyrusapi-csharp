using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatJoinRequest : ChatTokenRequest
    {
        [JsonProperty("invite_link")]
        public string InviteLink { get; set; }
    }
}
