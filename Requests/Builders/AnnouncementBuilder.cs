using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class AnnouncementBuilder
	{
		private readonly AnnouncementRequest Announcement;

		public AnnouncementBuilder(AnnouncementRequest announcement)
		{
			Announcement = announcement;
		}

		public static implicit operator AnnouncementRequest(AnnouncementBuilder builder)
			=> builder.Announcement;

		public AnnouncementBuilder AddAttachment(NewFile attachment)
		{
			Announcement.Attachments.Add(attachment);
			return this;
		}

		public AnnouncementBuilder AddAttachments(IEnumerable<NewFile> attachments)
		{
			Announcement.Attachments.AddRange(attachments);
			return this;
		}

		public AnnouncementBuilder WithFormattedText(string text)
		{
			Announcement.FormattedText = text;
			return this;
		}
	}
}
