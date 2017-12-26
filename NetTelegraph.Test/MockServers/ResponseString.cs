using NetTelegraph.Result;
using NetTelegraph.Test.TestObject;
using NetTelegraph.Type;
using Newtonsoft.Json;
using Node = NetTelegraph.Type.Node;

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

        internal static string AccountResultResponse { get; } = JsonConvert.SerializeObject(mAccountResult,
            Formatting.Indented);

        private static readonly PageResult mPageResult = new PageResult
        {
            Ok = true,
            Result = new Page
            {
                Path = "TestPath",
                Url = "TestUrl",
                Title = "TestTitle",
                Description = "TestDescription",
                AuthorName = "TestAuthorName",
                AuthorUrl = "TestAuthorUrl",
                ImageUrl = "TestImageUrl",
                Content = new[]
                {
                    new Node
                    {
                       DOMTextNode = "TestDOMTextNode"
                    },

                    new Node
                    {
                       DOMTextNode = "TestDOMTextNode"
                    }
                },
                Views = 123,
                CanEdit = true
            }
        };

        internal static string PageResultResponse { get; } = JsonConvert.SerializeObject(mPageResult,
            Formatting.Indented);

        private static readonly BadResponse mBadResponse = new BadResponse
        {
            Ok = false,
            ErrorCode = 401,
            Description = "Unauthorized"
        };

        internal static string CommonBadResponse { get; } = JsonConvert.SerializeObject(mBadResponse, Formatting.Indented);
    }
}
