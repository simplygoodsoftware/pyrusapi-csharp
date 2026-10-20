using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	/// <summary>
	/// Current state of a BPMN token of a task.
	/// </summary>
	public class BpmnToken
	{
		[JsonProperty("token_id")]
		public int TokenId { get; set; }

		[JsonProperty("node_id")]
		public int NodeId { get; set; }

		[JsonProperty("node_name")]
		public string NodeName { get; set; }

		[JsonProperty("node_type")]
		public BpmnNodeType? NodeType { get; set; }

		[JsonProperty("status")]
		public BpmnTokenStatus Status { get; set; }

		/// <summary>
		/// Assignee of the node the token is on.
		/// </summary>
		[JsonProperty("person")]
		public Person Person { get; set; }

		/// <summary>
		/// Type of the event the token is waiting for.
		/// </summary>
		[JsonProperty("event_type")]
		public BpmnTokenEventType? EventType { get; set; }

		[JsonProperty("event_time")]
		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateTimeFormat)]
		public DateTime? EventTime { get; set; }
	}
}
