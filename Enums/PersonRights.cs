using System;
using System.Runtime.Serialization;

namespace Pyrus.ApiClient.Enums
{
	[Flags]
	[DataContract]
	public enum PersonRights
	{
		[EnumMember]
		None = 0x0,

		[EnumMember]
		ManageRoles = 0x1,

		[EnumMember]
		CanSeeAllTasks = 0x2,

		[EnumMember]
		ManagePersonsInOrganization = 0x4,

		[EnumMember]
		EditOrganizationProjects = 0x8,

		[EnumMember]
		EditOrganizationSettings = 0x10,

		[EnumMember]
		DeleteMyTasksAndProjects = 0x20,

		[EnumMember]
		CloseDeleteAnnouncements = 0x40,

		[EnumMember]
		BillsPayment = 0x80,

		[EnumMember]
		InvitePersonsToOrganization = 0x100,

		[EnumMember]
		DeleteOtherMembersTasks = 0x200,

		[EnumMember]
		ManageIntegrationsAndCatalogs = 0x400,

		[EnumMember]
		CreateAnnouncement = 0x800,


		[IgnoreDataMember]
		CanDeleteTaskFlagEquivalent = DeleteMyTasksAndProjects |
										DeleteOtherMembersTasks,

		[EnumMember]
		SupervisorRights = ManageRoles |
							ManagePersonsInOrganization |
							EditOrganizationProjects |
							EditOrganizationSettings |
							BillsPayment |
							CloseDeleteAnnouncements,

		[EnumMember]
		MaxAdditionalRights = ManageRoles |
							CanSeeAllTasks |
							ManagePersonsInOrganization |
							EditOrganizationProjects |
							EditOrganizationSettings |
							DeleteMyTasksAndProjects |
							CloseDeleteAnnouncements |
							BillsPayment |
							InvitePersonsToOrganization |
							ManageIntegrationsAndCatalogs |
							DeleteOtherMembersTasks,

		[EnumMember]
		NewOrganizationDefaultRights = DeleteMyTasksAndProjects | CreateAnnouncement,

		#region Front Rights Set
		[EnumMember]
		UIAdministrator = ManagePersonsInOrganization | ManageRoles | EditOrganizationSettings | InvitePersonsToOrganization | NewOrganizationDefaultRights,

		[EnumMember]
		UIAccountant = BillsPayment,

		[EnumMember]
		UISupervisor = CanSeeAllTasks | EditOrganizationProjects,

		[EnumMember]
		UIConfigurationManager = DeleteOtherMembersTasks | ManageIntegrationsAndCatalogs,
		#endregion
	}
}
