using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class PlainListsResponse : ResponseBase
	{
		[JsonProperty("lists")]
		public List<PlainTaskList> Lists { get; set; }
	}
}
