namespace Pyrus.ApiClient.Requests.Builders
{
	public class AuthRequestBuilder
	{
		internal string Login { get; set; }

		internal string SecretKey { get; set; }

		internal AuthRequestBuilder(string login, string secretKey)
		{
			Login = login;
			SecretKey = secretKey;
		}
	}
}