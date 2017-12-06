using NetTelegraph.Result;
using NetTelegraph.Test.TestObject;
using NetTelegraph.Type;
using Newtonsoft.Json;

namespace NetTelegraph.Test.MockServers
{
    internal class ResponseString
    {
        private static readonly AccountResult mAccountResult = new AccountResult
        {
            Ok = true,
            Result = new Account
            {
                ShortName = "TestShortName",
                AuthorName = "TestAuthorName",
                AuthUrl = "TestAuthorUrl",
                AccessToken = "TestAccesToken",
                AuthorUrl = "TestAuthUrl",
                PageCount = 123
            }
        };

        internal static string AccountResultResponse { get; } = JsonConvert.SerializeObject(mAccountResult, Formatting.Indented);

        private static readonly BadResponse mBadResponse = new BadResponse
        {
            Ok = false,
            ErrorCode = 401,
            Description = "Unauthorized"
        };

        internal static string CommonBadResponse { get; } = JsonConvert.SerializeObject(mBadResponse, Formatting.Indented);
    }
}
