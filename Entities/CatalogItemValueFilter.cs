using Newtonsoft.Json;

namespace Pyrus.ApiClient.Entities
{
    public class CatalogItemValueFilter
    {
        public string ColumnName { get; set; }

        public string Value { get; set; }

        public bool IsRegularExpression { get; set; }
    }
}