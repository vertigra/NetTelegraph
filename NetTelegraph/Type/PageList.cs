using Newtonsoft.Json;

namespace NetTelegraph.Type
{
    /// <summary>
    /// This object represents a list of Telegraph articles belonging to an account. 
    /// Most recently created articles first.
    /// </summary>
    public class PageList
    {
        /// <summary>
        /// Total number of pages belonging to the target Telegraph account.
        /// </summary>
        [JsonProperty("total_count", Required = Required.Always)]
        public int TotalCount { get; set; }

        /// <summary>
        /// Requested pages of the target Telegraph account.
        /// </summary>
        [JsonProperty("pages", Required = Required.Always)]
        public Page[] Pages { get; set; }
    }
}
