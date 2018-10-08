using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CreateCatalogRequest : CatalogRequestBase
	{
		[JsonProperty(PropertyName = "catalog_name")]
		public string CatalogName { get; set; }
	}
}
