using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class SyncCatalogRequest : CatalogRequestBase
	{
		[JsonProperty(PropertyName = "apply")]
		public bool Apply { get; set; }

		[JsonProperty(PropertyName = "force_update_first_column")]
		public bool ForceUpdateFirstColumn { get; set; }
	}
}
