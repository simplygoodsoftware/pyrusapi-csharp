namespace Pyrus.ApiClient.Requests.Builders
{
	public class DeleteKnowledgeBaseEntityBuilder
	{
		public string EntityId { get; }
		public bool DeleteWithChildren { get; private set; }

		public DeleteKnowledgeBaseEntityBuilder(string entityId)
		{
			EntityId = entityId;
		}

		public DeleteKnowledgeBaseEntityBuilder WithChildren()
		{
			DeleteWithChildren = true;
			return this;
		}
	}
}
