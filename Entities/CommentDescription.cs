using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests
{
    /// <summary>
    /// Изменение к задаче
    /// </summary>
    public class CommentDescription
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        [JsonProperty("task_id")]
        public int TaskId { get; set; }
        
        /// <summary>
        /// Идентификатор последнего известного изменения
        /// </summary>
        [JsonProperty("previous_note_id")]
        public long PreviousNoteId { get; set; }
        
        /// <summary>
        /// Изменение
        /// </summary>
        [JsonProperty("comment")]
        public TaskCommentRequest Comment { get; set; }
    }
}