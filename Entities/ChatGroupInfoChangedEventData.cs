using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatGroupInfoChangedEventData : ChatSystemEventData
    {
        [JsonProperty("title_changed")]
        public bool? TitleChanged { get; set; }

        [JsonProperty("description_changed")]
        public bool? DescriptionChanged { get; set; }

        [JsonProperty("old_title")]
        public string OldTitle { get; set; }

        [JsonProperty("new_title")]
        public string NewTitle { get; set; }

        [JsonProperty("old_description")]
        public string OldDescription { get; set; }

        [JsonProperty("new_description")]
        public string NewDescription { get; set; }
    }
}
