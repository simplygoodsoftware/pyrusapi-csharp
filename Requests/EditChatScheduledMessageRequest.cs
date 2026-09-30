using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class EditChatScheduledMessageRequest : EditChatMessageRequest
    {
        [JsonProperty("send_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime? SendAt { get; set; }
    }
}
