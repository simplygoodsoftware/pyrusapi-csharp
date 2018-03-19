using System.Collections.Generic;
using System.Linq;

namespace PyrusApiClient.Builders
{
	internal static class BuilderHelper
	{
		internal static void WriteApprovals(List<Approval> source, List<List<Person>> target)
		{
			var maxStep = source.Max(a => a.Step) ?? -1;
			if (maxStep == -1) return;

			var approvals = new List<List<Person>>();
			for (var i = 0; i < maxStep; i++)
				approvals.Add(new List<Person>());

			foreach (var approval in source)
			{
				if (!approval.Step.HasValue) continue;
				approvals[approval.Step.Value - 1]
					.Add(new Person { Id = approval.Person.Id, Email = approval.Person.Email });
			}

			target.AddRange(approvals);
		}
	}
}
