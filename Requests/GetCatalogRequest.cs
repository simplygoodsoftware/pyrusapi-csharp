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

        [JsonProperty(PropertyName = "use_wildcard")]
        public bool UseWildcard { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"?include_deleted={IncludeDeletedItems}");

            if (Filters != null && Filters.Length > 0)
            {
                foreach (var filter in Filters)
                {
                    result.Append(
                        $"&column={Uri.EscapeDataString(filter.ColumnName)}&value={Uri.EscapeDataString(filter.Value)}");
                }

                result.Append($"&use_wildcard={UseWildcard}");
            }

            return result.ToString();
        }
    }
    }