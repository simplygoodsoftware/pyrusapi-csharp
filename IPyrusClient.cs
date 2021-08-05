using Pyrus.ApiClient.Requests;
using Pyrus.ApiClient.Responses;
using System.IO;
using System.Threading.Tasks;

namespace PyrusApiClient
{
    public interface IPyrusClient
    {
		string SecretKey { get; set; }
		string Login { get; set; }
		string Token { get; set; }

        Task<AuthResponse> Auth(string login, string securityKey);
		Task<FormsResponse> GetForms(string accessToken = null);
		Task<FormResponse> GetForm(int formId, string accessToken = null);
		Task<FormRegisterResponse> GetRegistry(int formId, FormRegisterRequest request = null, string accessToken = null);
		Task<TaskResponse> GetTask(int taskId, string accessToken = null);
		Task<TaskResponse> CommentTask(int taskId, TaskCommentRequest comment, string accessToken = null);
		Task<TaskResponse> CreateTask(TaskRequest task, string accessToken = null);
		Task<CatalogResponse> GetCatalog(int catalogId, string accessToken = null);
		Task<CatalogsResponse> GetCatalogs(string accessToken = null);
		Task<SyncCatalogResponse> SyncCatalog(int catalogId, SyncCatalogRequest request, string accessToken = null);
		Task<SyncCatalogsResponse> SyncCatalogs(SyncCatalogRequest[] request, string accessToken = null);
		Task<CatalogResponse> CreateCatalog(CreateCatalogRequest request, string accessToken = null);
		Task<CatalogsResponse> CreateCatalogs(CreateCatalogRequest[] request, string accessToken = null);
		Task<ResponseBase> DeleteCatalogs(DeleteCatalogRequest[] request, string accessToken = null);
		Task<ContactsResponse> GetContacts(string accessToken = null);
		Task<UploadResponse> UploadFile(string path, string accessToken = null);
		Task<UploadResponse> UploadFile(Stream fileStream, string fileName, string accessToken = null);
		Task<DownloadResponse> DownloadFile(File file, string accessToken = null);
		Task<DownloadResponse> DownloadFile(int attachmentId, string accessToken = null);
		Task<ListsResponse> GetLists(string accessToken = null);
		Task<TaskListResponse> GetTaskList(int listId, int itemCount = 200, bool includeArchived = false, string accessToken = null);
		Task<RoleResponse> CreateRole(CreateRoleRequest request, string accessToken = null);
		Task<RolesResponse> CreateRoles(CreateRoleRequest[] request, string accessToken = null);
		Task<RoleResponse> UpdateRole(int roleId, UpdateRoleRequest request, string accessToken = null);
		Task<RolesResponse> UpdateRoles(UpdateRoleRequest[] request, string accessToken = null);
		Task<RolesResponse> DeleteRoles(DeleteRoleRequest[] request, string accessToken = null);
		Task<MemberResponse> CreateMember(CreateMemberRequest request, string accessToken = null);
		Task<MemberResponse> UpdateMember(int memberId, UpdateMemberRequest request, string accessToken = null);
		Task<ChangeMembersResponse> UpdateMembers(ChangeMembersRequest request, string accessToken = null);
		Task<BotResponse> CreateBot(CreateBotRequest request, string accessToken = null);
		Task<BotResponse> UpdateBot(int BotId, UpdateBotRequest request, string accessToken = null);
		Task<MemberResponse> DeleteMember(int memberId, string accessToken = null);
		Task<RolesResponse> GetRoles(string accessToken = null);
		Task<MembersResponse> GetMembers(string accessToken = null);
		Task<BotsResponse> GetBots(string accessToken = null);
		Task<ProfileResponse> GetProfile(string accessToken = null);
		Task<InboxResponse> GetInbox(int tasksCount = 50, string accessToken = null);
	}
}
