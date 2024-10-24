namespace Pyrus.ApiClient.Requests.Builders
{
    public class DeleteMemberRequestBuilder
    {
        public int MemberId { get; }

        public DeleteMemberRequestBuilder(int memberId)
        {
            MemberId = memberId;
        }

    }
}