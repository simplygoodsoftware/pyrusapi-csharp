using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class BpmnSize
	{
		[JsonProperty("w")]
		public int Width { get; set; }

		[JsonProperty("h")]
		public int Height { get; set; }
	}
}
