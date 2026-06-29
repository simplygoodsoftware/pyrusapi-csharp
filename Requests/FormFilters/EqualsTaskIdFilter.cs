using PyrusApiClient;

namespace Pyrus.ApiClient.Requests.FormFilters
{
	public class EqualsTaskIdFilter : FormFilter
	{
		public EqualsTaskIdFilter(int value)
			: base(OperatorId.Equals, true, value)
		{

		}
	}
}
