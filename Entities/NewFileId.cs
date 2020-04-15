using Newtonsoft.Json;

namespace PyrusApiClient
{
	public class NewFileId : NewFile
	{
		[JsonProperty("attachment_id")]
		public int AttachmentId { get; set; }
	}
}
