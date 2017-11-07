using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormRegisterResponse : ResponseBase
	{
		[JsonProperty("tasks")]
		public Task[] Tasks { get; set; }
	}
}
