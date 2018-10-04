using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class SyncCatalogRequest : CatalogRequestBase
	{
		[JsonProperty(PropertyName = "apply")]
		public bool Apply { get; set; }
	}
}
