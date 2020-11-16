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
		public int DepartmentId { get; set; }

		[JsonProperty("department_name")]
		public string DepartmentName { get; set; }

		public override string ToString()
		{
			return Id?.ToString() ?? Email;
		}
	}
}
