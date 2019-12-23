using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class RoleResponse : ResponseBase
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("banned")]
        public bool Banned { get; set; }

        [JsonProperty("member_ids")]
        public List<int> MemberIds { get; set; } = new List<int>();

        public Role Role =>
            new Role
            {
                Id = Id,
                Name = Name,
                ExternalId = ExternalId,
                Banned = Banned,
                MemberIds = MemberIds
            };
    }
}
