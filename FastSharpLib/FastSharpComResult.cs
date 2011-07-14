using System.Runtime.InteropServices;

namespace FastSharpLib
{
    [ComVisible(true), GuidAttribute("F6D7CA1D-88B3-4303-BD7D-BF9D74B3ECB6")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Jemts.FastSharpComResult")]
    public class FastSharpComResult : IFastSharpComResult
    {
        public string Output { get; set; }
        public bool HasErrors { get; set; }
    }
}