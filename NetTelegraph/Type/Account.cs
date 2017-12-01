using Newtonsoft.Json;

namespace NetTelegraph.Type
{
    /// <summary>
    /// This object represents a Telegraph account.
    /// See <see href="http://telegra.ph/api#Account">API</see>
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account name, helps users with several accounts remember which they are currently using. 
        /// Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
        /// </summary>
        [JsonProperty("short_name", Required = Required.Always)]
        public string ShortName { get; set; }

        /// <summary>
        /// Default author name used when creating new articles.
        /// </summary>
        [JsonProperty("author_name", Required = Required.Always)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Profile link, opened when users click on the author's name below the title. 
        /// Can be any link, not necessarily to a Telegram profile or channel.
        /// </summary>
        [JsonProperty("author_url", Required = Required.Always)]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Optional. Only returned by the createAccount and revokeAccessToken method. 
        /// Access token of the Telegraph account.
        /// </summary>
        [JsonProperty("access_token", Required = Required.AllowNull)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Optional. URL to authorize a browser on telegra.ph and connect it to a Telegraph account. 
        /// This URL is valid for only one use and for 5 minutes only.
        /// </summary>
        [JsonProperty("auth_url", Required = Required.AllowNull)]
        public string AuthUrl { get; set; }

        /// <summary>
        /// Optional. Number of pages belonging to the Telegraph account.
        /// </summary>
        [JsonProperty("page_count", Required = Required.AllowNull)]
        public string PageCount { get; set; }
    }
}
