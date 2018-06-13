using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Pyrus.ApiClient.Responses;
using PyrusApiClient;
using PyrusApiClient.Builders;

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

		public static OneIntPropertyBuilder<TaskResponse> GetTask(int taskId)
		{
			return new OneIntPropertyBuilder<TaskResponse>(taskId);
		}

		public static OneIntPropertyBuilder<DownloadResponse> DownloadFile(int fileId)
		{
			return new OneIntPropertyBuilder<DownloadResponse>(fileId);
		}

		public static AuthRequestBuilder Auth(string login, string secretKey)
		{
			return new AuthRequestBuilder(login, secretKey);
		}

		public static OneIntPropertyBuilder<ContactsResponse> GetCatalog(int catalogId)
		{
			return new OneIntPropertyBuilder<ContactsResponse>(catalogId);
		}

		public static OneIntPropertyBuilder<FormResponse> GetForm(int formId)
		{
			return new OneIntPropertyBuilder<FormResponse>(formId);
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

		public static async Task<TaskResponse> Process(this OneIntPropertyBuilder<TaskResponse> builder, PyrusClient client)
		{
			return await client.GetTask(builder.IntProperty);
		}

		public static async Task<DownloadResponse> Process(this OneIntPropertyBuilder<DownloadResponse> builder, PyrusClient client)
		{
			return await client.DownloadFile(builder.IntProperty);
		}

		public static async Task<AuthResponse> Process(this AuthRequestBuilder builder, PyrusClient client)
		{
			return await client.Auth(builder.Login, builder.SecretKey);
		}

		public static async Task<CatalogResponse> Process(this OneIntPropertyBuilder<ContactsResponse> builder, PyrusClient client)
		{
			return await client.GetCatalog(builder.IntProperty);
		}

		public static async Task<ContactsResponse> Process(this EmptyBuilder<ContactsResponse> builder, PyrusClient client)
		{
			return await client.GetContacts();
		}

		public static async Task<FormResponse> Process(this OneIntPropertyBuilder<FormResponse> builder, PyrusClient client)
		{
			return await client.GetForm(builder.IntProperty);
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
	}
}
