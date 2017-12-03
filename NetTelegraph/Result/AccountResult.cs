using NetTelegraph.Type;
using Newtonsoft.Json;

namespace NetTelegraph.Result
{
    /// <summary>
    /// The response contains a JSON object, which always has a Boolean field ok. 
    /// If ok equals true, the request was successful, and the result of the query can be found in the result field.
    /// In case of an unsuccessful request, ok equals false, and the error is explained in the error field (e.g. SHORT_NAME_REQUIRED).
    /// </summary>
    public class AccountResult
    {
        /// <summary>
        /// If ok equals true, the request was successful, false otherwise.
        /// </summary>
        [JsonProperty("ok", Required = Required.Always)]
        public bool Ok { get; set; }

        /// <summary>
        /// Result of the query.
        /// </summary>
        [JsonProperty("result", Required = Required.Always)]
        public Account Result { get; set; }
    }
}
