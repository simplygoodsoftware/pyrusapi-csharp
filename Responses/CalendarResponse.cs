using System.Collections.Generic;
using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class CalendarResponse : ResponseBase
	{
		[JsonProperty("tasks")]
		public List<TaskWithComments> Tasks { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}
