using System;
using System.Linq;
using Mock4Net.Core;
using NetTelegraph.Enum;
using NetTelegraph.Test.MockServers;
using NetTelegraph.Type;
using NUnit.Framework;
using RestSharp;
using Node = NetTelegraph.Interface.Node;

namespace NetTelegraph.Test.ToMockServerTest
{
    [TestFixture]
    internal class TelegramBotTest
    {
        private const int mOkServerPort = 8091;
        private const int mBadServerPort = 8092;

        private readonly TelegraphBot mTelegraphBotOkResponse = new TelegraphBot
        {
            mRestClient = new RestClient("http://localhost:" + mOkServerPort)
        };

        private readonly TelegraphBot mTelegraphBotBadResponse = new TelegraphBot
        {
            mRestClient = new RestClient("http://localhost:" + mBadServerPort)
        };

        [OneTimeSetUp]
        public static void OnStart()
        {
            MockServer.Start(mOkServerPort, mBadServerPort);
        }

        [OneTimeTearDown]
        public static void OnStop()
        {
            MockServer.Stop();
        }

        [Test]
        public void CreateAccountTest()
        {
            mTelegraphBotOkResponse.CreateAccount("TestShortName", "TestAuthorName", "TestAuthorUri");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/createAccount").UsingPost());

            CommonUtils.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("short_name=TestShortName&" +
                                "author_name=TestAuthorName&" +
                                "author_url=TestAuthorUri", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/createAccount", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(
                    () => mTelegraphBotBadResponse.CreateAccount("TestShortName"));
            });
        }

        [Test, Ignore("Fails")]
        public void CreatePageTest()
        {
            Node[] content = {

                new NodeElements
                {
                    Tag = Tag.br
                    
                },

                new NodeElements
                {
                    Tag = Tag.br
                }
            };

            mTelegraphBotOkResponse.CreatePage("TestAccessToken", "TestTitle", "TestAuthorName",
                "TestAuthorUrl", true);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/createPage").UsingPost());

        }
    }
}
