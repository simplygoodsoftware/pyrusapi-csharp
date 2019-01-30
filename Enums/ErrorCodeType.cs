using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	[JsonConverter(typeof(StringEnumWithDefaultConverter), UnknownError)]
	public enum ErrorCodeType
	{
		[EnumMember(Value = "server_error")]
		ServerError = 0,

		//Unauthorized (401)
		[EnumMember(Value = "authorization_error")]
		AuthorizationError = 100,

		[EnumMember(Value = "token_not_specified")]
		TokenNotSpecified = 101,

		[EnumMember(Value = "revoked_token")]
		RevokedToken = 102,

		[EnumMember(Value = "expired_token")]
		ExpiredToken = 103,

		[EnumMember(Value = "invalid_token")]
		InvalidToken = 104,

		[EnumMember(Value = "account_blocked")]
		AccountBlocked = 105,

		[EnumMember(Value = "invalid_credentials")]
		InvalidCredentials = 106,

		//BadRequest (400)

		[EnumMember(Value = "invalid_field_id")]
		InvalidFieldId = 201,

		[EnumMember(Value = "invalid_field_name")]
		InvalidFieldName = 202,

		[EnumMember(Value = "invalid_field_id_name")]
		InvalidFieldIdName = 203,

		[EnumMember(Value = "non_unique_name")]
		NonUniqueName = 204,

		[EnumMember(Value = "field_identity_missing")]
		FieldIdentityMissing = 205,

		[EnumMember(Value = "duplicate_field")]
		DuplicateField = 206,

		[EnumMember(Value = "invalid_catalog_id")]
		InvalidCatalogId = 207,

		[EnumMember(Value = "invalid_catalog_item_name")]
		InvalidCatalogItemName = 208,

		[EnumMember(Value = "non_unique_catalog_item_name")]
		NonUniqueCatalogItemName = 209,

		[EnumMember(Value = "invalid_catalog_item_id")]
		InvalidCatalogItemId = 210,

		[EnumMember(Value = "catalog_item_id_name_mismatch")]
		InvalidCatalogItemIdName = 211,

		[EnumMember(Value = "invalid_email")]
		InvalidEmail = 212,

		[EnumMember(Value = "non_unique_email")]
		NonUniqueEmail = 213,

		[EnumMember(Value = "invalid_person_id_email")]
		InvalidPersonIdEmail = 214,

		[EnumMember(Value = "unrecognized_attachment_id")]
		UnrecognizedAttachmentId = 215,

		[EnumMember(Value = "required_field_missing")]
		RequiredFieldMissing = 216,

		[EnumMember(Value = "type_is_not_supported")]
		FieldTypeIsNotSupported = 217,

		[EnumMember(Value = "incorrect_parameters_count")]
		IncorrectParametersCount = 218,

		[EnumMember(Value = "filter_type_is_not_supported")]
		FilterTypeIsNotSupported = 219,

		[EnumMember(Value = "step_field_does_not_exists")]
		StepFieldDoesNotExists = 220,

		[EnumMember(Value = "no_file_in_request")]
		NoFileInRequest = 221,

		[EnumMember(Value = "too_large_request_length")]
		TooLargeRequestLength = 222,

		[EnumMember(Value = "task_has_no_form")]
		TaskHasNoForm = 223,

		[EnumMember(Value = "required_parameter_missing")]
		RequiredParameterMissing = 224,

		[EnumMember(Value = "invalid_value_format")]
		InvalidValueFormat = 225,

		[EnumMember(Value = "invalid_json")]
		InvalidJson = 226,

		[EnumMember(Value = "empty_body")]
		EmptyBody = 228,

		[EnumMember(Value = "text_missing")]
		TextMissing = 229,

		[EnumMember(Value = "form_id_missing")]
		FormIdMissing = 230,

		[EnumMember(Value = "invalid_person_id")]
		InvalidPersonId = 231,

		[EnumMember(Value = "deleted_field")]
		DeletedField = 232,

		[EnumMember(Value = "person_identity_missing")]
		PersonIdentityMissing = 233,

		[EnumMember(Value = "catalog_identity_missing")]
		CatalogItemIdMissing = 234,

		[EnumMember(Value = "form_has_no_task")]
		FormHasNoTask = 235,

		[EnumMember(Value = "either_due_date_or_due_can_be_set")]
		EitherDueDateOrDueCanBeSet = 236,

		[EnumMember(Value = "negative_duration")]
		NegativeDuration = 237,

		[EnumMember(Value = "duration_is_too_long")]
		DurationIsTooLong = 238,

		[EnumMember(Value = "due_missing")]
		DueMissing = 239,

		[EnumMember(Value = "scheduled_date_in_past")]
		ScheduledDateInPast = 240,

		[EnumMember(Value = "cannot_add_form_project")]
		CannotAddFormProject = 241,

		[EnumMember(Value = "form_template_cant_be_removed_from_task")]
		FormTemplateCantBeRemovedFromTask = 242,

		[EnumMember(Value = "too_many_task_steps")]
		TooManyTaskSteps = 243,

		[EnumMember(Value = "too_many_comments")]
		TooManyComments = 244,

		[EnumMember(Value = "invalid_step_number")]
		InvalidStepNumber = 245,

		[EnumMember(Value = "task_limit_exceeded")]
		TaskLimitExceeded = 246,

		[EnumMember(Value = "field_is_in_table")]
		FieldIsInTable = 247,

		[EnumMember(Value = "required_table_field_missing")]
		RequiredTableFieldMissing = 248,

		[EnumMember(Value = "department_catalog_can_not_be_modified")]
		DepartmentCatalogCanNotBeModified = 249,

		[EnumMember(Value = "catalog_duplicate_rows")]
		CatalogDuplicateItems = 250,

		[EnumMember(Value = "empty_catalog_headers")]
		EmptyCatalogHeaders = 251,

		[EnumMember(Value = "can_not_modify_deleted_catalog")]
		CanNotModifyDeletedCatalog = 252,

		[EnumMember(Value = "catalog_duplicate_headers")]
		CatalogDuplicateHeaders = 253,

		[EnumMember(Value = "can_not_modify_first_column")]
		CanNotModifyFirstColumn = 254,

		[EnumMember(Value = "catalog_headers_items_mismatch")]
		CatalogHeadersItemsMismatch = 255,

		[EnumMember(Value = "too_many_catalog_items")]
		TooManyCatalogItems = 256,

		[EnumMember(Value = "catalog_item_max_length_exceeded")]
		CatalogItemMaxLengthExceeded = 257,

		[EnumMember(Value = "single_value_is_not_supported")]
		SingleValueIsNotSupported = 258,

		[EnumMember(Value = "participant_limit_exceeded")]
		ParticipantLimitExceeded = 259,

		[EnumMember(Value = "table_rows_limit_exceeded")]
		TableRowsLimitExceeded = 260,

		[EnumMember(Value = "text_field_value_limit_exceeded")]
		TextFieldValueLimitExceeded = 261,

		[EnumMember(Value = "unable_to_edit_field")]
		UnableToEditField = 262,

		//Forbidden (403)
		[EnumMember(Value = "access_denied_project")]
		AccessDeniedProject = 301,

		[EnumMember(Value = "access_denied_task")]
		AccessDeniedTask = 302,

		[EnumMember(Value = "access_denied_catalog")]
		AccessDeniedCatalog = 303,

		[EnumMember(Value = "access_denied_form")]
		AccessDeniedForm = 304,

		[EnumMember(Value = "access_denied_person")]
		AccessDeniedPerson = 305,

		[EnumMember(Value = "access_denied_close_task")]
		AccessDeniedCloseTask = 306,

		[EnumMember(Value = "access_denied_reopen_task")]
		AccessDeniedReopenTask = 307,

		[EnumMember(Value = "access_denied_file_access_history")]
		AccessDeniedFileAccessHistory = 308,

		[EnumMember(Value = "access_denied_file")]
		AccessDeniedFile = 309,

		//Too many Requests (429)
		[EnumMember(Value = "too_many_requests")]
		TooManyRequests = 400,

		UnknownError = 999,
	}
}
