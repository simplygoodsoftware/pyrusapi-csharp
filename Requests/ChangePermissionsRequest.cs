using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
	public class ChangePermissionsRequest
	{
		[JsonProperty("add_managers")]
		public int[] AddManagers { get; set; }

		[JsonProperty("add_members")]
		public int[] AddMembers { get; set; }

		[JsonProperty("remove_access")]
		public int[] RemoveAccess { get; set; }
	}
}
