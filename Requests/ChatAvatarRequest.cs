using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatAvatarRequest : ChatTokenRequest
    {
        [JsonProperty("upload_id")]
        public string UploadId { get; set; }

        [JsonProperty("x")]
        public int? X { get; set; }

        [JsonProperty("y")]
        public int? Y { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }
    }
}
