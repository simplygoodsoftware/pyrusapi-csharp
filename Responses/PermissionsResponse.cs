using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Responses
{
	public class PermissionsResponse : ResponseBase
	{
		[JsonProperty("permissions")]
		public Dictionary<int, PermissionLevel> Permissions { get; set; }
	}
}
