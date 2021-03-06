﻿using System;
using Newtonsoft.Json;
using Pyrus.ApiClient.JsonConverters;

namespace PyrusApiClient
{
	public class FormFieldDueDate : FormField
	{
		public FormFieldDueDate()
		{
		}

		public FormFieldDueDate(int id, DateTime value)
		{
			Id = id;
			Value = value;
		}

		[JsonConverter(typeof(DateTimeJsonConverter), Constants.DateFormat)]
		[JsonProperty("value")]
		public DateTime? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.ToString(Constants.DateTimeFormat)}";
		}
	}
}
