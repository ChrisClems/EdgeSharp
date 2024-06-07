using System.Diagnostics.CodeAnalysis;
using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class ApplicationExtensions
{

    [Flags]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum BackgroundOptions
    {
        None = 0,
        Invisible = 1 << 0, // 1
        HideAlerts = 1 << 1, // 2
        NonInteractive = 1 << 2, // 4
        NoScreenUpdating = 1 << 3, // 8
        DelayCompute = 1 << 4 // 16
    }

    // Provide an extension that takes an action so that code can be run inline with DoIdle()
    // Makes slightly less ugly code when DoIdle() is required after each method in a long string of methods
    public static void DoIdle(this Application app, Action action)
    {
        action();
        app.DoIdle();
    }

    // Return enum of options that represent the backgrounding options for an Application
    public static BackgroundOptions GetBackgroundOptions(this Application app)
    {
        bool[] optionsArray = [!app.Visible, !app.DisplayAlerts, !app.Interactive, !app.ScreenUpdating, app.DelayCompute];

        BackgroundOptions backgroundOptions = BackgroundOptions.None;
        for (int i = 0; i < optionsArray.Length; i++)
        {
            if (optionsArray[i])
            {
                backgroundOptions |= (BackgroundOptions)(1 << i);
            }
        }
        return backgroundOptions;
    }
    
    // Returns a bitmask representing the boolean values that represent
    // various background options of the application object
    public static int GetBackgroundOptionsMask(this Application app)
    {
        return (int)GetBackgroundOptions(app);
    }

    public static void SetBackgroundOptions(this Application app, BackgroundOptions options)
    {
        SetBackgroundOptionsMask(app, (int)options);
    }
    
    // Set background options for Application using a bitmask
    public static void SetBackgroundOptionsMask(this Application app, int bitMask)
    {
        var options = new List<bool>();
        
        foreach (BackgroundOptions option in Enum.GetValues(typeof(BackgroundOptions)))
        {
            if (option == BackgroundOptions.None) continue; // Skip the 'None' option
            // Check if the current option's bit is set in the mask
            options.Add((bitMask & (int)option) != 0);
        }
        app.DoIdle(() => app.Visible = !options[0]);
        app.DoIdle(() => app.DisplayAlerts = !options[1]);
        app.DoIdle(() => app.Interactive = !options[2]);
        app.DoIdle(() => app.ScreenUpdating = !options[3]);
        app.DoIdle(() => app.DelayCompute = options[4]);
// TODO: Check new mask for match with input. Throw exception if not.
    }
}