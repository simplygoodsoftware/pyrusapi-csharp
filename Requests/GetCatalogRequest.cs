using Newtonsoft.Json;
using Pyrus.ApiClient.Entities;

namespace Pyrus.ApiClient.Requests
{
    public class GetCatalogRequest
    {
        [JsonProperty(PropertyName = "include_deleted_items")]
        public bool IncludeDeletedItems { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public CatalogItemValueFilter[] Filters { get; set; }
    }
}