using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateKnowledgeBaseEntityBuilder
	{
		private readonly UpdateKnowledgeBaseEntityRequest _request;

		public string EntityId { get; }

		public UpdateKnowledgeBaseEntityBuilder(string entityId)
		{
			EntityId = entityId;
			_request = new UpdateKnowledgeBaseEntityRequest();
		}

		public UpdateKnowledgeBaseEntityBuilder WithTitle(string title)
		{
			_request.Title = title;
			return this;
		}

		public UpdateKnowledgeBaseEntityBuilder WithBody(string body)
		{
			_request.Body = body;
			return this;
		}

		public UpdateKnowledgeBaseEntityBuilder WithParentTopicId(string parentTopicId)
		{
			_request.ParentTopicIdChanged = true;
			_request.ParentTopicId = parentTopicId;
			return this;
		}

		public UpdateKnowledgeBaseEntityBuilder ClearParentTopic()
		{
			_request.ParentTopicIdChanged = true;
			_request.ParentTopicId = null;
			return this;
		}

		public static implicit operator UpdateKnowledgeBaseEntityRequest(UpdateKnowledgeBaseEntityBuilder builder) => builder._request;
	}
}
