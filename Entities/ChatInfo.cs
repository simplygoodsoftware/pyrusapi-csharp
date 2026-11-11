using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("peer_id")]
        public int? PeerId { get; set; }

        [JsonProperty("organization_id")]
        public int OrganizationId { get; set; }
    }
}
