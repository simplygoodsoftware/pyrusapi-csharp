using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class BpmnDiagramVersionInfo
	{
		[JsonProperty("bpmn_version")]
		public int BpmnVersion { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("create_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime CreateDate { get; set; }

		[JsonProperty("delete_date")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? DeleteDate { get; set; }

		[JsonProperty("author")]
		public Person Author { get; set; }
	}
}
