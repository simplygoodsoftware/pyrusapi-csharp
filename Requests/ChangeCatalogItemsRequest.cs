using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ChangeCatalogRequest
    {
        [JsonProperty(PropertyName = "added")]
        public List<CatalogItem> Added { get; set; } = new List<CatalogItem>();

        [JsonProperty(PropertyName = "updated")]
        public List<CatalogItem> Updated { get; set; } = new List<CatalogItem>();

        [JsonProperty(PropertyName = "deleted")]
        public List<CatalogItem> Deleted { get; set; } = new List<CatalogItem>();
    }
}
