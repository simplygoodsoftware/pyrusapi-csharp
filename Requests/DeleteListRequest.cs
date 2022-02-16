using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class DeleteListRequest
	{
		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
