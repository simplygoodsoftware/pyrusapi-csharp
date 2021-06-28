using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pyrus.ApiClient;
using Pyrus.ApiClient.Helpers;
using Pyrus.ApiClient.Requests;
using Pyrus.ApiClient.Responses;
using PyrusApiClient.Exceptions;

namespace PyrusApiClient
{
	public class PyrusClient
	{
		public string SecretKey { get; set; }

		public string Login { get; set; }

		public string Token { get; set; }

		public static Settings Settings { get; set; }

		/// <summary>
		/// Returns custom settings if they were specified in <see cref="PyrusClient"/> constructor.
		/// Otherwise, returns static settings
		/// </summary>
		public Settings ClientSettings { get; }

		internal const string AuthEndpoint = "/auth";
		internal const string FormsEndpoint = "/forms";
		internal const string ListsEndpoint = "/lists";
		internal const string TasksEndpoint = "/tasks";
		internal const string CatalogsEndpoint = "/catalogs";
		internal const string UploadFilesEndpoint = "/files/upload";
		internal const string ContactsEndpoint = "/contacts";
		internal const string ProfileEndpoint = "/profile";
		internal const string DownloadFilesEndpoint = "/services/attachment";
		internal const string RolesEndpoint = "/roles";
		internal const string MembersEndpoint = "/members";
		internal const string BotsEndpoint = "/bots";
		internal const string InboxEndpoint = "/inbox";

		internal const string BatchSuffix = "/batch";
		internal const string RegisterSuffix = "/register";
		internal const string CommentSuffix = "/comments";
		internal const string TasksSuffix = "/tasks";

		static PyrusClient()
		{
			Settings = new Settings();
		}

		public PyrusClient() : this(Settings)
		{
		}

