using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;
using System;

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

		[JsonProperty("status")]
		public string Status { get; set; }

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

		[Obsolete]
		[JsonProperty(PropertyName = "skype")]
		public string Skype { get; set; }

		[JsonProperty("messenger")]
		public Messenger Messenger { get; set; }

		[JsonProperty(PropertyName = "phone")]
		public string Phone { get; set; }

		[JsonProperty(PropertyName = "mobile_phone")]
		public string MobilePhone { get; set; }

		[JsonProperty("login_phone")]
		public string LoginPhone { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("personality")]
		public string Personality { get; set; }

		[JsonProperty("personnel_number")]
		public string PersonnelNumber { get; set; }

		[JsonProperty("mobile_session_settings")]
		public SessionLifespanUpdate MobileSessionSettings { get; set; }

		[JsonProperty("web_session_settings")]
		public SessionLifespanUpdate WebSessionSettings { get; set; }

		[JsonProperty("mobile_session_inactive_settings")]
		public SessionLifespanUpdate MobileSessionInactiveSettings { get; set; }

		[JsonProperty("web_session_inactive_settings")]
		public SessionLifespanUpdate WebSessionInactiveSettings { get; set; }

		[JsonProperty("mobile_session_restriction_settings")]
		public SessionRestrictionUpdate MobileSessionRestrictionSettings { get; set; }

		[JsonProperty("web_session_restriction_settings")]
		public SessionRestrictionUpdate WebSessionRestrictionSettings { get; set; }

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

		[JsonProperty("two_factor_auth")]
		public bool? TwoFactorAuth { get; set; }
	}
}
