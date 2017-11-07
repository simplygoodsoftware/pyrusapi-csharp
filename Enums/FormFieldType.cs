using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum FormFieldType
	{
		[EnumMember(Value = "unknown")]
		Unknown = 0,

		[EnumMember(Value = "text")]
		Text = 1,

		[EnumMember(Value = "money")]
		Money = 2,

		[EnumMember(Value = "number")]
		Number = 3,

		[EnumMember(Value = "date")]
		Date = 4,

		[EnumMember(Value = "time")]
		Time = 5,

		[EnumMember(Value = "checkmark")]
		Checkmark = 6,

		[EnumMember(Value = "multiple_choice")]
		MultipleChoice = 7,

		[EnumMember(Value = "due_date")]
		DueDate = 8,

		[EnumMember(Value = "email")]
		Email = 9,

		[EnumMember(Value = "phone")]
		Phone = 10,

		[EnumMember(Value = "flag")]
		Flag = 11,

		[EnumMember(Value = "step")]
		Step = 12,

		[EnumMember(Value = "status")]
		Status = 13,

		[EnumMember(Value = "creation_date")]
		CreationDate = 14,

		[EnumMember(Value = "note")]
		Note = 15,

		[EnumMember(Value = "catalog")]
		Catalog = 16,

		[EnumMember(Value = "file")]
		File = 17,

		[EnumMember(Value = "person")]
		Person = 18,

		[EnumMember(Value = "author")]
		Author = 19,

		[EnumMember(Value = "table")]
		Table = 20,

		[EnumMember(Value = "title")]
		Title = 21,

		[EnumMember(Value = "project")]
		Project = 22,

		[EnumMember(Value = "form_link")]
		FormLink = 23
	}
}
