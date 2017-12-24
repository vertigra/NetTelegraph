namespace NetTelegraph.Type
{
    /// <summary>
    /// String which represents a DOM text node 
    /// See <see href="http://telegra.ph/api#Node">API</see>
    /// </summary>
    public class Node : Interface.Node
    {
        /// <summary>
        /// 
        /// </summary>
        public string DOMTextNode { get; set; }
    }
}
