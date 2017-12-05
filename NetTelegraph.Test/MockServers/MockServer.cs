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

            AddNewRouter("/createAccount", ResponseString.AccountResultResponse);
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

    //todo move to common class and exp with seralize object
    internal static class ResponseString
    {
        internal static string AccountResultResponse { get; } = new JObject(
            new JProperty("ok", true),
            new JProperty("result",
                new JObject(
                new JProperty("short_name", "TestShortName"),
                new JProperty("author_name", "TestAuthorName"),
                new JProperty("author_url", "TestAuthorUrl"),
                new JProperty("access_token", "TestAccesToken"),
                new JProperty("auth_url", "TestAuthUrl"),
                new JProperty("page_count", 123)))).ToString();
    }
}
