using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class RolesResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "roles")]
        List<Role> Roles { get; set; } = new List<Role>();
    }
}
