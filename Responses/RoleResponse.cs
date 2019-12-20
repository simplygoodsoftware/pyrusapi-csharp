using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class RoleResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "role")]
        public Role Role { get; set; }
    }
}
