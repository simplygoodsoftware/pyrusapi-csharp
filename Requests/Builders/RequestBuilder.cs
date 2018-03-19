using System.Threading.Tasks;
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
	}
}
