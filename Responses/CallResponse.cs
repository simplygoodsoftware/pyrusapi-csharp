using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Результат выполнения запроса для регистрации в Pyrus звонка из системы API-телефонии
    /// </summary>
    public class CallResponse : ResponseBase
    {
        /// <summary>
        /// ID созданной задачи
        /// </summary>
        [JsonProperty("task_id")]
        public int TaskId { get; set; }
    }
}