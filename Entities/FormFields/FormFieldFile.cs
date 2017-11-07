using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormFieldFile : FormField
	{
		[JsonProperty("value")]
		public File[] Value { get; set; }
	}

	public class FormFieldNewFile : FormField
	{
		[JsonProperty("value")]
		public IEnumerable<string> Value { get; set; }

		public FormFieldNewFile(int id, IEnumerable<string> files)
		{
			Id = id;
			Value = files;
		}

		public FormFieldNewFile(int id, IEnumerable<Guid> files)
		{
			Id = id;
			Value = files.Select(f => f.ToString()).ToArray();
		}

		public FormFieldNewFile(string name, IEnumerable<string> files)
		{
			Name = name;
			Value = files;
		}

		public FormFieldNewFile(string name, IEnumerable<Guid> files)
		{
			Name = name;
			Value = files.Select(f => f.ToString()).ToArray();
		}
	}


	public class File
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("size")]
		public long Size { get; set; }

		[JsonProperty("md5")]
		public string MD5 { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
