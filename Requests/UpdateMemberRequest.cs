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

		[JsonProperty("native_first_name")]
		public string NativeFirstName { get; set; }

		[JsonProperty("native_last_name")]
		public string NativeLastName { get; set; }

		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "banned")]
		public bool? Banned { get; set; }

		[JsonProperty("rights")]
		public PersonRights? Rights { get; set; }

		[JsonProperty(PropertyName = "position")]
		public string Position { get; set; }

		[JsonProperty(PropertyName = "department_id")]
		public long? DepartmentId { get; set; }

		[JsonProperty(PropertyName = "drop_department")]
		public bool? DropDepartment { get; set; }

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
	}
}
