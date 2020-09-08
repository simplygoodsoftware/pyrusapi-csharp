using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CreateCatalogRequest : CatalogRequestBase
	{
		[JsonProperty(PropertyName = "name")]
		public string CatalogName { get; set; }
	}
}
