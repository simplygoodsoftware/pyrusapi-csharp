using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormLink
	{
		[JsonProperty("task_id")]
		[Obsolete]
		public int? TaskId { get; set; }

		[JsonProperty("task_ids")]
		public int[] TaskIds { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }
	}
}
