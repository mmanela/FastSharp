using System.Runtime.InteropServices;

namespace FastSharpLib
{
    [ComVisible(true), Guid("CEFD2AD9-EA74-40ff-89A5-37383EB9C3F8")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IFastSharpCom
    {
        [DispId(1)]
        FastSharpComResult ExecuteSnippet(string snippet);

        [DispId(2)]
        FastSharpComResult CompileSnippet(string snippet);
    }
}