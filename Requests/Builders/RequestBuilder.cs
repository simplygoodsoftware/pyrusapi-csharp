using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

		public static UpdateCatalogRequestBuilder UpdateCatalog(int catalogId)
		{
			return new UpdateCatalogRequestBuilder(catalogId);
		}

		public static CreateCatalogRequestBuilder CreateCatalog(string name)
		{
			return new CreateCatalogRequestBuilder(name);
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

		public static async Task<UpdateCatalogResponse> Process(this UpdateCatalogRequestBuilder builder, PyrusClient client)
		{
			return await client.UpdateCatalog(builder.CatalogId, builder);
		}

		public static async Task<CatalogResponse> Process(this CreateCatalogRequestBuilder builder, PyrusClient client)
		{
			return await client.CreateCatalog(builder);
		}

		#endregion
	}
}
