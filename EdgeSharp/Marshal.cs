using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace EdgeSharp;

internal partial class Marshal
{
    public static object GetActiveObject(string progId, bool throwOnError = true)
    {
        ArgumentNullException.ThrowIfNull(progId);

        var hr = CLSIDFromProgIDEx(progId, out var clsid);
        if (hr < 0)
        {
            if (throwOnError)
                System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(hr);

            return null;
        }

        hr = GetActiveObject(clsid, IntPtr.Zero, out var obj);
        if (hr >= 0) return obj;
        if (throwOnError)
            System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(hr);

        return null;

    }

    [LibraryImport("ole32")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private static partial int CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string lpszProgId, out Guid lpclsid);

    [DllImport("oleaut32")]
    private static extern int GetActiveObject([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid, IntPtr pvReserved,
        [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
}