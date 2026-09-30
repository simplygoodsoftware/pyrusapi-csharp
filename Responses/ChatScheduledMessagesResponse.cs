using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatScheduledMessagesResponse : ResponseBase
    {
        [JsonProperty("items")]
        public ChatScheduledMessage[] Items { get; set; }
    }
}
