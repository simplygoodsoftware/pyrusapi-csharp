using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class ChatScheduledMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public ChatAttachment[] Attachments { get; set; }

        [JsonProperty("reply_to_message_id")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty("reply_quote")]
        public string ReplyQuote { get; set; }

        [JsonProperty("send_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime SendAt { get; set; }

        [JsonProperty("is_send_failed")]
        public bool IsSendFailed { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
