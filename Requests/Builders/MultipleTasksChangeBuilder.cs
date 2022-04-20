using System;
using System.Collections.Generic;
using Pyrus.ApiClient.Requests.Builders;
using PyrusApiClient.Builders;

namespace Pyrus.ApiClient.Requests
{
    public class MultipleTasksChangeBuilder
    {
        private readonly MultipleTasksChangeRequest _request = new MultipleTasksChangeRequest
        {
            Comments = new List<CommentDescription>()
        };

        public MultipleTasksChangeBuilder(bool noTasksInResponse)
        {
            _request.NoTasksInResponse = noTasksInResponse;
        }

        public MultipleTasksChangeBuilder CommentFormTask(int taskId, long previousNoteId, Action<FormTaskCommentBuilder> buildAction)
        {
            var builder = RequestBuilder.CommentFormTask(taskId);
            buildAction(builder);
            _request.Comments.Add(new CommentDescription
            {
                TaskId = taskId,
                PreviousNoteId = previousNoteId,
                Comment = builder
            });
            return this;
        }

        public MultipleTasksChangeBuilder CommentSimpleTask(int taskId, long previousNoteId, Action<SimpleTaskCommentBuilder> buildAction)
        {
            var builder = RequestBuilder.CommentSimpleTask(taskId);
            buildAction(builder);
            _request.Comments.Add(new CommentDescription
            {
                TaskId = taskId,
                PreviousNoteId = previousNoteId,
                Comment = builder
            });
            return this;
        }
        
        public static implicit operator MultipleTasksChangeRequest(MultipleTasksChangeBuilder builder)
        {
            return builder._request;
        }
    }
}