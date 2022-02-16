using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class UpdateListRequest
	{
		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
