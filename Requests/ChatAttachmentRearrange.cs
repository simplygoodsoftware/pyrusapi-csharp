using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatAttachmentRearrange
    {
        [JsonProperty("attachment_id")]
        public string AttachmentId { get; set; }

        [JsonProperty("new_order")]
        public int NewOrder { get; set; }
    }
}
