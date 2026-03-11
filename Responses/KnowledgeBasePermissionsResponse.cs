using System.Collections.Generic;
using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class KnowledgeBasePermissionsResponse : ResponseBase
	{
		[JsonProperty("global_permission")]
		public KnowledgeBasePermissionLevel GlobalPermission { get; set; }

		[JsonProperty("inherit")]
		public bool Inherit { get; set; }

		[JsonProperty("readers")]
		public List<KnowledgeBasePersonInfo> Readers { get; set; }

		[JsonProperty("editors")]
		public List<KnowledgeBasePersonInfo> Editors { get; set; }
	}
}
