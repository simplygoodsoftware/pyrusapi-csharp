using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class CreateListRequest
	{
		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
