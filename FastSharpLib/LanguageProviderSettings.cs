using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FastSharpLib
{
    [DataContract]
    public class LanguageProviderSettings
    {
        [DataMember]
        public List<string> References { get; set; }

        [DataMember]
        public List<string> Imports { get; set; }

        [DataMember]
        public IDictionary<string, string> ProviderOptions { get; set; }
    }
}