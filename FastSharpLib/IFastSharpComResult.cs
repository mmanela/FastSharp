using System.Runtime.InteropServices;

namespace FastSharpLib
{
    [ComVisible(true), Guid("FC4C7FA4-0EEB-4674-9C3C-62DE0FCB2D91")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IFastSharpComResult
    {
        [DispId(1)]
        string Output { get; set; }

        [DispId(2)]
        bool HasErrors { get; set; }
    }
}