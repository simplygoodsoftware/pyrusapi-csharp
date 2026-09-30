using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatResponse : ResponseBase
    {
        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }
}
