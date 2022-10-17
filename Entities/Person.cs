using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;

namespace PyrusApiClient
{
	public class Person
	{
		public Person()
		{
		}

		public Person(int id)
		{
			Id = id;
		}

		public Person(string email)
		{
			Email = email;
		}

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
		public PersonRights? Rights { get; set; }

		[JsonProperty("type")]
		public PersonType Type { get; set; }

		[JsonProperty("department_id")]
		public long? DepartmentId { get; set; }

		[JsonProperty("department_name")]
		public string DepartmentName { get; set; }

		[JsonProperty("banned")]
		public bool? Banned { get; set; }

		[JsonProperty("fired")]
		public bool Fired { get; set; }

		[JsonProperty("task_receiver")]
		public int? TaskReceiver { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

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

		[JsonProperty("cant_view_restricted_form_registry")]
		public bool? CantViewRestrictedFormRegistry { get; set; }

		[JsonProperty("cant_view_form_registry")]
		public bool? CantViewFormRegistry { get; set; }

		[JsonProperty("cant_export_restricted_form_registry")]
		public bool? CantExportRestrictedFormRegistry { get; set; }

		[JsonProperty("cant_export_form_registry")]
		public bool? CantExportFormRegistry { get; set; }

		[JsonProperty("cant_add_external_users_to_tasks")]
		public bool? CantAddExternalUsersToTasks { get; set; }

		[JsonProperty("cant_add_external_users_to_lists")]
		public bool? CantAddExternalUsersToLists { get; set; }

		public override string ToString() => Id?.ToString() ?? Email;
	}
}
