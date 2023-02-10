using System;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public sealed class DueFilter
	{
		[JsonIgnore]
		internal DueFilterType Type { get; }

		[JsonProperty("overdue_steps")]
		public int[] OverdueSteps { get; }

		public DueFilter(DueFilterType type)
		{
			Type = Enum.IsDefined(typeof(DueFilterType), type)
				? type
				: default;
		}

		public DueFilter(params int[] overdueSteps)
		{
			OverdueSteps = overdueSteps;
		}
	}
}
