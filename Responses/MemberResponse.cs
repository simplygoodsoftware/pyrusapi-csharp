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

		[JsonProperty("native_first_name")]
		public string NativeFirstName { get; set; }

		[JsonProperty("native_last_name")]
		public string NativeLastName { get; set; }

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

		[JsonProperty("export_localized_registry_forbidden")]
		public bool? ForbidLocalizedRegistryExport { get; set; }

		[JsonProperty("export_not_localized_registry_forbidden")]
		public bool? ForbidNotLocalizedRegistryExport { get; set; }

		[JsonProperty("localized_registry_access_forbbidden")]
		public bool? ForbidLocalizedRegistryAccess { get; set; }

		[JsonProperty("not_localized_registry_access_forbbidden")]
		public bool? ForbidNotLocalizedRegistryAccess { get; set; }

		[JsonProperty("add_external_users_to_tasks_forbidden")]
		public bool? ForbidAddExternalUsersToTasks { get; set; }

		[JsonProperty("add_external_users_to_projects_forbidden")]
		public bool? ForbidAddExternalUsersToProjects { get; set; }

		public Person Person =>
			new Person
			{ 
				Id = Id,
				FirstName = FirstName,
				LastName = LastName,
				NativeFirstName = NativeFirstName,
				NativeLastName = NativeLastName,
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
				WebSessionInactiveSettings = WebSessionInactiveSettings,
				ForbidAddExternalUsersToProjects = ForbidAddExternalUsersToProjects,
				ForbidAddExternalUsersToTasks = ForbidAddExternalUsersToTasks,
				ForbidLocalizedRegistryAccess = ForbidLocalizedRegistryAccess,
				ForbidNotLocalizedRegistryAccess = ForbidNotLocalizedRegistryAccess,
				ForbidLocalizedRegistryExport = ForbidLocalizedRegistryExport,
				ForbidNotLocalizedRegistryExport = ForbidNotLocalizedRegistryExport,
			};

	}
}
