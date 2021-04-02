using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pyrus.ApiClient.Responses;
using PyrusApiClient;
using PyrusApiClient.Builders;
using File = PyrusApiClient.File;

namespace Pyrus.ApiClient.Requests.Builders
{
	public static class RequestBuilder
	{
		public static FormTaskBuilder CreateFormTask(int formId)
		{
			return new FormTaskBuilder(new TaskRequest {FormId = formId});
		}

		public static SimpleTaskBuilder CreateSimpleTask(string text)
		{
			return new SimpleTaskBuilder(new TaskRequest{Text = text});
		}

		public static FormTaskCommentBuilder CommentFormTask(int taskId)
		{
			return new FormTaskCommentBuilder(new TaskCommentRequest(), taskId);
		}

		public static SimpleTaskCommentBuilder CommentSimpleTask(int taskId)
		{
			return new SimpleTaskCommentBuilder(new TaskCommentRequest(), taskId);
		}

		public static FormRegisterRequestBuilder GetRegistry(int formId)
		{
			return new FormRegisterRequestBuilder(new FormRegisterRequest(), formId);
		}

		public static OnePropertyBuilder<int, TaskResponse> GetTask(int taskId)
		{
			return new OnePropertyBuilder<int, TaskResponse>(taskId);
		}

		public static OnePropertyBuilder<int, DownloadResponse> DownloadFile(int fileId)
		{
			return new OnePropertyBuilder<int, DownloadResponse>(fileId);
		}

		public static OnePropertyBuilder<File, DownloadResponse> DownloadFile(File file)
		{
			return new OnePropertyBuilder<File, DownloadResponse>(file);
		}

		public static AuthRequestBuilder Auth(string login, string secretKey)
		{
			return new AuthRequestBuilder(login, secretKey);
		}

		public static OnePropertyBuilder<int, CatalogResponse> GetCatalog(int catalogId)
		{
			return new OnePropertyBuilder<int, CatalogResponse>(catalogId);
		}

		public static OnePropertyBuilder<int, FormResponse> GetForm(int formId)
		{
			return new OnePropertyBuilder<int, FormResponse>(formId);
		}

		public static EmptyBuilder<ContactsResponse> GetContacts()
		{
			return new EmptyBuilder<ContactsResponse>();
		}

		public static EmptyBuilder<FormsResponse> GetForms()
		{
			return new EmptyBuilder<FormsResponse>();
		}

		public static EmptyBuilder<ListsResponse> GetLists()
		{
			return new EmptyBuilder<ListsResponse>();
		}

		public static TaskListRequestBuilder GetTaskList(int listId, int maxItemCount = 200, bool includeArchived = false)
		{
			return new TaskListRequestBuilder(listId, maxItemCount, includeArchived);
		}

		public static UploadRequestBuilder UploadFile(string path)
		{
			return new UploadRequestBuilder(path);
		}

		public static UploadRequestBuilder UploadFile(Stream fileStream, string fileName)
		{
			return new UploadRequestBuilder(fileStream, fileName);
		}

		public static SyncCatalogRequestBuilder SyncCatalog(int catalogId)
		{
			return new SyncCatalogRequestBuilder(catalogId);
		}

		public static CreateCatalogRequestBuilder CreateCatalog(string name)
		{
			return new CreateCatalogRequestBuilder(name);
		}

		public static CreateRoleRequestBuilder CreateRole(string name)
		{
			return new CreateRoleRequestBuilder(name);
		}

		public static UpdateRoleRequestBuilder UpdateRole(int roleId)
		{
			return new UpdateRoleRequestBuilder(roleId);
		}

		public static EmptyBuilder<RolesResponse> GetRoles()
		{
			return new EmptyBuilder<RolesResponse>();
		}

		public static CreateMemberRequestBuilder CreateMember(string email)
		{
			return new CreateMemberRequestBuilder(email);
		}

		public static UpdateMemberRequestBuilder UpdateMember(int memberId)
		{
			return new UpdateMemberRequestBuilder(memberId);
		}
		
		public static DeleteMemberRequestBuilder DeleteMember(int memberId)
		{
			return new DeleteMemberRequestBuilder(memberId);
		}

		public static EmptyBuilder<MembersResponse> GetMembers()
		{
			return new EmptyBuilder<MembersResponse>();
		}

		public static EmptyBuilder<ProfileResponse> GetProfile()
		{
			return new EmptyBuilder<ProfileResponse>();
		}

		public static OnePropertyBuilder<int, InboxResponse> GetInbox(int tasksCount = 50)
		{
			return new OnePropertyBuilder<int, InboxResponse>(tasksCount);
		}

		#region Process

		public static async Task<TaskResponse> Process(this FormTaskBuilder builder, PyrusClient client)
		{
			return await client.CreateTask(builder);
		}

		public static async Task<TaskResponse> Process(this FormTaskBuilder.FormFieldsBuilder builder, PyrusClient client)
		{
			return await client.CreateTask(builder);
		}

		public static async Task<TaskResponse> Process(this SimpleTaskBuilder builder, PyrusClient client)
		{
			return await client.CreateTask(builder);
		}

		public static async Task<TaskResponse> Process(this SimpleTaskCommentBuilder builder, PyrusClient client)
		{
			return await client.CommentTask(builder.TaskId, builder);
		}

		public static async Task<TaskResponse> Process(this FormTaskCommentBuilder builder, PyrusClient client)
		{
			return await client.CommentTask(builder.TaskId, builder);
		}

		public static async Task<TaskResponse> Process(this FormTaskCommentBuilder.FieldUpdatesBuilder builder, PyrusClient client)
		{
			return await client.CommentTask(builder.TaskId, builder);
		}

