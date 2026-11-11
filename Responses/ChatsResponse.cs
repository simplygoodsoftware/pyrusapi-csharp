using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
    public class ChatsResponse : ResponseBase
    {
        [JsonProperty("chats")]
        public ChatInfo[] Chats { get; set; }
    }
}
