using System;
using System.Net;
using System.Runtime.CompilerServices;
using NetTelegraph.Interface;
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
        private const string mCreatePagetUri = "/createPage";
        private const string mEditAccountInfoUri = "/editAccountInfo";
        private const string mEditPage = "/editPage";
        private const string mGetPage = "/getPage";
        private const string mGetPageList = "/getPageList";
        private const string mGetViews = "/getViews";

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

        /// <summary>
        /// Use this method to create a new Telegraph page. On success, returns a Page object.
        /// </summary>
        /// <param name="accessToken">Required. Access token of the Telegraph account.</param>
        /// <param name="title">Required. Page title.</param>
        /// <param name="content">Required. Content of the page. </param>
        /// <param name="authorName">Author name, displayed below the article's title.</param>
        /// <param name="authorUrl">Profile link, opened when users click on the author's name below the title. 
        /// Can be any link, not necessarily to a Telegram profile or channel.</param>
        /// <param name="returnContent">If true, a content field will be returned in the Page object (see: Content format).</param>
        /// <returns></returns>
        public PageResult CreatePage(string accessToken, string title, INode[] content, string authorName = null,
            string authorUrl = null, bool returnContent = false)
        {
            RestRequest request = NewRestRequest(mCreatePagetUri);

            request.AddParameter("access_token", accessToken);
            request.AddParameter("title", title);
            //todo parse content parameter
            request.AddParameter("content", content);

            if(authorName != null)
                request.AddParameter("author_name", authorName);
            if (authorUrl != null)
                request.AddParameter("author_url", authorUrl);
            if (returnContent)
                request.AddParameter("return_content", true);

            return ExecuteRequest<PageResult>(request) as PageResult;
        }

        /// <summary>
        /// Use this method to update information about a Telegraph account. 
        /// Pass only the parameters that you want to edit.
        /// </summary>
        /// <param name="accessToken">Required. Access token of the Telegraph account.</param>
        /// <param name="shortName">New account name.</param>
        /// <param name="authorName">New default author name used when creating new articles.</param>
        /// <param name="authorUrl">New default profile link, opened when users click on the author's name below the title. 
        /// Can be any link, not necessarily to a Telegram profile or channel.</param>
        /// <returns>On success, returns an Account object with the default fields.</returns>
        public AccountResult EditAccountInfo(string accessToken, string shortName = null, string authorName = null, string authorUrl = null)
        {
            RestRequest request = NewRestRequest(mEditAccountInfoUri);

            request.AddParameter("access_token", accessToken);

            if(shortName != null)
                request.AddParameter("short_name", shortName);
            if (authorName != null)
                request.AddParameter("author_name", authorName);
            if (authorUrl != null)
                request.AddParameter("author_url", authorUrl);

            return ExecuteRequest<AccountResult>(request) as AccountResult;
        }

        //todo add editPage method
        //todo add getAccountInfo method

        /// <summary>
        /// Use this method to get a Telegraph page.
        /// </summary>
        /// <param name="path">Required. 
        /// Path to the Telegraph page (in the format Title-12-31, i.e. everything that comes after "http://telegra.ph/").</param>
        /// <param name="returnContent">If true, content field will be returned in Page object.</param>
        /// <returns>Returns a Page object on success.</returns>
        public PageResult GetPage(string path, bool returnContent = false)
        {
            RestRequest request = NewRestRequest(mGetPage);

            request.AddParameter("path", path);
            request.AddParameter("return_content", returnContent);

            return ExecuteRequest<PageResult>(request) as PageResult;
        }

        /// <summary>
        /// Use this method to get a list of pages belonging to a Telegraph account.
        /// </summary>
        /// <param name="accessToken">Required. Access token of the Telegraph account.</param>
        /// <param name="offset">Sequential number of the first page to be returned.</param>
        /// <param name="limit">Limits the number of pages to be retrieved.</param>
        /// <returns>Returns a PageList object, sorted by most recently created pages first.</returns>
        public PageListResult GetPageList(string accessToken, int offset = 0, int limit = 50)
        {
            RestRequest request = NewRestRequest(mGetPageList);

            request.AddParameter("access_token", accessToken);
            request.AddParameter("offset", offset != 0 ? offset : 0);
            request.AddParameter("limit", limit != 50 ? limit : 50);

            return ExecuteRequest<PageListResult>(request) as PageListResult;
        }

        /// <summary>
        /// Use this method to get the number of views for a Telegraph article. 
        /// </summary>
        /// <param name="path">Required. Path to the Telegraph page (in the format Title-12-31, where 12 is the month and 31 the day the article was first published).</param>
        /// <param name="year">Required if month is passed. If passed, the number of page views for the requested year will be returned.</param>
        /// <param name="month">Required if day is passed. If passed, the number of page views for the requested month will be returned.</param>
        /// <param name="day">Required if hour is passed. If passed, the number of page views for the requested day will be returned.</param>
        /// <param name="hour">If passed, the number of page views for the requested hour will be returned.</param>
        /// <returns>Returns a PageViews object on success. By default, the total number of page views will be returned.</returns>
        public PageViewsResult GetViews(string path, int? year = null, int? month = null, int? day = null, int? hour = null)
        {
            //todo test this
            RestRequest request = NewRestRequest(mGetViews);

            request.AddParameter("path", path);
            request.AddParameter("year", year);
            request.AddParameter("month", month);
            request.AddParameter("day", day);

            if (hour != null)
                request.AddParameter("hour", hour);

            return ExecuteRequest<PageViewsResult>(request) as PageViewsResult;
        }

        private object ExecuteRequest<T>(IRestRequest request) where T : class
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }

            throw new Exception(response.StatusDescription);
        }
    }
}