using System;

namespace Pyrus.ApiClient.Entities
{
    public class CatalogItemValueFilter
    {
        public string ColumnName { get; set; }

        public string Value { get; set; }

        [Obsolete("Use GetCatalogRequest.UseWildcard.")]
        public bool IsRegularExpression { get; set; }
    }
}