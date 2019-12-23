using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pyrus.ApiClient;
using Pyrus.ApiClient.Helpers;
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

		internal const string RegisterSuffix = "/register";
		internal const string CommentSuffix = "/comments";
		internal const string TasksSuffix = "/tasks";

		static PyrusClient()
		{
			Settings = new Settings();
		}

	
		public async Task<AuthResponse> Auth(string login, string securityKey)
		{
			var url = Settings.Origin + AuthEndpoint + $"?login={login}&security_key={securityKey}";
			var response = await this.RunQuery<AuthResponse>(() => RequestHelper.GetRequest(url));
			Token = response.AccessToken;
			return response;
		}

		public async Task<FormsResponse> GetForms(string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<FormsResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<FormResponse> GetForm(int formId, string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint + $"/{formId}";
			if (accessToken != null)
				Token = accessToken;
			
			var response = await this.RunQuery<FormResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<FormRegisterResponse> GetRegistry(int formId, FormRegisterRequest request = null, string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint + $"/{formId}" + RegisterSuffix;
			if (accessToken != null)
				Token = accessToken;

			if (request != null && request.Filters.Count != 0)
				await ValidateFilter(request.Filters, formId);

			var response = await this.RunQuery<FormRegisterResponse>(() => RequestHelper.PostRequest(url, request, Token));
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
			var url = Settings.Origin + TasksEndpoint + $"/{taskId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<TaskResponse> CommentTask(int taskId, TaskCommentRequest comment, string accessToken = null)
		{
			var url = Settings.Origin + TasksEndpoint + $"/{taskId}" + CommentSuffix;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(url, comment, Token));
			return response;
		}

		public async Task<TaskResponse> CreateTask(TaskRequest task, string accessToken = null)
		{
			var url = Settings.Origin + TasksEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(url, task, Token));
			return response;
		}

		public async Task<CatalogResponse> GetCatalog(int catalogId, string accessToken = null)
		{
			var url = Settings.Origin + CatalogsEndpoint + $"/{catalogId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<SyncCatalogResponse> SyncCatalog(int catalogId, SyncCatalogRequest request, string accessToken = null)
		{
			var url = Settings.Origin + CatalogsEndpoint + $"/{catalogId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<SyncCatalogResponse>(() => RequestHelper.PostRequest(url, request, Token));
			return response;
		}

		public async Task<CatalogResponse> CreateCatalog(CreateCatalogRequest request, string accessToken = null)
		{
			var url = Settings.Origin + CatalogsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<CatalogResponse>(() => RequestHelper.PutRequest(url, request, Token));
			return response;
		}

		public async Task<ContactsResponse> GetContacts(string accessToken = null)
		{
			var url = Settings.Origin + ContactsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ContactsResponse>(() => RequestHelper.GetRequest(url, Token));
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
			var url = Settings.Origin + UploadFilesEndpoint;
			if (accessToken != null)
				Token = accessToken;

			if (fileStream.Length == 0)
				throw new PyrusApiClientException("Uploaded file can not be empty");

			var streamFactory = new NoDisposeStreamWrapperFactory(fileStream);

			var response = await this.RunQuery<UploadResponse>(() => RequestHelper.PostFileRequest(url, streamFactory, fileName, Token));
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
			var url = Settings.FilesOrigin + DownloadFilesEndpoint + $"?Id={attachmentId}";
			return await DownloadFile(url, accessToken);
		}

		private async Task<DownloadResponse> DownloadFile(string url, string accessToken = null)
		{
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<DownloadResponse>(() => RequestHelper.GetFileRequest(url, Token));
			return response;
		}

		public async Task<ListsResponse> GetLists(string accessToken = null)
		{
			var url = Settings.Origin + ListsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ListsResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<TaskListResponse> GetTaskList(int listId, int itemCount = 200, bool includeArchived = false, string accessToken = null)
		{
			var includeArchivedSuffix = includeArchived ? "&include_archived=y" : "";
			var url = Settings.Origin + ListsEndpoint + $"/{listId}" + TasksSuffix + $"?item_count={itemCount}{includeArchivedSuffix}";
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<TaskListResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

        public async Task<RoleResponse> CreateRole(CreateRoleRequest request, string accessToken = null)
        {
            var url = Settings.Origin + RolesEndpoint;
            if (accessToken != null)
                Token = accessToken;

            var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PostRequest(url, request, Token));
            return response;
        }

        public async Task<RoleResponse> UpdateRole(int roleId, UpdateRoleRequest request, string accessToken = null)
        {
            var url = Settings.Origin + RolesEndpoint + $"/{roleId}";
            if (accessToken != null)
                Token = accessToken;

            var response = await this.RunQuery<RoleResponse>(() => RequestHelper.PutRequest(url, request, Token));
            return response;
        }

        public async Task<RolesResponse> GetRoles(string accessToken = null)
        {
            var url = Settings.Origin + RolesEndpoint;
            if (accessToken != null)
                Token = accessToken;

            var response = await this.RunQuery<RolesResponse>(() => RequestHelper.GetRequest(url, Token));
            return response;
        }

		public async Task<ProfileResponse> GetProfile(string accessToken = null)
		{
			var url = Settings.Origin + ProfileEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await this.RunQuery<ProfileResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}
	}
}
