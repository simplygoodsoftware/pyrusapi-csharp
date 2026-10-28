using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// SLA rule: target time, condition and (for a by-status policy) the status value.
	/// </summary>
	public class BpmnSlaPolicy
	{
		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("sla_target_time_hours")]
		public int TargetTimeHours { get; set; }

		[JsonProperty("sla_target_time_minutes")]
		public int TargetTimeMinutes { get; set; }

		[JsonProperty("is_frozen")]
		public bool IsFrozen { get; set; }

		[JsonProperty("condition")]
		public BpmnCondition Condition { get; set; }

		[JsonProperty("status_value")]
		public int? StatusValue { get; set; }

		[JsonProperty("calendar_state")]
		public BpmnSlaCalendarState? CalendarState { get; set; }
	}
}
