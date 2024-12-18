﻿using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;
using System;

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

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("avatar_id")]
		public int? AvatarId { get; set; }

		[JsonProperty("external_avatar_id")]
		public int? ExternalAvatarId { get; set; }

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

		[Obsolete]
		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("messenger")]
		public Messenger Messenger { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("mobile_phone")]
		public string MobilePhone { get; set; }

		[JsonProperty("login_phone")]
		public string LoginPhone { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("personality")]
		public string Personality { get; set; }

		[JsonProperty("personnel_number")]
		public string PersonnelNumber { get; set; }

		[JsonProperty("vacation_days")]
		public int? VacationDays { get; set; }

		[JsonProperty("mobile_session_settings")]
		public SessionLifespan MobileSessionSettings { get; set; }

		[JsonProperty("web_session_settings")]
		public SessionLifespan WebSessionSettings { get; set; }

		[JsonProperty("mobile_session_inactive_settings")]
		public SessionLifespan MobileSessionInactiveSettings { get; set; }

		[JsonProperty("web_session_inactive_settings")]
		public SessionLifespan WebSessionInactiveSettings { get; set; }

		[JsonProperty("mobile_session_restriction_settings")]
		public SessionRestriction MobileSessionRestrictionSettings { get; set; }

		[JsonProperty("web_session_restriction_settings")]
		public SessionRestriction WebSessionRestrictionSettings { get; set; }

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
				Status = Status,
				AvatarId = AvatarId,
				ExternalAvatarId = ExternalAvatarId,
				Banned = Banned,
				Position = Position,
#pragma warning disable CS0612 // Type or member is obsolete
				Skype = Skype,
#pragma warning restore CS0612 // Type or member is obsolete
				Messenger = Messenger,
				Phone = Phone,
				MobilePhone = MobilePhone,
				LoginPhone = LoginPhone,
				Location = Location,
				Personality = Personality,
				PersonnelNumber = PersonnelNumber,
				VacationDays = VacationDays,
				MobileSessionSettings = MobileSessionSettings,
				WebSessionSettings = WebSessionSettings,
				MobileSessionInactiveSettings = MobileSessionInactiveSettings,
				WebSessionInactiveSettings = WebSessionInactiveSettings,
				MobileSessionRestrictionSettings = MobileSessionRestrictionSettings,
				WebSessionRestrictionSettings = WebSessionRestrictionSettings,
				CantAddExternalUsersToLists = CantAddExternalUsersToLists,
				CantAddExternalUsersToTasks = CantAddExternalUsersToTasks,
				CantExportRestrictedFormRegistry = CantExportRestrictedFormRegistry,
				CantExportFormRegistry = CantExportFormRegistry,
				CantViewFormRegistry = CantViewFormRegistry,
				CantViewRestrictedFormRegistry = CantViewRestrictedFormRegistry,
				TwoFactorAuth = TwoFactorAuth,
			};
	}
}
