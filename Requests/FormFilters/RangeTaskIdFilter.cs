using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class RangeTaskIdFilter : FormFilter
	{
		public RangeTaskIdFilter(object fromTaskId, object toTaskId)
			: base(OperatorId.Range, true, fromTaskId, toTaskId)
		{
		}
	}
}
