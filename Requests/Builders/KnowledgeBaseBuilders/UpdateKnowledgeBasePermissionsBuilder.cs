using System.Linq;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class UpdateKnowledgeBasePermissionsBuilder
	{
		private readonly UpdateKnowledgeBasePermissionsRequest _request;
		
		public string EntityId { get; }

		public UpdateKnowledgeBasePermissionsBuilder(string entityId)
		{
			EntityId = entityId;
			_request = new UpdateKnowledgeBasePermissionsRequest();
		}

		public UpdateKnowledgeBasePermissionsBuilder SetInherit(bool inherit)
		{
			_request.Inherit = inherit;
			return this;
		}

		public UpdateKnowledgeBasePermissionsBuilder SetReaders(params int[] readers)
		{
			_request.Readers = readers.ToList();
			return this;
		}

		public UpdateKnowledgeBasePermissionsBuilder SetEditors(params int[] editors)
		{
			_request.Editors = editors.ToList();
			return this;
		}

		public static implicit operator UpdateKnowledgeBasePermissionsRequest(UpdateKnowledgeBasePermissionsBuilder builder) => builder._request;
	}
}
