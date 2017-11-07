using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PyrusApiClient;
using PyrusApiClient.Extensions;

namespace Pyrus.ApiClient.JsonConverters
{
	public class FormFieldJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			if (obj == null)
				return null;

			var formFieldType = obj[typeof(FormField).GetPropertyAttribute<JsonPropertyAttribute>(nameof(FormField.Type)).PropertyName].ToString();

			if (formFieldType == FormFieldType.Text.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldText>();

			if (formFieldType == FormFieldType.Flag.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldFlag>();

			if (formFieldType == FormFieldType.Number.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldNumber>();

			if (formFieldType == FormFieldType.Money.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldMoney>();

			if (formFieldType == FormFieldType.Project.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldProject>();

			if (formFieldType == FormFieldType.Person.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldPerson>();

			if (formFieldType == FormFieldType.Date.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldDate>();

			if (formFieldType == FormFieldType.Title.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldTitle>(serializer);

			if (formFieldType == FormFieldType.CreationDate.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldCreateDate>();

			if (formFieldType == FormFieldType.MultipleChoice.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldMultipleChoice>();

			if (formFieldType == FormFieldType.DueDate.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldDueDate>();

			if (formFieldType == FormFieldType.Status.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldStatus>();

			if (formFieldType == FormFieldType.Author.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldAuthor>();

			if (formFieldType == FormFieldType.Time.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldTime>();

			if (formFieldType == FormFieldType.Note.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldNote>();

			if (formFieldType == FormFieldType.Checkmark.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldCheckmark>();

			if (formFieldType == FormFieldType.Phone.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldPhone>();

			if (formFieldType == FormFieldType.Step.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldStep>();

			if (formFieldType == FormFieldType.File.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldFile>();

			if (formFieldType == FormFieldType.Catalog.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldCatalog>();

			if (formFieldType == FormFieldType.Email.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldEmail>();

			if (formFieldType == FormFieldType.Table.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldTable>(serializer);

			if (formFieldType == FormFieldType.FormLink.GetAttribute<EnumMemberAttribute>().Value)
				return obj.ToObject<FormFieldFormLink>(serializer);

			return null;
		}
		
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(FormField);
		}

		public override bool CanWrite => false;
	}
}
