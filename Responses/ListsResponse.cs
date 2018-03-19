using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class ListsResponse : ResponseBase
	{
		[JsonProperty("lists")]
		public List<TaskList> Lists { get; set; }
	}
}
