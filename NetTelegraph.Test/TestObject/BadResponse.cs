using Newtonsoft.Json;

namespace NetTelegraph.Test.TestObject
{
    internal class BadResponse
    {
        [JsonProperty("ok")]
        internal bool Ok { get; set; }

        [JsonProperty("error_code")]
        internal int ErrorCode { get; set; }

        [JsonProperty("description")]
        internal string Description { get; set; }
    }
}
