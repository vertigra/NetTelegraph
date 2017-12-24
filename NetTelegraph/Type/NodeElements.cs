using NetTelegraph.Enum;

namespace NetTelegraph.Type
{
    /// <summary>
    /// This object represents a DOM element node.
    /// </summary>
    public class NodeElements : Interface.Node
    {
        /// <summary>
        /// Name of the DOM element. 
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// Optional. 
        /// Attributes of the DOM element. 
        /// Key of object represents name of attribute, value represents value of attribute. 
        /// </summary>
        public Attrs Attrs { get; set; }

        /// <summary>
        /// Optional. List of child nodes for the DOM element.
        /// </summary>
        public Node[] Children { get; set; }
    }
}
