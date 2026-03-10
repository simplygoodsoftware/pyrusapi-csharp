using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class UpdateKnowledgeBasePermissionsRequest
	{
		[JsonProperty("inherit")]
		public bool? Inherit { get; set; }

		[JsonProperty("readers")]
		public List<int> Readers { get; set; }

		[JsonProperty("editors")]
		public List<int> Editors { get; set; }
	}
}
