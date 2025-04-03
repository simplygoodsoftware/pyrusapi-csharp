using PyrusApiClient;
using System.Collections.Generic;
using System.Linq;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class IsInTaskIdFilter : FormFilter
	{
		public IsInTaskIdFilter(IEnumerable<object> values)
			:base(OperatorId.IsIn, true, values.ToArray())
		{
		}
	}
}
