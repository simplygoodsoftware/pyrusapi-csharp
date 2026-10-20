using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// SLA calendar of a diagram: base calendar, mode and working hours.
	/// </summary>
	public class BpmnSlaCalendar
	{
		[JsonProperty("base_calendar")]
		public string BaseCalendar { get; set; }

		[JsonProperty("active")]
		public BpmnSlaCalendarState Active { get; set; }

		[JsonProperty("time_zone_offset")]
		public int TimeZoneOffset { get; set; }

		[JsonProperty("workday_start")]
		public int WorkdayStart { get; set; }

		[JsonProperty("workday_end")]
		public int WorkdayEnd { get; set; }
	}
}
