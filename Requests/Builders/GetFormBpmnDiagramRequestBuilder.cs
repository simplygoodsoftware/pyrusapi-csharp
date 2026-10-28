namespace Pyrus.ApiClient.Requests.Builders
{
	public class GetFormBpmnDiagramRequestBuilder
	{
		public int FormId { get; }

		public int BpmnVersion { get; }

		public GetFormBpmnDiagramRequestBuilder(int formId, int bpmnVersion)
		{
			FormId = formId;
			BpmnVersion = bpmnVersion;
		}
	}
}
