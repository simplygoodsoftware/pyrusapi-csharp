using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class RangeTaskIdFilter : FormFilter
	{
		public RangeTaskIdFilter(int fromTaskId, int toTaskId)
			: base(OperatorId.Range, true, fromTaskId, toTaskId)
		{
		}
	}
}
