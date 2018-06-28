using System;

namespace PyrusApiClient
{
	public class FormFieldCreateDate : FormField
	{
		public DateTime? Value { get; set; }

		public override string ToString()
		{
			return $"{Value?.ToString(Constants.DateTimeFormat)}";
		}
	}
}
