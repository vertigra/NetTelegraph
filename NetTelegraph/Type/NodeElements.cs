namespace NetTelegraph.Type
{
    /// <summary>
    /// 
    /// </summary>
    public class NodeElements
    {
        
        //todo use enum ?
        /// <summary>
        /// Name of the DOM element. 
        /// Available tags: a, aside, b, blockquote, br, code, em, figcaption, figure, h3, h4, hr, i, iframe, img, li, ol, p, pre, s, strong, u, ul, video.
        /// </summary>
        public string Tag { get; set; }

        //todo check use enum ?
        /// <summary>
        /// Optional. 
        /// Attributes of the DOM element. 
        /// Key of object represents name of attribute, value represents value of attribute. 
        /// Available attributes: href, src.
        /// </summary>
        public object Attrs { get; set; }

        /// <summary>
        /// Optional. List of child nodes for the DOM element.
        /// </summary>
        public Node[] Children { get; set; }
    }
}
