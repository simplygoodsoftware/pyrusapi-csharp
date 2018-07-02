using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldFile : FormField
	{
		[JsonProperty("value")]
		public List<File> Value { get; set; }

		public override string ToString()
		{
			return Value == null || Value.Count == 0
				? ""
				: String.Join(", ", Value.Select(v => v.Name));
		}
	}
}
