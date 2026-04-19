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
			if (!Enum.IsDefined(typeof(DueFilterType), type))
				throw new ArgumentOutOfRangeException(nameof(type), type, $"Unknown {nameof(DueFilterType)} value.");
			Type = type;
		}

		public DueFilter(params int[] overdueSteps)
		{
			if (overdueSteps == null) throw new ArgumentNullException(nameof(overdueSteps));
			OverdueSteps = overdueSteps;
		}
	}
}
