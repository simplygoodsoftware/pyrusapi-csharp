using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnPosition
	{
		[JsonProperty("x")]
		public int X { get; set; }

		[JsonProperty("y")]
		public int Y { get; set; }
	}
}
