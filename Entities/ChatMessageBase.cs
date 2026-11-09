using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class ChatMessageBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_date")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime CreateDate { get; set; }

        [JsonProperty("edited_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat, true)]
        public DateTime? EditedAt { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public ChatAttachment[] Attachments { get; set; }

        [JsonProperty("reply_to_message_id")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty("reply_quote")]
        public string ReplyQuote { get; set; }

        [JsonProperty("forward")]
        public ChatForwardOrigin Forward { get; set; }

        [JsonProperty("poll")]
        public ChatPoll Poll { get; set; }

        [JsonProperty("system")]
        public ChatSystemEvent System { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
