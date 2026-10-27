using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatSearchMessagesResponse : ResponseBase
    {
        [JsonProperty("items")]
        public ChatMessageBase[] Items { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
