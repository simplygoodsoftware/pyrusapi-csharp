using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class Role
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("member_ids")]
		public int[] MemberIds { get; set; }
	}
}
