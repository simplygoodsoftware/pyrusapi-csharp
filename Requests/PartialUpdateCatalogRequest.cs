using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class PartialUpdateCatalogRequest
	{
		/// <summary>
		/// Записи каталога для добавления и/или изменения.
		/// </summary>
		[JsonProperty(PropertyName = "upsert")]
		public List<CatalogItem> UpsertItems { get; set; } = new List<CatalogItem>();

		/// <summary>
		/// Значения ключа (первой колонки) записей каталога для удаления.
		/// </summary>
		[JsonProperty(PropertyName = "delete")]
		public List<string> DeleteItems { get; set; } = new List<string>();
	}
}