		public static async Task<FormRegisterResponse> Process(this FormRegisterRequestBuilder builder, PyrusClient client)
		{
			return await client.GetRegistry(builder.FormId, builder);
		}

		public static async Task<FormRegisterResponse> Process(this FormRegisterRequestBuilder.FormRegisterFilterBuilder builder, PyrusClient client)
		{
			return await client.GetRegistry(builder.FormId, builder);
		}

		public static async Task<TaskResponse> Process(this OnePropertyBuilder<int, TaskResponse> builder, PyrusClient client)
		{
			return await client.GetTask(builder.Property);
		}

		public static async Task<DownloadResponse> Process(this OnePropertyBuilder<int, DownloadResponse> builder, PyrusClient client)
		{
			return await client.DownloadFile(builder.Property);
		}

		public static async Task<DownloadResponse> Process(this OnePropertyBuilder<File, DownloadResponse> builder, PyrusClient client)
		{
			return await client.DownloadFile(builder.Property);
		}


		public static async Task<AuthResponse> Process(this AuthRequestBuilder builder, PyrusClient client)
		{
			return await client.Auth(builder.Login, builder.SecretKey);
		}

		public static async Task<CatalogResponse> Process(this OnePropertyBuilder<int, CatalogResponse> builder, PyrusClient client)
		{
			return await client.GetCatalog(builder.Property);
		}

		public static async Task<ContactsResponse> Process(this EmptyBuilder<ContactsResponse> builder, PyrusClient client)
		{
			return await client.GetContacts();
		}

		public static async Task<FormResponse> Process(this OnePropertyBuilder<int, FormResponse> builder, PyrusClient client)
		{
			return await client.GetForm(builder.Property);
		}

		public static async Task<FormsResponse> Process(this EmptyBuilder<FormsResponse> builder, PyrusClient client)
		{
			return await client.GetForms();
		}

		public static async Task<ListsResponse> Process(this EmptyBuilder<ListsResponse> builder, PyrusClient client)
		{
			return await client.GetLists();
		}

		public static async Task<TaskListResponse> Process(this TaskListRequestBuilder builder, PyrusClient client)
		{
			return await client.GetTaskList(builder.ListId, builder.MaxItemCount, builder.IncludeArchived);
		}

		public static async Task<UploadResponse> Process(this UploadRequestBuilder builder, PyrusClient client)
		{
			if (builder.FileStream != null)
				return await client.UploadFile(builder.FileStream, builder.FileName);

			return await client.UploadFile(builder.FilePath);
		}

		public static async Task<SyncCatalogResponse> Process(this SyncCatalogRequestBuilder builder, PyrusClient client)
		{
			return await client.SyncCatalog(builder.CatalogId, builder);
		}

		public static async Task<CatalogResponse> Process(this CreateCatalogRequestBuilder builder, PyrusClient client)
		{
			return await client.CreateCatalog(builder);
		}

		public static async Task<RoleResponse> Process(this CreateRoleRequestBuilder builder, PyrusClient client)
		{
			return await client.CreateRole(builder);
		}

		public static async Task<RoleResponse> Process(this UpdateRoleRequestBuilder builder, PyrusClient client)
		{
			return await client.UpdateRole(builder.RoleId, builder);
		}

		public static async Task<RolesResponse> Process(this EmptyBuilder<RolesResponse> builder, PyrusClient client)
		{
			return await client.GetRoles();
		}

		public static async Task<MemberResponse> Process(this CreateMemberRequestBuilder builder, PyrusClient client)
		{
			return await client.CreateMember(builder);
		}

		public static async Task<MemberResponse> Process(this UpdateMemberRequestBuilder builder, PyrusClient client)
		{
			return await client.UpdateMember(builder.MemberId, builder);
		}

		public static async Task<MemberResponse> Process(this DeleteMemberRequestBuilder builder, PyrusClient client)
		{
			return await client.DeleteMember(builder.MemberId);
		}

		public static async Task<MembersResponse> Process(this EmptyBuilder<MembersResponse> builder, PyrusClient client)
		{
			return await client.GetMembers();
		}

		public static async Task<ProfileResponse> Process(this EmptyBuilder<ProfileResponse> builder, PyrusClient client)
		{
			return await client.GetProfile();
		}

		public static async Task<InboxResponse> Process(this OnePropertyBuilder<int, InboxResponse> builder, PyrusClient client)
		{
			return await client.GetInbox(builder.Property);
		}

		public static async Task<bool> ProcessToCsv(this FormRegisterRequestBuilder builder, PyrusClient client, string filePath, CsvSettings settings = null)
		{
			var csvResult = await ProcessToCsv(builder, client, settings);
			System.IO.File.WriteAllText(filePath, csvResult.Csv, settings?.Encoding ?? Encoding.UTF8);
			return csvResult.Success;
		}

		public static async Task<CsvResponse> ProcessToCsv(this FormRegisterRequestBuilder builder, PyrusClient client, CsvSettings settings = null)
		{
			FormRegisterRequest request = builder;
			request.Encoding = settings?.Encoding?.EncodingName;
			request.Delimiter = settings?.Delimiter;
			request.SimpleFormat = settings?.SimpleFormat ?? false;
			request.ResponseFormat = ResponseFormat.Csv;
			var response = await client.GetRegistry(builder.FormId, request);
			if (response?.ErrorCode != null)
				return new CsvResponse
				{
					Csv = $"Unexpected error occured: {JsonConvert.SerializeObject(response)}",
					Success = false
				};

			return new CsvResponse { Csv = response?.Csv, Success = true };
		}

		#endregion
	}

	public class CsvSettings
	{
		public Encoding Encoding { get; set; }
		public string Delimiter { get; set; }
		public bool SimpleFormat { get; set; }
	}
}
