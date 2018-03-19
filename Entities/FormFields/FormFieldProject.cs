using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldProject : FormField
	{
		[JsonProperty("value")]
		public ProjectArray Value { get; set; }
	}

	public class ProjectArray
	{
		[JsonProperty("projects")]
		public List<Project> Projects { get; set; }
	}


	public class Project
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("parent")]
		public Project Parent { get; set; }
	}

}
