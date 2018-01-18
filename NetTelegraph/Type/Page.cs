using Newtonsoft.Json;

namespace NetTelegraph.Type
{
    /// <summary>
    /// This object represents a page on Telegraph.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Path to the page.
        /// </summary>
        [JsonProperty("path", Required = Required.Always)]
        public string Path { get; set; }

        /// <summary>
        /// URL of the page.
        /// </summary>
        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        /// <summary>
        /// Title of the page.
        /// </summary>
        [JsonProperty("title", Required = Required.Always)]
        public string Title { get; set; }

        /// <summary>
        /// Description of the page.
        /// </summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>
        /// Optional. 
        /// Name of the author, displayed below the title.
        /// </summary>
        [JsonProperty("author_name", Required = Required.AllowNull)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Optional. 
        /// Profile link, opened when users click on the author's name below the title.  
        /// Can be any link, not necessarily to a Telegram profile or channel.
        /// </summary>
        [JsonProperty("author_url", Required = Required.AllowNull)]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Optional. 
        /// Image URL of the page.
        /// </summary>
        [JsonProperty("image_url", Required = Required.AllowNull)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Optional. 
        /// Content of the page.
        /// </summary>
        [JsonProperty("content", Required = Required.AllowNull)]
        public NodeElements[] Content { get; set; }

        /// <summary>
        /// Number of page views for the page.
        /// </summary>
        [JsonProperty("views", Required = Required.Always)]
        public int Views { get; set; }

        /// <summary>
        /// Optional. 
        /// Only returned if access_token passed. 
        /// True, if the target Telegraph account can edit the page.
        /// </summary>
        [JsonProperty("can_edit", Required = Required.AllowNull)]
        public bool CanEdit { get; set; }

        //todo rewoke
        internal static Interface.INode[] ParseArray(Interface.INode[] nodeArrayNodes)
        {
            return null;
            //return JsonConvert.DeserializeObject<NodeElements[]>(nodeArrayNodes);

            //return jsonArray.Cast<JObject>().Select(jobject => new PhotoSizeInfo(jobject)).ToArray();
            //return JsonConvert.DeserializeObject<Node[]>(json);
        }

        internal static object CheckFormat(Interface.INode[] node)
        {
            return null;
        }
    }
}
