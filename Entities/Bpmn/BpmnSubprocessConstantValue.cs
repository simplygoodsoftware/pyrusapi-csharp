using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class BpmnSubprocessConstantValue
	{
		[JsonProperty("bit")]
		public bool? Bit { get; set; }

		[JsonProperty("long")]
		public long? Long { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		public DateTime? Date { get; set; }

		[JsonProperty("amount")]
		public decimal? Amount { get; set; }

		[JsonProperty("int_values")]
		public List<int> IntValues { get; set; }

		[JsonProperty("catalog_id")]
		public int? CatalogId { get; set; }

		[JsonProperty("catalog_id_values")]
		public List<long> CatalogIdValues { get; set; }

		[JsonProperty("catalog_text_values")]
		public List<string> CatalogTextValues { get; set; }
	}
}
