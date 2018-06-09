using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PyrusApiClient;
using PyrusApiClient.Exceptions;
using PyrusApiClient.Extensions;

namespace Pyrus.ApiClient.JsonConverters
{
	internal class FormRegisterRequestJsonConverter: JsonConverter
	{
		private static readonly Dictionary<string, string> JsonNames;

		static FormRegisterRequestJsonConverter()
		{
			JsonNames = new Dictionary<string, string>();

			var properties = typeof(FormRegisterRequest).GetProperties().Where(prop => prop.IsDefined(typeof(JsonPropertyAttribute), false));
			foreach (var propertyInfo in properties)
			{
				if (propertyInfo.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() is JsonPropertyAttribute attribute)
					JsonNames.Add(propertyInfo.Name, attribute.PropertyName);
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (!(value is FormRegisterRequest request))
				return;

			writer.WriteStartObject();

			if (request.IncludeArchived == true)
			{
				writer.WritePropertyName(JsonNames[nameof(request.IncludeArchived)]);
				serializer.Serialize(writer, "y");
			}

			if (request.Steps != null && request.Steps.Count != 0)
			{
				var steps = string.Join(",", request.Steps);
				writer.WritePropertyName(JsonNames[nameof(request.Steps)]);
				serializer.Serialize(writer, steps);
			}

			if (request.Filters != null && request.Filters.Count != 0)
			{
				foreach (var filter in request.Filters)
				{
					writer.WritePropertyName($"fld{filter.FieldId}");
					var filterValue = GetFilterValue(filter.OperatorId, filter.Values);
					serializer.Serialize(writer, filterValue);
				}
			}

			if (request.ModifiedBefore.HasValue)
			{
				writer.WritePropertyName(JsonNames[nameof(request.ModifiedBefore)]);
				serializer.Serialize(writer, request.ModifiedBefore.Value);
			}

			if (request.ModifiedAfter.HasValue)
			{
				writer.WritePropertyName(JsonNames[nameof(request.ModifiedAfter)]);
				serializer.Serialize(writer, request.ModifiedAfter.Value);
			}

			writer.WriteEndObject();
		}

		private string GetFilterValue(OperatorId operatorId, string[] values)
		{
			if (values.Length == 0)
			{
				return null;
			}

			switch (operatorId)
			{
				case OperatorId.Equals:
				case OperatorId.MatchPrefix:
					if (values.Length > 1)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can not have more than one value");	

					return values[0];
				case OperatorId.LessThan:
					if (values.Length > 1)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can not have more than one value");

					return $"lt{values[0]}";
				case OperatorId.GreaterThan:
					if (values.Length > 1)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can not have more than one value");

					return $"gt{values[0]}";
				case OperatorId.IsIn:
					return string.Join(",", values);
				case OperatorId.Range:
					if (values.Length != 2)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can have only two values");

					return $"gt{values[0]},lt{values[1]}";
				default:
					return null;
			}
		}


		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(FormRegisterRequest);
		}

		public override bool CanRead => false;
	}
}
