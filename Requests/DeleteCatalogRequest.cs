using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class DeleteCatalogRequest
	{
		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
