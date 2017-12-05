using System;
using System.Net;
using System.Runtime.CompilerServices;
using NetTelegraph.Result;
using Newtonsoft.Json;
using RestSharp;

#if DEBUG
[assembly: InternalsVisibleTo("NetTelegraph.Test")]
#endif

namespace NetTelegraph
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegraphBot
    {

        /// <summary>
        /// 
        /// </summary>
        public TelegraphBot()
        {
            mRestClient = new RestClient("https://api.telegra.ph");
        }

        internal RestClient mRestClient { private get; set; }

        private const string mCreateAccountUri = "/createAccount";

        private static RestRequest NewRestRequest(string uri)
        {
            RestRequest request = new RestRequest(string.Format(uri), Method.POST);

            return request;
        }

        /// <summary>
        /// Use this method to create a new Telegraph account.
        /// Most users only need one account, but this can be useful for channel administrators
        /// who would like to keep individual author names and profile links for each of their channels.
        /// </summary>
        /// <param name="shortName">Required. Account name, helps users with several accounts remember which they are currently using. Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.</param>
        /// <param name="authorName">Default author name used when creating new articles.</param>
        /// <param name="authorUrl">Default profile link, opened when users click on the author's name below the title. Can be any link, not necessarily to a Telegram profile or channel.</param>
        /// <returns>
        /// On success, returns an Account object with the regular fields and an additional access_token field.
        /// </returns>
        public AccountResult CreateAccount(string shortName, string authorName = null, string authorUrl = null)
        {
            //todo exp with seralize object
            RestRequest request = NewRestRequest(mCreateAccountUri);

            request.AddParameter("short_name", shortName);

            if (authorName != null)
                request.AddParameter("author_name", authorName);
            if (authorUrl != null)
                request.AddParameter("author_url", authorUrl);

            return ExecuteRequest<AccountResult>(request) as AccountResult;
        }

        private object ExecuteRequest<T>(IRestRequest request) where T : class
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (typeof (T) == typeof (AccountResult))
                    return JsonConvert.DeserializeObject<AccountResult>(response.Content);
            }

            throw new Exception(response.StatusDescription);
        }
    }
}