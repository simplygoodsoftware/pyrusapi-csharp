using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("steps")]
		public Dictionary<int, string> Steps { get; set; }

		[JsonProperty("fields")]
		public List<FormField> Fields { get; set; }

		[JsonProperty("print_forms")]
		public List<PrintForm> PrintForms { get; set; }

		[JsonProperty("deleted_or_closed")]
		public bool DeletedOrClosed { get; set; }

		[JsonIgnore]
		public List<FormField> FlatFields => FieldHelper.GetFlatFieldsByForm(Fields);
	}
}
 