using Pyrus.ApiClient;
using Pyrus.ApiClient.Helpers;
using Pyrus.ApiClient.Requests;
using Pyrus.ApiClient.Requests.Builders;
using Pyrus.ApiClient.Responses;
using PyrusApiClient.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PyrusApiClient
{
	public class PyrusClient
	{
		public string SecretKey { get; set; }

		public string Login { get; set; }

		public string Token { get; set; }

		public int? PersonId { get; set; }

		public static Settings Settings { get; set; }

		/// <summary>
		/// Returns custom settings if they were specified in <see cref="PyrusClient"/> constructor.
		/// Otherwise, returns static settings
		/// </summary>
		public Settings ClientSettings { get; }

		internal const string AuthEndpoint = "/auth";
		internal const string LoginServiceAuthEndpoint = "https://accounts.pyrus.com/auth";
		internal const string FormsEndpoint = "/forms";
		internal const string ListsEndpoint = "/lists";
		internal const string TasksEndpoint = "/tasks";
		internal const string AnnouncementsEndpoint = "/announcements";
		internal const string TasksByApproverEndpoint = "/tasksbyapprover";
		internal const string CatalogsEndpoint = "/catalogs";
		internal const string UploadFilesEndpoint = "/files/upload";
		internal const string UploadFileServiceEndpoint = "/v4/files/upload";
		internal const string ContactsEndpoint = "/contacts";
		internal const string ProfileEndpoint = "/profile";
		internal const string DownloadFilesEndpoint = "/services/attachment";
		internal const string RolesEndpoint = "/roles";
		internal const string MembersEndpoint = "/members";
		internal const string BotsEndpoint = "/bots";
		internal const string InboxEndpoint = "/inbox";
		internal const string CalendarEndpoint = "/calendar";
		internal const string GetMessageEndpoint = "/integrations/getmessage";
		internal const string CallEndpoint = "/integrations/call";
		internal const string AttachCallRecordEndpoint = "/integrations/attachcallrecord";
		internal const string CallsEndpoint = "/calls";
		internal const string HandlingTimeEndpoint = "/handlingtime";
		internal const string EventHistoryEndpoint = "/eventhistory";
		internal const string FileAccessHistoryEndpoint = "/fileaccesshistory";
		internal const string RegistryAccessHistoryEndpoint = "/registryaccesshistory";
		internal const string RegistryDownloadHistoryEndpoint = "/registrydownloadhistory";
		internal const string TaskAccessHistoryEndpoint = "/taskaccesshistory";
		internal const string PersonLastActionEndpoint = "/personlastaction";
		internal const string OrgChartEndpoint = "/orgchart";
		internal const string ProfileIdentityEndpoint = "/profile/identity";

		internal const string BulkSuffix = "/bulk";
		internal const string RegisterSuffix = "/register";
		internal const string CommentSuffix = "/comments";
		internal const string TasksSuffix = "/tasks";

		static PyrusClient()
		{
			ServicePointManager.DnsRefreshTimeout = 0;
			Settings = new Settings();
		}

		public PyrusClient() : this(Settings)
		{
		}

		public PyrusClient(Settings settings)
		{
			ClientSettings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public async Task<AuthResponse> Auth(string login, string securityKey, int? personId = null)
		{
			var url = ClientExtensions.GetAuthUrl(this);
			var response = await this.RunQuery<AuthResponse>(()
				=> RequestHelper.PostRequest(this, url, new AuthRequest() { Login = login, SecurityKey = securityKey, PersonId = personId }));
			Token = response.AccessToken;

			ClientExtensions.SetOrigins(this, response);

			return response;
		}

		public async Task<FormsResponse> GetForms(string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<FormsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{FormsEndpoint}", Token));
			return response;
		}

		public async Task<FormResponse> GetForm(int formId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<FormResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{FormsEndpoint}/{formId}", Token));
			return response;
		}

		public async Task<FormRegisterResponse> GetRegistry(int formId, FormRegisterRequest request = null, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			if (request != null && request.Filters.Count != 0)
				await ValidateFilter(request.Filters, formId);

			var response = await this.RunQuery<FormRegisterResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{FormsEndpoint}/{formId}{RegisterSuffix}", request, Token));
			return response;
		}

		private async System.Threading.Tasks.Task ValidateFilter(List<FormFilter> requestFilters, int formId)
		{
			if (requestFilters.All(f => f.FieldId.HasValue))
				return;

			var form = await GetForm(formId);
			if (form == null)
				return;

			foreach (var requestFilter in requestFilters.Where(f => !f.FieldId.HasValue))
				requestFilter.FieldId = FormFilter.GetFieldIdByName(requestFilter.FieldName, form);
		}

		public async Task<TaskResponse> GetTask(int taskId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{TasksEndpoint}/{taskId}", Token));
			return response;
		}

		public async Task<AnnouncementResponse> GetAnnouncement(int announcementId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			return await this.RunQuery<AnnouncementResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{AnnouncementsEndpoint}/{announcementId}", Token));
		}

		public async Task<AnnouncementsResponse> GetAnnouncements(string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			return await this.RunQuery<AnnouncementsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{AnnouncementsEndpoint}", Token));
		}


		public async Task<TaskListResponse> GetTasksByApproverAsync(int id, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskListResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{TasksByApproverEndpoint}/{id}", Token));
			return response;
		}

		public async Task<TaskResponse> CommentTask(int taskId, TaskCommentRequest comment, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{TasksEndpoint}/{taskId}{CommentSuffix}", comment, Token));
			return response;
		}

		internal async Task<AnnouncementResponse> CommentAnnouncement(int announcementId, AnnouncementCommentRequest comment, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			
			return await this.RunQuery<AnnouncementResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{AnnouncementsEndpoint}/{announcementId}{CommentSuffix}", comment, Token));
		}

		public async Task<MultipleTasksChangeResponse> CommentMultipleTasksInOneTransaction(MultipleTasksChangeRequest request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<MultipleTasksChangeResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{TasksEndpoint}/{CommentSuffix}", request, Token));
			return response;
		}

		public async Task<TaskResponse> CreateTask(TaskRequest task, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{TasksEndpoint}", task, Token));
			return response;
		}

		internal async Task<AnnouncementResponse> CreateAnnouncement(AnnouncementRequest announcement, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			
			var response = await this.RunQuery<AnnouncementResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{AnnouncementsEndpoint}", announcement, Token));
			return response;
		}

		public async Task<CatalogResponse> GetCatalog(int catalogId, string accessToken = null, bool includeDeleted = false)
		{
			var path = $"{CatalogsEndpoint}/{catalogId}?include_deleted={includeDeleted}";
			Token = accessToken ?? Token;

			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{path}", Token));
			return response;
		}

		public async Task<CatalogsResponse> GetCatalogs(string accessToken = null)
		{
			Token = accessToken ?? Token;

			var response = await this.RunQuery<CatalogsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}", Token));
			return response;
		}

		public async Task<SyncCatalogResponse> SyncCatalog(int catalogId, SyncCatalogRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;

			var response = await this.RunQuery<SyncCatalogResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}/{catalogId}", request, Token));
			return response;
		}

		public async Task<SyncCatalogsResponse> SyncCatalogs(SyncCatalogRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<SyncCatalogsResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<CatalogResponse> CreateCatalog(CreateCatalogRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}", request, Token));
			return response;
		}

		public async Task<CatalogsResponse> CreateCatalogs(CreateCatalogRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<CatalogsResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<ResponseBase> DeleteCatalogs(DeleteCatalogRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<ResponseBase>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{CatalogsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}
		public async Task<ContactsResponse> GetContacts(ContactsRequest request, string accessToken = null)
			=> await GetContacts(request?.IncludeInactive ?? false, accessToken);

		public async Task<ContactsResponse> GetContacts(string accessToken = null)
			=> await GetContacts(includeInactive: false, accessToken);

		private async Task<ContactsResponse> GetContacts(bool includeInactive = false, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			var response = await this.RunQuery<ContactsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{ContactsEndpoint}/?include_inactive={includeInactive}", Token));
			return response;
		}

		public async Task<UploadResponse> UploadFile(string path, string accessToken = null)
		{
			try
			{
				using (var fileStream = System.IO.File.Open(path, FileMode.Open))
				{
					var fileName = new FileInfo(path).Name;
					return await UploadFile(fileStream, fileName, accessToken);
				}
			}
			catch (Exception e)
			{
				throw new PyrusApiClientException(e.Message, e);
			}
		}

		public async Task<UploadResponse> UploadFile(Stream fileStream, string fileName, string accessToken = null, bool useFileService = false)
		{
			if (accessToken != null)
				Token = accessToken;

			if (fileStream.Length == 0)
				throw new PyrusApiClientException("Uploaded file can not be empty");

			var streamFactory = new NoDisposeStreamWrapperFactory(fileStream);

			var response = await this.RunQuery<UploadResponse>(async () =>
			{
				var url = useFileService
					? $"{ClientSettings.FilesOrigin}{UploadFileServiceEndpoint}"
					: $"{ClientSettings.Origin}{UploadFilesEndpoint}";

                return await RequestHelper.PostFileRequest(this, url, streamFactory, fileName, Token);
            });
			return response;
		}

		public async Task<DownloadResponse> DownloadFile(File file, string accessToken = null)
		{
			if (file == null)
				throw new ArgumentNullException(nameof(file));
			if (string.IsNullOrEmpty(file.Url) && file.Id == 0)
				throw new ArgumentException("Url or Id must be filled");

			var url = file.Url;
			if (string.IsNullOrEmpty(url))
				return await DownloadFile(file.Id, accessToken);

			return await DownloadFileByUrl(url, accessToken);
		}

		public async Task<DownloadResponse> DownloadFile(int attachmentId, string accessToken = null, int? previewId = null)
		{
			var path = $"{DownloadFilesEndpoint}?Id={attachmentId}";

			if (previewId != null)
				path += $"&ispreview={previewId}";

			return await DownloadFile(path, accessToken);
		}

		private async Task<DownloadResponse> DownloadFile(string path, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DownloadResponse>(() => RequestHelper.GetFileRequest(this, $"{ClientSettings.FilesOrigin}{path}", Token));
			return response;
		}

		private async Task<DownloadResponse> DownloadFileByUrl(string url, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DownloadResponse>(() => RequestHelper.GetFileRequest(this, url, Token));
			return response;
		}

        public async Task<ListsResponse> GetLists(string accessToken = null, bool withForms = false, bool withDeleted = false)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ListsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}?with_forms={withForms}&with_deleted={withDeleted}", Token));
			return response;
		}

		public async Task<PlainListResponse> CreateList(CreateListRequest request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<PlainListResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}", request, Token));
			return response;
		}

		public async Task<PlainListsResponse> CreateLists(CreateListRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<PlainListsResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<PlainListResponse> UpdateList(int listId, UpdateListRequest request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<PlainListResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}/{listId}", request, Token));
			return response;
		}

		public async Task<PlainListsResponse> UpdateLists(UpdateListRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<PlainListsResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<ResponseBase> DeleteList(int listId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ResponseBase>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}/{listId}", Token));
			return response;
		}

		public async Task<ResponseBase> DeleteLists(DeleteListRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ResponseBase>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<TaskListResponse> GetTaskList(int listId, int itemCount = 200, bool includeArchived = false, string accessToken = null)
		{
			var request = RequestBuilder.GetTaskList(listId).MaxItemCount(itemCount).IncludeArchived(includeArchived);
			return await GetTaskList(listId, request, accessToken);
		}

		internal async Task<TaskListResponse> GetTaskList(int listId, TaskListRequest request = null, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			var response = await this.RunQuery<TaskListResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{ListsEndpoint}/{listId}{TasksSuffix}", request, Token));
			return response;
		}

		public async Task<RoleResponse> CreateRole(CreateRoleRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}", request, Token));
			return response;
		}

		public async Task<RolesResponse> CreateRoles(CreateRoleRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<RoleResponse> UpdateRole(int roleId, UpdateRoleRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}/{roleId}", request, Token));
			return response;
		}

		public async Task<RolesResponse> UpdateRoles(UpdateRoleRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<RolesResponse> DeleteRoles(DeleteRoleRequest[] request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<MemberResponse> CreateMember(CreateMemberRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}", request, Token));
			return response;
		}

		public async Task<MemberResponse> UpdateMember(int memberId, UpdateMemberRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}/{memberId}", request, Token));
			return response;
		}

		public async Task<ChangeMembersResponse> UpdateMembers(ChangeMembersRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<ChangeMembersResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<MemberResponse> SetAvatar(int memberId, SetAvatarRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}/{memberId}/avatar", request, Token));
			return response;
		}

		public async Task<BotResponse> CreateBot(CreateBotRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<BotResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{BotsEndpoint}", request, Token));
			return response;
		}

		public async Task<BotResponse> UpdateBot(int botId, UpdateBotRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<BotResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{BotsEndpoint}/{botId}", request, Token));
			return response;
		}

		public async Task<BotResponse> DeleteBot(int botId, DeleteBotRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<BotResponse>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{BotsEndpoint}/{botId}", request, Token));
			return response;
		}

		public async Task<MemberResponse> DeleteMember(int memberId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}/{memberId}", Token));
			return response;
		}

		public async Task<RolesResponse> GetRoles(string accessToken = null, bool includeFired = false)
		{
			if (accessToken != null)
				Token = accessToken;
			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}?include_fired={includeFired}", Token));
			return response;
		}

		public async Task<RoleResponse> GetRole(int id, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<RoleResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{RolesEndpoint}/{id}", Token));
			return response;
		}

		public async Task<MembersResponse> GetMembers(string accessToken = null, bool includeFired = false)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<MembersResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}?include_fired={includeFired}", Token));
			return response;
		}

		public async Task<MemberResponse> GetMember(int id, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{MembersEndpoint}/{id}", Token));
			return response;
		}

		public async Task<BotsResponse> GetBots(string accessToken = null, bool includeFired = false)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<BotsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{BotsEndpoint}?include_fired={includeFired}", Token));
			return response;
		}

		public async Task<ProfileResponse> GetProfile(ProfileRequest request, string accessToken = null)
			=> await GetProfile(request?.IncludeInactive ?? false, accessToken);

		public async Task<ProfileResponse> GetProfile(string accessToken = null)
			=> await GetProfile(includeInactive: false, accessToken);

		private async Task<ProfileResponse> GetProfile(bool includeInactive = false, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ProfileResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{ProfileEndpoint}/?include_inactive={includeInactive}", Token));
			return response;
		}

		public async Task<ProfileIdentityResponse> GetIdentity(string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ProfileIdentityResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{ProfileIdentityEndpoint}", Token));
			return response;
		}

		public async Task<DepartmentsResponse> GetOrgChart(string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DepartmentsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}", Token));
			return response;
		}

		public async Task<DepartmentResponse> CreateDepartment(CreateDepartmentRequest request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DepartmentResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}", request, Token));
			return response;
		}

		public async Task<DepartmentsResponse> CreateDepartments(CreateDepartmentRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DepartmentsResponse>(() => RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<DepartmentResponse> UpdateDepartment(long departmentId, UpdateDepartmentRequest request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DepartmentResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}/{departmentId}", request, Token));
			return response;
		}

		public async Task<DepartmentsResponse> UpdateDepartments(UpdateDepartmentRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;
			var response = await this.RunQuery<DepartmentsResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<ResponseBase> DeleteDepartment(long departmentId, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ResponseBase>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}/{departmentId}", Token));
			return response;
		}

		public async Task<ResponseBase> DeleteDepartments(DeleteDepartmentRequest[] request, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ResponseBase>(() => RequestHelper.DeleteRequest(this, $"{ClientSettings.Origin}{OrgChartEndpoint}{BulkSuffix}", request, Token));
			return response;
		}

		public async Task<InboxResponse> GetInbox(int tasksCount = 50, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<InboxResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{InboxEndpoint}?item_count={tasksCount}", Token));
			return response;
		}
		
		public async Task<CalendarResponse> GetCalendarTasks(DateTime startDateTime, DateTime endDateTime,
			int? tasksCount = 50, bool allAccessedTasks = false, int filterMask = 0b0111, string accessToken = null)
		{
			var path = $"{CalendarEndpoint}?" +
					  $"start_date_utc={startDateTime}" +
					  $"&end_date_utc={endDateTime}" +
					  $"&item_count={tasksCount}" +
					  $"&all_accessed_tasks={allAccessedTasks}" +
					  $"&filter_mask={filterMask}";
			
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<CalendarResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{path}", Token));
			return response;
		}
		
		public async Task<ResponseBase> RegisterMessageAsync(GetMessageRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			
			return await this.RunQuery<ResponseBase>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{GetMessageEndpoint}", request, Token));
		}

		public async Task<CallResponse> RegisterCallAsync(CallRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			
			return await this.RunQuery<CallResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{CallEndpoint}", request, Token));
		}
		
		public async Task<ResponseBase> AttachCallRecordAsync(AttachCallRecordRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			
			return await this.RunQuery<ResponseBase>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{AttachCallRecordEndpoint}", request, Token));
		}

		public async Task<DownloadResponse> GetHandlingTimeAsync(string sd = null, 
			string ed = null, 
			int? formId = null, 
			string tz = null, 
			string accessToken = null)
		{
			var path = $"{HandlingTimeEndpoint}";

			var parameters = new NameValueCollection();
			if (!string.IsNullOrEmpty(ed))
				parameters.Add("ed", ed);
			if (formId != null)
				parameters.Add("formId", formId.Value.ToString());
			if (!string.IsNullOrEmpty(tz))
				parameters.Add("tz", tz);
			var parametersString = ToQueryString(parameters);
			
			if (!string.IsNullOrEmpty(parametersString))
				path = $"{path}{parametersString}";
			
			return await DownloadFile(path, accessToken);
		}

		public async Task<DownloadResponse> GetPersonLastActionReportAsync(string accessToken = null)
		{
			return await DownloadFile(PersonLastActionEndpoint, accessToken);
		}

		public Task<DownloadResponse> GetSessionEventHistoryAsync(long after, int count, string accessToken = null)
		{
			return GetHistoryAsync(after, count, EventHistoryEndpoint, accessToken);
		}

		public Task<DownloadResponse> GetFileAccessHistoryAsync(long after, int count, string accessToken = null)
		{
			return GetHistoryAsync(after, count, FileAccessHistoryEndpoint, accessToken);
		}

		public Task<DownloadResponse> GetRegistryAccessEventHistoryAsync(long after, int count, string accessToken = null)
		{
			return GetHistoryAsync(after, count, RegistryAccessHistoryEndpoint, accessToken);
		}

		public Task<DownloadResponse> GetRegistryDownloadEventHistoryAsync(long after, int count, string accessToken = null)
		{
			return GetHistoryAsync(after, count, RegistryDownloadHistoryEndpoint, accessToken);
		}

		public Task<DownloadResponse> GetTaskAccessHistoryAsync(long after, int count, string accessToken = null)
		{
			return GetHistoryAsync(after, count, TaskAccessHistoryEndpoint, accessToken);
		}
		
		public async Task<CreateCallResponse> CreateCallAsync(
			CreateCallRequest request,
			string accessToken = null)
		{
			Token = accessToken ?? Token;

			return await this.RunQuery<CreateCallResponse>(() =>
				RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{CallsEndpoint}", request, Token));
		}

		public async Task<ResponseBase> UpdateCallAsync(
			Guid callGuid,
			UpdateCallRequest request,
			string accessToken = null)
		{
			Token = accessToken ?? Token;

			return await this.RunQuery<ResponseBase>(() =>
				RequestHelper.PutRequest(this, $"{ClientSettings.Origin}{CallsEndpoint}/{callGuid:D}", request, Token));
		}

		public async Task<ResponseBase> RegisterCallEventAsync(
			Guid callGuid,
			CallEventRequest request,
			string accessToken = null)
		{
			Token = accessToken ?? Token;

			return await this.RunQuery<ResponseBase>(() =>
				RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{CallsEndpoint}/{callGuid:D}/event", request, Token));
		}

		public async Task<PermissionsResponse> GetFormPermissions(int id, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<PermissionsResponse>(() => RequestHelper.GetRequest(this, $"{ClientSettings.Origin}{FormsEndpoint}/{id}/permissions", Token));
			return response;
		}

		public async Task<PermissionsResponse> ChangeFormPermissions(int id, ChangePermissionsRequest request, string accessToken = null)
		{
			Token = accessToken ?? Token;
			var response = await this.RunQuery<PermissionsResponse>(() => RequestHelper.PostRequest(this, $"{ClientSettings.Origin}{FormsEndpoint}/{id}/permissions", request, Token));
			return response;
		}

		private Task<DownloadResponse> GetHistoryAsync(long after, int count, string endpoint, string accessToken)
		{
			var parameters = new NameValueCollection
			{
				{ "after", after.ToString() },
				{ "count", count.ToString() }
			};

			var path = $"{endpoint}{ToQueryString(parameters)}";
			
			return DownloadFile(path, accessToken);
		}
		
		private string ToQueryString(NameValueCollection nvc)
		{
			var array = (nvc.AllKeys.SelectMany(nvc.GetValues,
				(key, value) => $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}")).ToArray();
			return "?" + string.Join("&", array);
		}

		public async Task<TResponse> ProcessGetRequest<TResponse>(string path)
			where TResponse : ResponseBase
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));

			var url = $"{ClientSettings.Origin}{path}";
			return await this.RunQuery<TResponse>(() => RequestHelper.GetRequest(this, url, Token));
		}

		public async Task<TResponse> ProcessPostRequest<TRequest, TResponse>(string path, TRequest request)
			where TResponse : ResponseBase
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var url = $"{ClientSettings.Origin}{path}";
			return await this.RunQuery<TResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
		}

		public async Task<TResponse> ProcessPutRequest<TRequest, TResponse>(string path, TRequest request)
			where TResponse : ResponseBase
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var url = $"{ClientSettings.Origin}{path}";
			return await this.RunQuery<TResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
		}

		public async Task<TResponse> ProcessDeleteRequest<TRequest, TResponse>(string path, TRequest request)
			where TResponse : ResponseBase
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var url = $"{ClientSettings.Origin}{path}";
			return await this.RunQuery<TResponse>(() => RequestHelper.DeleteRequest(this, url, request, Token));
		}
	}
}
