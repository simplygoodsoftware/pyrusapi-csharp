using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class CreateChatScheduledMessageRequest : ChatMessageContentRequest
    {
        [JsonProperty("send_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime? SendAt { get; set; }
    }
}
