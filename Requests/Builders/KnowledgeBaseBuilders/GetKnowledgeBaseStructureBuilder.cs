namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetKnowledgeBaseStructureBuilder
	{
		public string ParentTopicId { get; private set; }
		public int? Depth { get; private set; }

		public GetKnowledgeBaseStructureBuilder WithParentTopicId(string parentTopicId)
		{
			ParentTopicId = parentTopicId;
			return this;
		}

		public GetKnowledgeBaseStructureBuilder WithDepth(int depth)
		{
			Depth = depth;
			return this;
		}
	}
}
