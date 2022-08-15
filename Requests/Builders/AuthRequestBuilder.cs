namespace Pyrus.ApiClient.Requests.Builders
{
	public class AuthRequestBuilder
	{
		internal string Login { get; set; }

		internal string SecretKey { get; set; }

		internal int? PersonId { get; set; }

		internal AuthRequestBuilder(string login, string secretKey) : this(login, secretKey, null) { }
		internal AuthRequestBuilder(string login, string secretKey, int? personId)
		{
			Login = login;
			SecretKey = secretKey;
			PersonId = personId;
		}
	}
}