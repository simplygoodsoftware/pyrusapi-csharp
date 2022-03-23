using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Данные для автоматического заполнения поля формы Pyrus
    /// </summary>
    public class FormMapping
    {
        /// <summary>
        /// Символьный код поля формы Pyrus
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        
        /// <summary>
        /// Значение для поля в Pyrus
        /// </summary>
        /// <remarks>
        /// Максимальная длина 300 символов
        /// </remarks>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}