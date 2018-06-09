using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormRegisterRequest
	{
		[JsonProperty("steps")]
		public List<int> Steps { get; set; } = new List<int>();

		[JsonProperty("include_archived")]
		public bool? IncludeArchived { get; set; }

		[JsonProperty("modified_before")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? ModifiedBefore { get; set; }

		[JsonProperty("modified_after")]
		[JsonConverter(typeof(DateTimeJsonConverter), "yyyy-MM-ddTHH:mm:ssZ")]
		public DateTime? ModifiedAfter { get; set; }

		[JsonProperty("filters")]
		public List<FormFilter> Filters { get; set; } = new List<FormFilter>();
	}
}
