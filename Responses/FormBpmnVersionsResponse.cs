using System.Collections.Generic;
using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class FormBpmnVersionsResponse : ResponseBase
	{
		[JsonProperty("form_id")]
		public int FormId { get; set; }

		[JsonProperty("active_bpmn_version")]
		public int? ActiveBpmnVersion { get; set; }

		[JsonProperty("versions")]
		public List<BpmnDiagramVersionInfo> Versions { get; set; }
	}
}
