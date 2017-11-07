using System;
using System.IO;
using System.Threading.Tasks;
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

		internal readonly RequestHelper RequestHelper;

		internal const string AuthEndpoint = "/auth";
		internal const string FormsEndpoint = "/forms";
		internal const string TasksEndpoint = "/tasks";
		internal const string CatalogsEndpoint = "/catalogs";
		internal const string FilesEndpoint = "/files";
		internal const string ContactsEndpoint = "/contacts";

		internal const string RegisterSuffix = "/register";
		internal const string CommentSuffix = "/comments";
		internal const string UploadSuffix = "/upload";

		static PyrusClient()
		{
			Settings = new Settings();
		}

		public PyrusClient()
		{
			RequestHelper = new RequestHelper(this);
		}
		
		public async Task<AuthResponse> Auth(string login, string securityKey)
		{
			var url = Settings.Origin + AuthEndpoint + $"?login={login}&security_key={securityKey}";
			var response = await RequestHelper.RunQuery<AuthResponse>(() => RequestHelper.GetRequest(url));
			Token = response.AccessToken;
			return response;
		}

		public async Task<FormsResponse> GetForms(string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<FormsResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<FormResponse> GetForm(int formId, string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint + $"/{formId}";
			if (accessToken != null)
				Token = accessToken;
			
			var response = await RequestHelper.RunQuery<FormResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<FormRegisterResponse> GetRegistry(int formId, FormRegisterRequest request = null, string accessToken = null)
		{
			var url = Settings.Origin + FormsEndpoint + $"/{formId}" + RegisterSuffix;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<FormRegisterResponse>(() => RequestHelper.PostRequest(url, request, Token));
			return response;
		}

		public async Task<TaskResponse> GetTask(int taskId, string accessToken = null)
		{
			var url = Settings.Origin + TasksEndpoint + $"/{taskId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<TaskResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<TaskResponse> CommentTask(int taskId, TaskCommentRequest comment, string accessToken = null)
		{
			var url = Settings.Origin + TasksEndpoint + $"/{taskId}" + CommentSuffix;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(url, comment, Token));
			return response;
		}

		public async Task<TaskResponse> CreateTask(TaskRequest task, string accessToken = null)
		{
			var url = Settings.Origin + TasksEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<TaskResponse>(() => RequestHelper.PostRequest(url, task, Token));
			return response;
		}

		public async Task<CatalogResponse> GetCatalog(int catalogId, string accessToken = null)
		{
			var url = Settings.Origin + CatalogsEndpoint + $"/{catalogId}";
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<CatalogResponse>(() => RequestHelper.GetRequest(url, Token));
			return response;
		}

		public async Task<ContactsResponse> GetContacts(string accessToken = null)
		{
			var url = Settings.Origin + ContactsEndpoint;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<ContactsResponse>(() => RequestHelper.GetRequest(url, Token));
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
			var url = Settings.Origin + FilesEndpoint + UploadSuffix;
			if (accessToken != null)
				Token = accessToken;

			var response = await RequestHelper.RunQuery<UploadResponse>(() => RequestHelper.PostFileRequest(url, fileStream, fileName, Token));
			return response;
		}
	}
}
