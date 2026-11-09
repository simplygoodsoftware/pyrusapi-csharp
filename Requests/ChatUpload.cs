using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatUpload
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}
