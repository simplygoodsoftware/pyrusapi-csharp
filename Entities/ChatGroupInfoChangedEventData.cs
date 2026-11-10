using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class ChatGroupInfoChangedEventData
    {
        [JsonProperty("name_changed")]
        public bool? NameChanged { get; set; }

        [JsonProperty("description_changed")]
        public bool? DescriptionChanged { get; set; }

        [JsonProperty("old_name")]
        public string OldName { get; set; }

        [JsonProperty("new_name")]
        public string NewName { get; set; }

        [JsonProperty("old_description")]
        public string OldDescription { get; set; }

        [JsonProperty("new_description")]
        public string NewDescription { get; set; }
    }
}
