using PyrusApiClient;
using System.Collections.Generic;

namespace Pyrus.ApiClient.Requests.Builders
{
	public class AnnouncementCommentBuilder
	{
		private readonly AnnouncementCommentRequest Announcement;
		internal int AnnouncementId { get; }

		public AnnouncementCommentBuilder(AnnouncementCommentRequest announcement, int announcementId)
		{
			Announcement = announcement;
			AnnouncementId = announcementId;
		}

		public static implicit operator AnnouncementCommentRequest(AnnouncementCommentBuilder builder)
			=> builder.Announcement;

		public AnnouncementCommentBuilder AddAttachment(NewFile attachment)
		{
			Announcement.Attachments.Add(attachment);
			return this;
		}

		public AnnouncementCommentBuilder AddAttachments(IEnumerable<NewFile> attachments)
		{
			Announcement.Attachments.AddRange(attachments);
			return this;
		}

		public AnnouncementCommentBuilder WithText(string text)
		{
			Announcement.Text = text;
			return this;
		}

		public AnnouncementCommentBuilder WithFormattedText(string text)
		{
			Announcement.FormattedText = text;
			return this;
		}
	}
}
