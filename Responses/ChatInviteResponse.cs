using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatInviteResponse : ResponseBase
    {
        [JsonProperty("invite_link")]
        public string InviteLink { get; set; }
    }
}
