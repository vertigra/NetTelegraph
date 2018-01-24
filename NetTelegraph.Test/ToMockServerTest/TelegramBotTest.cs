using System;
using System.Linq;
using Mock4Net.Core;
using NetTelegraph.Enum;
using NetTelegraph.Test.MockServers;
using NetTelegraph.Type;
using NUnit.Framework;
using RestSharp;

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

        [Test]
        public void CreatePageTest()
        {
            NodeElements[] content = {

                new NodeElements
                {
                    Tag = Tag.br
                    
                },

                new NodeElements
                {
                    Tag = Tag.br
                }
            };

            mTelegraphBotOkResponse.CreatePage("TestAccessToken", "TestTitle", content, "TestAuthorName",
                "TestAuthorUrl", true);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/createPage").UsingPost());
            
            CommonUtils.PrintResult(request);

            //todo end this
        }

        [Test]
        public void EditAccountInfoTest()
        {
            mTelegraphBotOkResponse.EditAccountInfo("TestAccessToken", "TestShortName", "TestAuthorName",
                "TestAuthorUrl");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/editAccountInfo").UsingPost());

            CommonUtils.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("access_token=TestAccessToken&" +
                                "short_name=TestShortName&" +
                                "author_name=TestAuthorName&" +
                                "author_url=TestAuthorUrl", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/editAccountInfo", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(
                    () =>
                        mTelegraphBotBadResponse.EditAccountInfo("TestAccessToken", "TestShortName", "TestAuthorName",
                            "TestAuthorUrl"));
            });
        }

        [Test]
        public void GetPageTest()
        {
            mTelegraphBotOkResponse.GetPage("TestPath");

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/getPage").UsingPost());

            CommonUtils.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("path=TestPath&return_content=False", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/getPage", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(() => mTelegraphBotBadResponse.GetPage("TestPath"));
            });
        }

        [Test]
        public void GetPageListTest()
        {
            mTelegraphBotOkResponse.GetPageList("TestAccessToken", limit:100);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/getPageList").UsingPost());

            CommonUtils.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("access_token=TestAccessToken&offset=0&limit=100", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/getPageList", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(() => mTelegraphBotBadResponse.GetPageList("TestAccessToken", limit: 100));
            });
        }
    }
}
