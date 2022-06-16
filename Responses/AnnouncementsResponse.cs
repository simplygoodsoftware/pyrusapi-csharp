using System.Collections.Generic;
using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class AnnouncementsResponse : ResponseBase
	{
		[JsonProperty("announcements")] 
		public List<AnnouncementWithComments> Announcements { get; set; }
	}
}
