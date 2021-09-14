using Newtonsoft.Json;
using Pyrus.ApiClient.Entities;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
    public sealed class MultipleTasksCommentRequest
    {
        public MultipleTasksCommentRequest(List<CommentDescription> comments = null)
        {
            this.Comments = comments ?? new List<CommentDescription>();
        }

        [JsonProperty("comments")]
        public List<CommentDescription> Comments { get; set; }
    }
}
