using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class AnnouncementResponse : ResponseBase
	{
		[JsonProperty("announcement")]
		public AnnouncementWithComments Announcement { get; set }
	}
}
