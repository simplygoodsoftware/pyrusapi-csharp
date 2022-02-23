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
				WriteCustomBool(writer, serializer, nameof(request.IncludeArchived));

			if (request.Steps?.Count > 0)
			{
				var steps = string.Join(",", request.Steps);
				writer.WritePropertyName(JsonNames[nameof(request.Steps)]);
				serializer.Serialize(writer, steps);
			}

			if (request.TaskIds?.Count > 0)
			{
				var taskIds = string.Join(",", request.TaskIds);
				writer.WritePropertyName(JsonNames[nameof(request.TaskIds)]);
				serializer.Serialize(writer, taskIds);
			}

			if (request.Filters != null && request.Filters.Count != 0)
				WriteFilters(writer, serializer, request);

			if (request.ModifiedBefore.HasValue)
				WriteDate(writer, nameof(request.ModifiedBefore), request.ModifiedBefore.Value);
			if (request.ModifiedAfter.HasValue)
				WriteDate(writer, nameof(request.ModifiedAfter), request.ModifiedAfter.Value);
			if (request.CreatedBefore.HasValue)
				WriteDate(writer, nameof(request.CreatedBefore), request.CreatedBefore.Value);
			if (request.CreatedAfter.HasValue)
				WriteDate(writer, nameof(request.CreatedAfter), request.CreatedAfter.Value);
			if (request.ClosedBefore.HasValue)
				WriteDate(writer, nameof(request.ClosedBefore), request.ClosedBefore.Value);
			if (request.ClosedAfter.HasValue)
				WriteDate(writer, nameof(request.ClosedAfter), request.ClosedAfter.Value);

			if (request.ResponseFormat == ResponseFormat.Csv)
			{
				writer.WritePropertyName(JsonNames[nameof(request.ResponseFormat)]);
				writer.WriteValue("csv");
			}

			if (!string.IsNullOrEmpty(request.Delimiter))
				WriteString(writer, nameof(request.Delimiter), request.Delimiter);

			if (request.SimpleFormat)
				WriteCustomBool(writer, serializer, nameof(request.SimpleFormat));

			if (!string.IsNullOrEmpty(request.Encoding))
				WriteString(writer, nameof(request.Encoding), request.Encoding);

			if (request.FieldIds?.Count > 0)
			{
				var fieldIds = string.Join(",", request.FieldIds);
				writer.WritePropertyName(JsonNames[nameof(request.FieldIds)]);
				serializer.Serialize(writer, fieldIds);
			}

			writer.WriteEndObject();
		}

		private static void WriteCustomBool(JsonWriter writer, JsonSerializer serializer, string propertyName)
		{
			writer.WritePropertyName(JsonNames[propertyName]);
			serializer.Serialize(writer, "y");
		}

		private static void WriteString(JsonWriter writer, string propertyName, string propertyValue)
		{
			writer.WritePropertyName(JsonNames[propertyName]);
			writer.WriteValue(propertyValue);
		}

		private static void WriteDate(JsonWriter writer, string propertyName, DateTime propertyValue)
		{
			writer.WritePropertyName(JsonNames[propertyName]);
			writer.WriteValue(propertyValue.ToUniversalTime().ToString(Constants.DateTimeFormat));
		}

		private void WriteFilters(JsonWriter writer, JsonSerializer serializer, FormRegisterRequest request)
		{
			foreach (var filter in request.Filters)
			{
				writer.WritePropertyName($"fld{filter.FieldId}");
				var filterValue = GetFilterValue(filter.OperatorId, filter.Values);
				serializer.Serialize(writer, filterValue);
			}
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