		public PyrusClient(Settings settings)
		{
			ClientSettings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public async Task<AuthResponse> Auth(string login, string securityKey)
		{
			var url = ClientSettings.Origin + AuthEndpoint;
			var response = await this.RunQuery<AuthResponse>(() 
				=> RequestHelper.PostRequest(this, url, new AuthRequest() { Login = login, SecurityKey = securityKey }));
			Token = response.AccessToken;
			return response;
		}

		public async Task<FormsResponse> GetForms(string accessToken = null)
		{
			var url = ClientSettings.Origin + FormsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<FormsResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<FormResponse> GetForm(int formId, string accessToken = null)
		{
			var url = ClientSettings.Origin + FormsEndpoint + $"/{formId}";
			if (accessToken != null)
				Token = accessToken;
			
			var response = await this.RunQuery<FormResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<FormRegisterResponse> GetRegistry(int formId, FormRegisterRequest request = null, string accessToken = null)
		{
			var url = ClientSettings.Origin + FormsEndpoint + $"/{formId}" + RegisterSuffix;
			if (accessToken != null)
				Token = accessToken;

			if (request != null && request.Filters.Count != 0)
				await ValidateFilter(request.Filters, formId);

			var response = await this.RunQuery<FormRegisterResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		private async System.Threading.Tasks.Task ValidateFilter(List<FormFilter> requestFilters, int formId)
		{
			if (requestFilters.All(f => f.FieldId.HasValue))
				return;

			var form = await GetForm(formId);
			if (form == null)
				return;

			foreach (var requestFilter in requestFilters.Where(f=> !f.FieldId.HasValue))
				requestFilter.FieldId = FormFilter.GetFieldIdByName(requestFilter.FieldName, form);
		}

		public async Task<TaskResponse> GetTask(int taskId, string accessToken = null)
		{
			var url = ClientSettings.Origin + TasksEndpoint + $"/{taskId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<TaskResponse> CommentTask(int taskId, TaskCommentRequest comment, string accessToken = null)
		{
			var url = ClientSettings.Origin + TasksEndpoint + $"/{taskId}" + CommentSuffix;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(this, url, comment, Token));
			return response;
		}

		public async Task<TaskResponse> CreateTask(TaskRequest task, string accessToken = null)
		{
			var url = ClientSettings.Origin + TasksEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(this, url, task, Token));
			return response;
		}

		public async Task<CatalogResponse> GetCatalog(int catalogId, string accessToken = null)
		{
			var url = ClientSettings.Origin + CatalogsEndpoint + $"/{catalogId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<SyncCatalogResponse> SyncCatalog(int catalogId, SyncCatalogRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + CatalogsEndpoint + $"/{catalogId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<SyncCatalogResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<CatalogResponse> CreateCatalog(CreateCatalogRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + CatalogsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<ContactsResponse> GetContacts(string accessToken = null)
		{
			var url = ClientSettings.Origin + ContactsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ContactsResponse>(() => RequestHelper.GetRequest(this, url, Token));
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

		public async Task<UploadResponse> UploadFile(Stream fileStream, string fileName, string accessToken = null)
		{
			var url = ClientSettings.Origin + UploadFilesEndpoint;
			if (accessToken != null)
				Token = accessToken;

			if (fileStream.Length == 0)
				throw new PyrusApiClientException("Uploaded file can not be empty");

			var streamFactory = new NoDisposeStreamWrapperFactory(fileStream);

			var response = await this.RunQuery<UploadResponse>(() => RequestHelper.PostFileRequest(this, url, streamFactory, fileName, Token));
			return response;
		}

		public async Task<DownloadResponse> DownloadFile(File file, string accessToken = null)
		{
			if (string.IsNullOrEmpty(file.Url) && file.Id == 0)
				throw new ArgumentException("Url or Id must be filled");

			var url = file.Url;
			if (string.IsNullOrEmpty(url))
				return await DownloadFile(file.Id, accessToken);

			return await DownloadFile(url, accessToken);
		}

		public async Task<DownloadResponse> DownloadFile(int attachmentId, string accessToken = null)
		{
			var url = ClientSettings.FilesOrigin + DownloadFilesEndpoint + $"?Id={attachmentId}";
			return await DownloadFile(url, accessToken);
		}

		private async Task<DownloadResponse> DownloadFile(string url, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DownloadResponse>(() => RequestHelper.GetFileRequest(this, url, Token));
			return response;
		}

		public async Task<ListsResponse> GetLists(string accessToken = null)
		{
			var url = ClientSettings.Origin + ListsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ListsResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<TaskListResponse> GetTaskList(int listId, int itemCount = 200, bool includeArchived = false, string accessToken = null)
		{
			var includeArchivedSuffix = includeArchived ? "&include_archived=y" : "";
			var url = ClientSettings.Origin + ListsEndpoint + $"/{listId}" + TasksSuffix + $"?item_count={itemCount}{includeArchivedSuffix}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskListResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<RoleResponse> CreateRole(CreateRoleRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<RolesResponse> CreateRoles(CreateRoleRequest[] request, string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint + BatchSuffix;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<RoleResponse> UpdateRole(int roleId, UpdateRoleRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint + $"/{roleId}";
			Token = accessToken ?? Token;

			var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<RolesResponse> UpdateRoles(UpdateRoleRequest[] request, string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint + BatchSuffix;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<RolesResponse> DeleteRoles(RoleDeleteRequest[] request, string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint + BatchSuffix;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<MemberResponse> CreateMember(CreateMemberRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + MembersEndpoint;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<MemberResponse> UpdateMember(int memberId, UpdateMemberRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + MembersEndpoint + $"/{memberId}";
			Token = accessToken ?? Token;

			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<ChangeMembersResponse> UpdateMembers(ChangeMembersRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + MembersEndpoint + BatchSuffix;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<ChangeMembersResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<BotResponse> CreateBot(CreateBotRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + BotsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<BotResponse>(() => RequestHelper.PostRequest(this, url, request, Token));
			return response;
		}

		public async Task<BotResponse> UpdateBot(int BotId, UpdateBotRequest request, string accessToken = null)
		{
			var url = ClientSettings.Origin + BotsEndpoint + $"/{BotId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<BotResponse>(() => RequestHelper.PutRequest(this, url, request, Token));
			return response;
		}

		public async Task<MemberResponse> DeleteMember(int memberId, string accessToken = null)
		{
			var url = ClientSettings.Origin + MembersEndpoint + $"/{memberId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<MemberResponse>(() => RequestHelper.DeleteRequest(this, url, Token));
			return response;
		}

		public async Task<RolesResponse> GetRoles(string accessToken = null)
		{
			var url = ClientSettings.Origin + RolesEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<RolesResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<MembersResponse> GetMembers(string accessToken = null)
		{
			var url = ClientSettings.Origin + MembersEndpoint;
			Token = accessToken ?? Token;

			var response = await this.RunQuery<MembersResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<BotsResponse> GetBots(string accessToken = null)
		{
			var url = ClientSettings.Origin + BotsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<BotsResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<ProfileResponse> GetProfile(string accessToken = null)
		{
			var url = ClientSettings.Origin + ProfileEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ProfileResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}

		public async Task<InboxResponse> GetInbox(int tasksCount = 50, string accessToken = null)
		{
			var url = $"{ClientSettings.Origin}{InboxEndpoint}?item_count={tasksCount}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<InboxResponse>(() => RequestHelper.GetRequest(this, url, Token));
			return response;
		}
	}
}
