using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
    public class InboxRequest
    {
        [JsonProperty("item_count")]
        public int TasksCount { get; set; }

        [JsonProperty("group_item_count")]
        public int GroupTasksCount { get; set; }

        public override string ToString()
        {
            return string.Join(
                "&",
                $"item_count={TasksCount}",
                $"group_item_count={GroupTasksCount}");
        }
    }
}
