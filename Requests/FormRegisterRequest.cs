using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormRegisterRequest
	{
		[JsonProperty("steps")]
		public List<int> Steps { get; set; } = new List<int>();

		[JsonProperty("include_archived")]
		public bool? IncludeArchived { get; set; }

		[JsonProperty("modified_before")]
		public DateTime? ModifiedBefore { get; set; }

		[JsonProperty("modified_after")]
		public DateTime? ModifiedAfter { get; set; }

		[JsonProperty("filters")]
		public List<FormFilter> Filters { get; set; } = new List<FormFilter>();

		[JsonProperty("format")]
		public ResponseFormat ResponseFormat { get; set; }

		[JsonProperty("delimiter")]
		public string Delimiter { get; set; }

		[JsonProperty("simple_format")]
		public bool SimpleFormat { get; set; }

		[JsonProperty("encoding")]
		public string Encoding { get; set; }

		[JsonProperty("field_ids")]
		public List<int> FieldIds { get; set; }
	}
}
