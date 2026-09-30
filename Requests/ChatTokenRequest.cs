using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatTokenRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
