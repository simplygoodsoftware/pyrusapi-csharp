using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Entities
{
    public class CommentDescription
    {
        [JsonProperty("task_id")]
        public int TaskId { get; set; }

        [JsonProperty("previous_note_id")]
        public long PreviousNoteId { get; set; }

        [JsonProperty("comment")]
        public TaskCommentRequest TaskChangeRequest { get; set; }
    }
}
