using Newtonsoft.Json;
using PyrusApiClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pyrus.ApiClient.JsonConverters
{
	public class FormFieldListJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			=> throw new NotImplementedException();


		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader == null)
				throw new ArgumentNullException();
			if (reader.TokenType == JsonToken.Null)
				return null;
			var list = existingValue as List<FormField> ?? (List<FormField>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
			serializer.Populate(reader, list);
			return list.Where(f => f != null).ToList();
		}


		public override bool CanConvert(Type objectType)
			=> objectType == typeof(List<FormField>);
		
		public override bool CanWrite => false;
	}
}



