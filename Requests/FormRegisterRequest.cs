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

		[JsonProperty("filters")]
		public List<FormFilter> Filters { get; set; } = new List<FormFilter>();
	}
}
