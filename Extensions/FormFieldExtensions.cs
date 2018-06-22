using System;
using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient
{
	public static class FormFieldExtensions
	{
		public static FormFieldAuthor WithValue(this FormFieldAuthor formField, Person person)
		{
			formField.Value = person;
			return formField;
		}

		public static FormFieldAuthor WithValue(this FormFieldAuthor formField, int? personId)
		{
			formField.Value = personId.HasValue ? new Person(personId.Value) : null;
			return formField;
		}

		public static FormFieldAuthor WithValue(this FormFieldAuthor formField, string email)
		{
			formField.Value = !string.IsNullOrEmpty(email) ? new Person(email) : null;
			return formField;
		}

		public static FormFieldCatalog WithValue(this FormFieldCatalog formField, long? itemId)
		{
			formField.Value = itemId.HasValue ? new Catalog { ItemId = itemId.Value } : null;
			return formField;
		}

		public static FormFieldCheckmark WithValue(this FormFieldCheckmark formField, Checkmark? checkmark)
		{
			formField.Value = checkmark;
			return formField;
		}

		public static FormFieldDate WithValue(this FormFieldDate formField, DateTime? date)
		{
			formField.Value = date;
			return formField;
		}

		public static FormFieldDueDate WithValue(this FormFieldDueDate formField, DateTime? dueDate)
		{
			formField.Value = dueDate;
			return formField;
		}

		public static FormFieldDueDateTime WithValue(this FormFieldDueDateTime formField, DateTime? dueDate)
		{
			formField.Value = dueDate;
			return formField;
		}

		public static FormFieldEmail WithValue(this FormFieldEmail formField, string email)
		{
			formField.Value = email;
			return formField;
		}

		public static FormFieldFlag WithValue(this FormFieldFlag formField, Flag flag)
		{
			formField.Value = flag;
			return formField;
		}

		public static FormFieldFormLink WithValue(this FormFieldFormLink formField, int? taskId)
		{
			formField.Value = taskId.HasValue ?  new FormLink { TaskId = taskId } : null;
			return formField;
		}

		public static FormFieldMoney WithValue(this FormFieldMoney formField, decimal? money)
		{
			formField.Value = money;
			return formField;
		}

		public static FormFieldMultipleChoice WithChoice(this FormFieldMultipleChoice formField, int? choiceId)
		{
			formField.Value.ChoiceId = choiceId;
			return formField;
		}

		public static FormFieldMultipleChoice WithValue(this FormFieldMultipleChoice formField, int? choiceId, IEnumerable<FormField> fields)
		{
			formField.Value.ChoiceId = choiceId;
			formField.Value.Fields = fields?.ToList() ?? new List<FormField>();
			return formField;
		}

		public static FormFieldMultipleChoice WithFields(this FormFieldMultipleChoice formField, IEnumerable<FormField> fields)
		{
			formField.Value.Fields = fields?.ToList() ?? new List<FormField>();
			return formField;
		}

		public static FormFieldMultipleChoice WithField(this FormFieldMultipleChoice formField, FormField field)
		{
			formField.Value.Fields = new List<FormField> { field };
			return formField;
		}

		public static FormFieldMultipleChoice AddField(this FormFieldMultipleChoice formField, FormField field)
		{
			formField.Value.Fields.Add(field);
			return formField;
		}

		public static FormFieldMultipleChoice AddFields(this FormFieldMultipleChoice formField, IEnumerable<FormField> fields)
		{
			formField.Value.Fields.AddRange(fields);
			return formField;
		}

		public static FormFieldNewFile WithValue(this FormFieldNewFile formField, string guid)
		{
			formField.Value = new List<string> { guid };
			return formField;
		}

		public static FormFieldNewFile WithValue(this FormFieldNewFile formField, Guid guid)
		{
			formField.Value = new List<string> { guid.ToString() };
			return formField;
		}

		public static FormFieldNewFile WithValue(this FormFieldNewFile formField, IEnumerable<string> guids)
		{
			formField.Value = guids.ToList();
			return formField;
		}
		public static FormFieldNewFile WithValue(this FormFieldNewFile formField, IEnumerable<Guid> guids)
		{
			formField.Value = guids.Select(guid => guid.ToString()).ToList();
			return formField;
		}

		public static FormFieldNewFile AddValue(this FormFieldNewFile formField, string guid)
		{
			formField.Value.Add(guid);
			return formField;
		}

		public static FormFieldNewFile AddValue(this FormFieldNewFile formField, Guid guid)
		{
			formField.Value.Add(guid.ToString());
			return formField;
		}

		public static FormFieldNewFile AddValues(this FormFieldNewFile formField, IEnumerable<string> guids)
		{
			formField.Value.AddRange(guids);
			return formField;
		}
		public static FormFieldNewFile AddValues(this FormFieldNewFile formField, IEnumerable<Guid> guids)
		{
			formField.Value.AddRange(guids.Select(guid => guid.ToString()));
			return formField;
		}

		public static FormFieldNumber WithValue(this FormFieldNumber formFiled, decimal? number)
		{
			formFiled.Value = number;
			return formFiled;
		}

		public static FormFieldPerson WithValue(this FormFieldPerson formField, Person person)
		{
			formField.Value = person;
			return formField;
		}

		public static FormFieldPerson WithValue(this FormFieldPerson formField, int? personId)
		{
			formField.Value = personId.HasValue ? new Person(personId.Value) : null;
			return formField;
		}

		public static FormFieldPerson WithValue(this FormFieldPerson formField, string email)
		{
			formField.Value = !string.IsNullOrEmpty(email) ? new Person(email) : null;
			return formField;
		}

		public static FormFieldPhone WithValue(this FormFieldPhone formField, string phone)
		{
			formField.Value = phone;
			return formField;
		}

		public static FormFieldTable AddRow(this FormFieldTable formField, TableRow row)
		{
			formField.Value.Add(row);
			return formField;
		}

		public static FormFieldTable AddRow(this FormFieldTable formField, int rowId, IEnumerable<FormField> cells)
		{
			formField.Value.Add(new TableRow(rowId, cells));
			return formField;
		}

		public static FormFieldTable AddRows(this FormFieldTable formField, IEnumerable<TableRow> rows)
		{
			formField.Value.AddRange(rows);
			return formField;
		}

		public static FormFieldTable WithValue(this FormFieldTable formField, IEnumerable<TableRow> rows)
		{
			formField.Value = rows?.ToList() ?? new List<TableRow>();
			return formField;
		}

		public static FormFieldText WithValue(this FormFieldText formField, string text)
		{
			formField.Value = text;
			return formField;
		}

		public static FormFieldTime WithValue(this FormFieldTime formField, string time)
		{
			formField.Value = time;
			return formField;
		}

		public static FormFieldTime WithValue(this FormFieldTime formField, DateTime? time)
		{
			formField.Value = time?.ToString("HH:mm");
			return formField;
		}

		public static FormFieldTitle WithValue(this FormFieldTitle formField, Title title)
		{
			formField.Value = title;
			return formField;
		}

		public static FormFieldTitle WithCheckmark(this FormFieldTitle formField, Checkmark checkmark)
		{
			formField.Value.Checkmark = checkmark;
			return formField;
		}

		public static FormFieldTitle AddFields(this FormFieldTitle formField, IEnumerable<FormField> fields)
		{
			formField.Value.Fields.AddRange(fields.ToList());
			return formField;
		}

		public static FormFieldTitle AddField(this FormFieldTitle formFieldTilte, FormField formField)
		{
			formFieldTilte.Value.Fields.Add(formField);
			return formFieldTilte;
		}

		public static FormFieldTitle WithFields(this FormFieldTitle formField, IEnumerable<FormField> fields)
		{
			formField.Value.Fields = fields.ToList();
			return formField;
		}

		public static FormFieldTitle WithField(this FormFieldTitle formField, FormField field)
		{
			formField.Value.Fields = new List<FormField> { field };
			return formField;
		}
	}
}