using Newtonsoft.Json;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
    public class MultipleTasksCommentResponse : ResponseBase
    {
        [JsonProperty("tasks")]
        public List<TaskWithComments> Tasks { get; set; }
    }
}
