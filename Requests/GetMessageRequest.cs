using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
    /// <summary>
    /// Запрос на добавление нового сообщения
    /// </summary>
    public class GetMessageRequest
    {
        /// <summary>
        /// Уникальный идентификатор аккаунта интеграции во внешней системе
        /// </summary>
        /// <remarks>
        /// ID группы в ВКонтакте, имя бота в Telegram, ID бизнес аккаунта Facebook итд
        /// </remarks>
        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }
        
        /// <summary>
        /// Уникальный идентификатор канала для сообщений в интеграции
        /// </summary>
        /// <remarks>
        /// Id чата в телеграм, Id пользователя ВКонтакте и т.д.
        /// Максимальная длина 300 символов
        /// </remarks>
        [JsonProperty(PropertyName = "channel_id")]
        public string ChannelId { get; set; }
        
        /// <summary>
        /// Имя отправителя сообщения
        /// </summary>
        /// <remarks>
        /// Максимальная длина 100 символов
        /// </remarks>
        [JsonProperty(PropertyName = "sender_name")]
        public string SenderName { get; set; }
        
        /// <summary>
        /// Строковый код типа сообщения
        /// </summary>
        /// <remarks>
        /// Коды задаются в поле message_types.code в файле-манифесте интеграции
        /// </remarks>
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        /// <remarks>
        /// Максимальная длина 10 000 символов
        /// </remarks>
        [JsonProperty(PropertyName = "message_text")]
        public string MessageText { get; set; }
        
        /// <summary>
        /// Данные для автоматического заполнения полей формы
        /// </summary>
        [JsonProperty(PropertyName = "mappings")]
        public List<FormMapping> Mappings { get; set; }
        
        /// <summary>
        /// Идентификаторы загруженных на сервер Pyrus файлов вложений
        /// </summary>
        /// <remarks>
        /// Максимум 100 файлов вложений
        /// Загрузить файл и получить его guid можно с помощью метода files/upload
        /// </remarks>
        [JsonProperty(PropertyName = "attachments")]
        public List<Guid> Attachments { get; set; }
    }
}