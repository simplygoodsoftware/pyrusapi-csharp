using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    public class AnnouncementRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("formatted_text")]
        public string FormattedText { get; set; }

        [JsonProperty("attachments")]
        public List<NewFile> Attachments { get; set; } = new List<NewFile>();

    }
}