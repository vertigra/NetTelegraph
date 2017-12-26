using Mock4Net.Core;

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
            AddNewRouter("/createPage", ResponseString.PageResultResponse);

            AddNewRouter("/", ResponseString.CommonBadResponse, ServerBadResponse, 401);
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
}
