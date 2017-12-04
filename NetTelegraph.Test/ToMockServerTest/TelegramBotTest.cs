using NetTelegraph;
using NUnit.Framework;
using RestSharp;

namespace NetTelegraph.Test.ToMockServerTest
{
    [TestFixture]
    internal class TelegramBotTest
    {
        private const int mOkServerPort = 8091;
        private const int mBadServerPort = 8092;

        private readonly TelegraphBot mTelegraphBot = new TelegraphBot
        {
            RestClient = new RestClient("http://localhost:" + mOkServerPort)
        };
    }
}
