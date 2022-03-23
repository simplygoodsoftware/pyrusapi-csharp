using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pyrus.ApiClient.Requests
{
    /// <summary>
    /// Запрос на изменение нескольких задач
    /// </summary>
    public class MultipleTasksChangeRequest
    {
        /// <summary>
        /// Не возвращать задачи в ответе
        /// </summary>
        [JsonProperty("no_tasks_in_response")]
        public bool NoTasksInResponse { get; set; }
        
        /// <summary>
        /// Изменения к задачам
        /// </summary>
        [JsonProperty("comments")]
        public List<CommentDescription> Comments { get; set; }
    }
}