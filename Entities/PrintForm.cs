using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class PrintForm
	{
		[JsonProperty("print_form_id")]
		public Int32? PrintFormId { get; set; }

		[JsonProperty("print_form_name")]
		public String Name { get; set; }
	}
}
