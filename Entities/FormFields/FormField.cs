using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormField
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumWithDefaultConverter), FormFieldType.Unknown)]
		public FormFieldType? Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("info")]
		public FormFieldInfo Info { get; set; }

		public static TField Create<TField>(int id)
			where TField : FormField, new()
		{
			ValidateFieldType(typeof(TField));
			return new TField { Id = id };
		}

		public static TField Create<TField>(string name)
			where TField : FormField, new()
		{
			ValidateFieldType(typeof(TField));
			return new TField { Name = name };
		}

		private static void ValidateFieldType(Type type)
		{
			var readOnlyTypes = new List<Type>
			{
				typeof(FormFieldCreateDate),
				typeof(FormFieldNote),
				typeof(FormField),
				typeof(FormFieldProject),
				typeof(FormFieldStep),
				typeof(FormFieldStatus),
			};
			if (readOnlyTypes.Contains(type))
				throw new ArgumentException($"Writing value to the type {type.Name} is not supported");
			if (type == typeof(FormFieldFile))
				throw new ArgumentException($"{nameof(FormFieldFile)} can not be used to write value. Please use {nameof(FormFieldNewFile)} instead.");
		}
	}
}
