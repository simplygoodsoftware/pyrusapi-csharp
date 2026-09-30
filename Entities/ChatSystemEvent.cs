using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    [JsonConverter(typeof(ChatSystemEventJsonConverter))]
    public class ChatSystemEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public ChatSystemEventData Data { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
