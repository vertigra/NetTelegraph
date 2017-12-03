using NetTelegraph.Result;
using RestSharp;

namespace NetTelegraph
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegraphBot
    {
        RestClient mRestClient = new RestClient("https://api.telegra.ph");

        public AccountResult CreateAccount()
        {

            return null;
        }
    }
}