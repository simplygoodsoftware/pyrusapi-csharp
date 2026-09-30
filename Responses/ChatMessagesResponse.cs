using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatMessagesResponse : ResponseBase
    {
        [JsonProperty("items")]
        public ChatMessage[] Items { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
