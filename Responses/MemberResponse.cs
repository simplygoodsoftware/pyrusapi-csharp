using Newtonsoft.Json;
using PyrusApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			};

	}
}
