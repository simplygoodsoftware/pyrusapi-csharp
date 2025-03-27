using System;
using System.Text;
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

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append("?");
            result.Append($"include_deleted={IncludeDeletedItems}");

            var isRegularExpression = false;
            foreach (var filter in Filters)
            {
                if (filter.IsRegularExpression)
                    isRegularExpression = true;

                result.Append(
                    $"&column={Uri.EscapeDataString(filter.ColumnName)}&value={Uri.EscapeDataString(filter.Value)}");
            }

            result.Append($"&is_regex={isRegularExpression}");

            return result.ToString();
        }
    }
}