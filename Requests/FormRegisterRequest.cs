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

		[JsonProperty("created_before")]
		public DateTime? CreatedBefore { get; set; }

		[JsonProperty("created_after")]
		public DateTime? CreatedAfter { get; set; }

		[JsonProperty("closed_before")]
		public DateTime? ClosedBefore { get; set; }

		[JsonProperty("closed_after")]
		public DateTime? ClosedAfter { get; set; }

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
		
		[JsonProperty("task_ids")]
		public List<int> TaskIds { get; set; } = new List<int>();

		[JsonProperty("due_filter")]
		public DueFilter DueFilter { get; set; }
	}
}
