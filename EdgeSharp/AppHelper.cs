using System.Diagnostics;
using SolidEdgeFramework;
using SolidEdgeSDK;

namespace EdgeSharp;

public class AppHelper
{
    /// <summary>
    ///     Checks if Solid Edge application is running.
    /// </summary>
    /// <returns>Returns true if Solid Edge application is running, otherwise false.</returns>
    public static bool IsSolidEdgeRunning()
    {
        try
        {
            Marshal.GetActiveObject("SolidEdge.Application");
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Establishes a connection with the Solid Edge application.
    /// </summary>
    /// <param name="startIfNotRunning">Specifies whether to start a new instance of Solid Edge if it is not already running.</param>
    /// <returns>
    ///     Returns an instance of the Solid Edge application if the connection is successful, or null if the connection
    ///     is not established.
    /// </returns>
    public static Application? Connect(bool startIfNotRunning = true)
    {
        Application? app;
        if (!startIfNotRunning && !IsSolidEdgeRunning()) return null;
        if (IsSolidEdgeRunning())
        {
            OleMessageFilter.Register();
            app = (Application)Marshal.GetActiveObject(PROGID.SolidEdge_Application);
            return app;
        }

        OleMessageFilter.Register();
        app = (Application)Activator.CreateInstance(Type.GetTypeFromProgID(PROGID.SolidEdge_Application) ??
                                                    throw new InvalidOperationException())!;
        return app;
    }

    /// <summary>
    ///     Stops the first found running instance of Solid Edge gracefully.
    /// </summary>
    public static void StopSolidEdge()
    {
        try
        {
            var app = (Application)Marshal.GetActiveObject(PROGID.SolidEdge_Application);
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        catch
        {
            // ignored
        }
    }

    /// <summary>
    ///     Stops specific running instance of Solid Edge application gracefully.
    /// </summary>
    /// <param name="app">The Solid Edge application instance to stop.</param>
    public static void StopSolidEdge(Application app)
    {
        app.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
    }

    /// <summary>
    ///     Stops all running instances of Solid Edge gracefully.
    /// </summary>
    public static void StopAllSolidEdge()
    {
        while (IsSolidEdgeRunning()) StopSolidEdge();
    }

    /// <summary>
    ///     Kills all running Solid Edge processes.
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