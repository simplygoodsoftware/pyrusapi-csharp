using Pyrus.ApiClient.Enums;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class CreateKnowledgeBaseEntityBuilder
	{
		private readonly CreateKnowledgeBaseEntityRequest _request;

		public CreateKnowledgeBaseEntityBuilder(string title, KnowledgeBaseEntityType type)
		{
			_request = new CreateKnowledgeBaseEntityRequest
			{
				Title = title,
				Type = type
			};
		}

		public CreateKnowledgeBaseEntityBuilder WithBody(string body)
		{
			_request.Body = body;
			return this;
		}

		public CreateKnowledgeBaseEntityBuilder InTopic(string parentTopicId)
		{
			_request.ParentTopicId = parentTopicId;
			return this;
		}

		public static implicit operator CreateKnowledgeBaseEntityRequest(CreateKnowledgeBaseEntityBuilder builder) => builder._request;
	}
}
