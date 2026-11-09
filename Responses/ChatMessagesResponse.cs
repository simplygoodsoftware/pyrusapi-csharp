using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatMessagesResponse : ResponseBase
    {
        [JsonProperty("messages")]
        public ChatMessage[] Messages { get; set; }

        [JsonProperty("has_more")]
        public bool? HasMore { get; set; }
    }
}
