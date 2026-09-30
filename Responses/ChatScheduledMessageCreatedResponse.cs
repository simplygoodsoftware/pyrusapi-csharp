using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatScheduledMessageCreatedResponse : ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
