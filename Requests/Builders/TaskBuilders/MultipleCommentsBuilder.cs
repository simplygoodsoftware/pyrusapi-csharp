using Pyrus.ApiClient.Entities;
using PyrusApiClient;
using PyrusApiClient.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Requests.Builders.TaskBuilders
{
    public class MultipleCommentsBuilder
    {
        public MultipleCommentsBuilder(List<CommentDescription> comments = null)
        {
            Request = new MultipleTasksCommentRequest(comments);
        }

        public MultipleTasksCommentRequest Request { get; set; }
    }
}
