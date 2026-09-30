using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatUpload
    {
        [JsonProperty("upload_id")]
        public string UploadId { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }
    }
}
