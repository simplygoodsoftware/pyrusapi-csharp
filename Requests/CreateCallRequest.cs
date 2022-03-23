using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	/// <summary>
	/// Запрос на регистрацию звонка
	/// </summary>
	public class CreateCallRequest
	{
		/// <summary>
		/// Номер телефона оператора, на который был совершён звонок
		/// </summary>
		[JsonProperty(PropertyName = "to")]
		public string To { get; set; }

		/// <summary>
		/// Номер телефона позвонившего
		/// </summary>
		[JsonProperty(PropertyName = "from")]
		public string From { get; set; }

		/// <summary>
		/// Внутренний номер оператора
		/// </summary>
		[JsonProperty(PropertyName = "extension")]
		public string Extension { get; set; }

		/// <summary>
		/// GUID, сгенерированный при подключении интеграции к форме
		/// </summary>
		[JsonProperty(PropertyName = "integration_guid")]
		public Guid IntegrationGuid { get; set; }
	}
}
