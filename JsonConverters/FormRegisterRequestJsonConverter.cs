using System;
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
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var request = value as FormRegisterRequest;
			if (request == null)
			{
				return;
			}

			writer.WriteStartObject();

			if (request.IncludeArchived == true)
			{
				writer.WritePropertyName(request.GetPropertyAttribute<JsonPropertyAttribute>(nameof(request.IncludeArchived)).PropertyName);
				serializer.Serialize(writer, "y");
			}

			if (request.Steps != null && request.Steps.Length != 0)
			{
				var steps = String.Join(",", request.Steps);
				writer.WritePropertyName(request.GetPropertyAttribute<JsonPropertyAttribute>(nameof(request.Steps)).PropertyName);
				serializer.Serialize(writer, steps);
			}

			if (request.Filters != null && request.Filters.Count != 0)
			{
				foreach (var filter in request.Filters)
				{
					writer.WritePropertyName($"fld{filter.FieldId}");
					string filterValue = GetFilterValue(filter.OperatorId, filter.Values);
					serializer.Serialize(writer, filterValue);
				}
			}

			writer.WriteEndObject();
		}

		private string GetFilterValue(OperatorId operatorId, FilterValue[] values)
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

					return values[0].Value;
				case OperatorId.LessThan:
					if (values.Length > 1)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can not have more than one value");

					return $"lt{values[0].Value}";
				case OperatorId.GreaterThan:
					if (values.Length > 1)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can not have more than one value");

					return $"gt{values[0].Value}";
				case OperatorId.IsIn:
					return string.Join(",", values.Select(v => v.Value));
				case OperatorId.Range:
					if (values.Length != 2)
						throw new InvalidParametersCountException($"Operator {operatorId.GetAttribute<EnumMemberAttribute>().Value} can have only two values");

					return $"gt{values[0].Value},lt{values[1].Value}";
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
