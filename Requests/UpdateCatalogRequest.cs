using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateCatalogRequest : CatalogRequestBase
	{
		[JsonProperty(PropertyName = "apply")]
		public bool Apply { get; set; }
	}
}
