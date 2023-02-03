using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests
{
	public class ChangePermissionsRequest
	{
		[JsonProperty("permissions")]
		public Dictionary<int, PermissionLevel> Permissions { get; set; }
	}
}
