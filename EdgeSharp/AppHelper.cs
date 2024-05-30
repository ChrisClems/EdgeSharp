using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SolidEdgeFramework;

namespace EdgeSharp;

public class AppHelper
{

    public static bool IsSolidEdgeRunning()
    {
        try
        {
            var app = (Application)Marshal.GetActiveObject("SolidEdge.Application");
            return true;
        }
        catch
        {
            return false;
        }
    }

}