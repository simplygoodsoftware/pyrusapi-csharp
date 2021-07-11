using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CreateCatalogRequest : CatalogRequestBase
	{
		[JsonProperty("name")]
		public string CatalogName { get; set; }

		[JsonProperty("external_version")]
		public long ExternalVersion { get; set; }
	}
}
