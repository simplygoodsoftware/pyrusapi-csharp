using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatMembershipResponse : ResponseBase
    {
        [JsonProperty("has_access")]
        public bool HasAccess { get; set; }

        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }
}
