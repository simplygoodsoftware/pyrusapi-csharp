using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class LessThanTaskIdFilter : FormFilter
	{
		public LessThanTaskIdFilter(int value)
			: base(OperatorId.LessThan, true, value)
		{
		}
	}
}
