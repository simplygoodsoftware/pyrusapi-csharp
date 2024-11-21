using Newtonsoft.Json;
using Pyrus.ApiClient.Enums;
using PyrusApiClient;
using System;

namespace Pyrus.ApiClient.Requests
{
	public class CreateMemberRequest
	{
		[JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("rights")]
		public PersonRights? Rights { get; set; }

		[JsonProperty(PropertyName = "position")]
		public string Position { get; set; }

		[JsonProperty(PropertyName = "department_id")]
		public int? DepartmentId { get; set; }

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

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }
	}
}
