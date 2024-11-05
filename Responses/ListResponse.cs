using Newtonsoft.Json;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
    public class ListResponse : PlainListResponse
    {
        [JsonProperty("children")]
        public List<TaskList> Children { get; set; } = new List<TaskList>();
    }
}
