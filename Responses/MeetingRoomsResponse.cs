using System.Collections.Generic;
using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class MeetingRoomsResponse : ResponseBase
	{
		[JsonProperty("meeting_rooms")]
		public List<MeetingRoom> MeetingRooms { get; set; } = new List<MeetingRoom>();
	}
}
