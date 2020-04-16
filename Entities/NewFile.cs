using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class NewFile
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("root_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? RootId { get; set; }


        [JsonProperty("attachment_id")]
        public int AttachmentId { get; set; }


        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        public NewFile()
        {
        }

        public NewFile(string guid, int? rootId)
        {
            Guid = guid ?? throw new System.ArgumentNullException(nameof(guid));
            RootId = rootId;
        }

        public NewFile(int attachmentId)
        {
            AttachmentId = attachmentId;
        }

        public NewFile(string url, string name)
        {
            Url = url ?? throw new System.ArgumentNullException(nameof(url));
            Name = name;
        }
    }
}
