using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormsResponse : ResponseBase
	{
		[JsonProperty("forms")]
		public List<FormResponse> Forms { get; set; }
	}
}
