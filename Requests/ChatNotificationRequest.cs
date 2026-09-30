using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatNotificationRequest
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }
}
