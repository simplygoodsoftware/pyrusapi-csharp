using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatAttachment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("download_path")]
        public string DownloadPath { get; set; }
    }
}
