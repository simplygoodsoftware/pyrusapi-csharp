using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormRegisterResponse : ResponseBase
	{
		[JsonProperty("tasks")]
		public List<Task> Tasks { get; set; }

		internal string Csv { get; set; }
	}
}
