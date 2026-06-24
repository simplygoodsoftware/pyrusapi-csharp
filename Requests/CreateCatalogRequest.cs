using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class CreateCatalogRequest : CatalogRequestBase
	{
		[JsonProperty("name")]
		public string CatalogName { get; set; }

		[JsonProperty("external_version")]
		public long ExternalVersion { get; set; }

        [JsonProperty("source_type")]
        public SourceType SourceType { get; set; }

        [JsonProperty("external_last_sync_date")]
        public DateTime? ExternalLastSyncDate { get; set; }

        [JsonProperty("external_change_date")]
        public DateTime? ExternalChangeDate { get; set; }
    }
}
