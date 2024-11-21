using Newtonsoft.Json;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
    public class MembersResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "members")]
        public List<Person> Members { get; set; } = new List<Person>();
    }
}
