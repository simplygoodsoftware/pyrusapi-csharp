using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatMessageResponse : ResponseBase
    {
        [JsonProperty("message")]
        public ChatMessage Message { get; set; }
    }
}
