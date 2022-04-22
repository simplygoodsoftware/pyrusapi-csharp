using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum DueFilterType
	{
		Unknown,

		///<summary>Entirely overdue tasks</summary>
		[EnumMember(Value = "overdue")]
		Overdue,

		///<summary>Overdue on current step tasks</summary>
		[EnumMember(Value = "overdue_on_step")]
		OverdueOnStep,
		
		///<summary>Both <see cref="Overdue"/> or <see cref="OverdueOnStep"/> tasks</summary>
		[EnumMember(Value = "past_due")]
		PastDue, 
	}
}
