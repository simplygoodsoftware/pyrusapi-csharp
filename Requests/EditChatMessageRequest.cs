using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class EditChatMessageRequest : ChatTokenRequest
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Include)]
        public string Text { get; set; }

        [JsonProperty("added_attachments", DefaultValueHandling = DefaultValueHandling.Include)]
        public ChatUpload[] AddedAttachments { get; set; }

        [JsonProperty("deleted_attachment_ids", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] DeletedAttachmentIds { get; set; }

        [JsonProperty("rearranged_attachments", DefaultValueHandling = DefaultValueHandling.Include)]
        public ChatAttachmentRearrange[] RearrangedAttachments { get; set; }
    }
}
