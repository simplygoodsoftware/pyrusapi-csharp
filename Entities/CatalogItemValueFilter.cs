using Newtonsoft.Json;

namespace Pyrus.ApiClient.Entities
{
    public class CatalogItemValueFilter
    {
        [JsonProperty(PropertyName = "column_name")]
        public string ColumnName { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}