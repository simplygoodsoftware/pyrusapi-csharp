using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class SendChatMessageRequest
    {
        [JsonProperty("token")]
        public Guid? Token { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public ChatUpload[] Attachments { get; set; }

        [JsonProperty("reply_to_message_id")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty("reply_quote")]
        public string ReplyQuote { get; set; }

        internal SendChatMessageRequest CopyWithToken()
        {
            var copy = (SendChatMessageRequest)MemberwiseClone();
            copy.Token ??= Guid.NewGuid();
            return copy;
        }
    }
}
