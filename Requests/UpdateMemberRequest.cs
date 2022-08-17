using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;

namespace Pyrus.ApiClient.Requests
{
	public class UpdateMemberRequest
	{
		[JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "banned")]
		public bool? Banned { get; set; }

		[JsonProperty("rights")]
		public PersonRights? Rights { get; set; }

		[JsonProperty(PropertyName = "position")]
		public string Position { get; set; }

		[JsonProperty(PropertyName = "department_id")]
		public int? DepartmentId { get; set; }

		[JsonProperty(PropertyName = "skype")]
		public string Skype { get; set; }

		[JsonProperty(PropertyName = "phone")]
		public string Phone { get; set; }

		[JsonProperty("login_phone")]
		public string LoginPhone { get; set; }

		[JsonProperty("mobile_session_settings")]
		public SessionLifespanUpdate MobileSessionSettings { get; set; }

		[JsonProperty("web_session_settings")]
		public SessionLifespanUpdate WebSessionSettings { get; set; }

		[JsonProperty("mobile_session_inactive_settings")]
		public SessionLifespanUpdate MobileSessionInactiveSettings { get; set; }

		[JsonProperty("web_session_inactive_settings")]
		public SessionLifespanUpdate WebSessionInactiveSettings { get; set; }
	}
}
