using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldProject : FormField
	{
		[JsonProperty("value")]
		public ProjectArray Value { get; set; }

		public override string ToString()
		{
			
			return Value?.Projects == null || Value.Projects.Count == 0
				? ""
				: String.Join(", ", Value.Projects.Select(p => p.Name));
		}
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
