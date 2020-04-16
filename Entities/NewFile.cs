using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class NewFile
    {
        [JsonProperty("guid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Guid { get; set; }

        [JsonProperty("root_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? RootId { get; set; }


        [JsonProperty("attachment_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AttachmentId { get; set; }


        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [System.Obsolete("Use parametrized constructors.")]
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
