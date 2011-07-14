using System.Runtime.Serialization;
using FastSharpLib;

namespace FastSharpApplication
{
    [DataContract]
    public class FastSharpFormState
    {
        [DataMember]
        public CodeLanguage SelectedLanguage { get; set; }

        [DataMember]
        public string CodeText { get; set; }
    }
}