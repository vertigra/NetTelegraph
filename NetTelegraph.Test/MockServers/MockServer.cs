using Mock4Net.Core;
using Newtonsoft.Json.Linq;

namespace NetTelegraph.Test.MockServers
{
    internal static class MockServer
    {
        internal static FluentMockServer ServerOkResponse { get; private set; }
        internal static FluentMockServer ServerBadResponse { get; private set; }

        internal static void Start(int? portOkResponse = null, int? portBadResponse = null)
        {
            if (portOkResponse != null)
                ServerOkResponse = FluentMockServer.Start(portOkResponse.Value);
            if (portBadResponse != null)
                ServerBadResponse = FluentMockServer.Start(portBadResponse.Value);

            AddNewRouter("/", ResponseString.AccountResultResponse);
        }

        internal static void AddNewRouter(string url, string responseString, FluentMockServer server = null, int? statusCode = null)
        {
            if (statusCode == null)
                statusCode = 200;

            if (server == null)
                server = ServerOkResponse;

            server.Given(
                Requests.WithUrl(url).UsingPost()
                )
                .RespondWith(
                    Responses
                        .WithStatusCode((int) statusCode)
                        .WithBody(responseString)
                );
        }

        internal static void Stop()
        {
            ServerOkResponse?.Stop();
            ServerBadResponse?.Stop();
        }
    }

    internal static class ResponseString
    {
        internal static string AccountResultResponse { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject("short_name", "TestShortName"),
                new JObject("author_name", "TestAuthorName"),
                new JObject("author_url", "TestAuthorUrl"),
                new JObject("access_token", "TestAccesToken"),
                new JObject("auth_url", "TestAuthUrl"),
                new JObject("page_count", 123))).ToString();
    }
}
