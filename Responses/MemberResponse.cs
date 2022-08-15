using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;

namespace Pyrus.ApiClient.Responses
{
	public class MemberResponse : ResponseBase
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("rights")]
		public PersonRights Rights { get; set; }

		[JsonProperty("type")]
		public PersonType Type { get; set; }

		[JsonProperty("department_id")]
		public int? DepartmentId { get; set; }

		[JsonProperty("department_name")]
		public string DepartmentName { get; set; }

		[JsonProperty("banned")]
		public bool? Banned { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("login_phone")]
		public string LoginPhone { get; set; }

		[JsonProperty("mobile_session_settings")]
		public SessionLifespan MobileSessionSettings { get; set; }

		[JsonProperty("web_session_settings")]
		public SessionLifespan WebSessionSettings { get; set; }

		[JsonProperty("mobile_session_inactive_settings")]
		public SessionLifespan MobileSessionInactiveSettings { get; set; }

		[JsonProperty("web_session_inactive_settings")]
		public SessionLifespan WebSessionInactiveSettings { get; set; }

		public Person Person =>
			new Person
			{ 
				Id = Id,
				FirstName = FirstName,
				LastName = LastName,
				Email = Email,
				Type = Type,
				DepartmentId = DepartmentId,
				DepartmentName = DepartmentName,
				Banned = Banned,
				Position = Position,
				Skype = Skype,
				Phone = Phone,
				LoginPhone = LoginPhone,
				MobileSessionSettings = MobileSessionSettings,
				WebSessionSettings = WebSessionSettings,
				MobileSessionInactiveSettings = MobileSessionInactiveSettings,
				WebSessionInactiveSettings = WebSessionInactiveSettings
			};

	}
}
