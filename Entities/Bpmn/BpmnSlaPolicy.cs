using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Правило SLA: целевое время, условие применения и (для политики по статусам) значение статуса.
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
