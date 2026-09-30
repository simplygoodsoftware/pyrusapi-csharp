using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatMembersChangedEventData : ChatSystemEventData
    {
        [JsonProperty("members")]
        public ChatMemberRef[] Members { get; set; }
    }
}
