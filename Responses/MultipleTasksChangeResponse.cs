using Newtonsoft.Json;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests
{
    /// <summary>
    /// Результат выполнения запроса на изменение нескольких задач
    /// </summary>
    public class MultipleTasksChangeResponse : ResponseBase
    {
        /// <summary>
        /// Задачи после изменения
        /// </summary>
        [JsonProperty("tasks")]
        public Task[] Tasks { get; set; }
    }
}