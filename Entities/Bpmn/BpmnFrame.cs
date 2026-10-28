using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnFrame
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("position")]
		public BpmnPosition Position { get; set; }

		[JsonProperty("size")]
		public BpmnSize Size { get; set; }
	}
}
