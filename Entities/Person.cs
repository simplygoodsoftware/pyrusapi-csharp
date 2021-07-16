using Newtonsoft.Json;

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

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		public override string ToString() => Id?.ToString() ?? Email;
	}
}
