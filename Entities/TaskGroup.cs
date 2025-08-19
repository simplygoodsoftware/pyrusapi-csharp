using Newtonsoft.Json;
using System.Collections.Generic;

namespace PyrusApiClient
{
    public class TaskGroup
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("tasks")]
        public List<TaskHeader> Tasks { get; set; }
    }
}
