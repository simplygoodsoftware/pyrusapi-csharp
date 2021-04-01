using Newtonsoft.Json;
using PyrusApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Responses
{
    public class MembersResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "members")]
        public List<Person> Members { get; set; } = new List<Person>();
    }
}
