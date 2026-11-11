using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
    public class ChatMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        [JsonProperty("type")]
        public ChatMessageType Type { get; set; }

        [JsonProperty("create_date")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
        public DateTime CreateDate { get; set; }

        [JsonProperty("edited_at")]
        [JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
        public DateTime? EditedAt { get; set; }

        [JsonProperty("reply_to_message_id")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty("content")]
        public ChatMessageContent Content { get; set; }

        [JsonProperty("reactions")]
        public ChatReaction[] Reactions { get; set; }
    }
}
