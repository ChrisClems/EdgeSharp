using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Diagnostics;
using SolidEdgeFramework;
using SolidEdgeSDK;

namespace EdgeSharp;

public class AppHelper
{
    /// <summary>
    /// Checks if Solid Edge application is running.
    /// </summary>
    /// <returns>Returns true if Solid Edge application is running, otherwise false.</returns>
    public static bool IsSolidEdgeRunning()
    {
        try
        {
            var comObjectHandle = Marshal.GetActiveObject("SolidEdge.Application");
            return comObjectHandle != null;
        }
        catch
        {
            return false;
        }
    }

    public static Application StartOrConnect()
    {
        try
        {
            var app = (Application)Marshal.GetActiveObject(PROGID.SolidEdge_Application);
            return app;
        }
        catch
        {
            var app = (Application)Activator.CreateInstance(Type.GetTypeFromProgID(PROGID.SolidEdge_Application) ?? throw new InvalidOperationException())!;
            return app;
        }
    }
    
    /// <summary>
    /// Stops the first found running instance of Solid Edge gracefully.
    /// </summary>
    public static void StopSolidEdge()
    {
        try
        {
            var app = (Application)Marshal.GetActiveObject(PROGID.SolidEdge_Application);
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
        }
        catch
        {
            // ignored
        }
    }

    /// <summary>
    /// Stops specific running instance of Solid Edge application gracefully.
    /// </summary>
    /// <param name="app">The Solid Edge application instance to stop.</param>
    public static void StopSolidEdge(Application app)
    {
        app.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        app = null;
    }

    /// <summary>
    /// Stops all running instances of Solid Edge gracefully.
    /// </summary>
    public static void StopAllSolidEdge()
    {
        while (IsSolidEdgeRunning())
        {
            StopSolidEdge();
        }
    }

    /// <summary>
    /// Kills all running Solid Edge processes.
    /// </summary>
    public static void KillAllSolidEdgeProcs()
    {
        foreach (var process in Process.GetProcesses())
        {
            if (process.ProcessName != "Edge") continue;
            process.Kill();
        }
    }
}