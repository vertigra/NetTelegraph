using Newtonsoft.Json;

namespace NetTelegraph.Type
{
    /// <summary>
    /// This object represents the number of page views for a Telegraph article.
    /// </summary>
    public class PageViews
    {
        /// <summary>
        /// Number of page views for the target page.
        /// </summary>
        [JsonProperty("views", Required = Required.Always)]
        public int Views { get; set; }
    }
}
