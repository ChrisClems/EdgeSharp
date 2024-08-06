using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class ApplicationExtensions
{

    [Flags]
    public enum BackgroundOptions
    {
        None = 0,
        Invisible = 1 << 0, // 1
        HideAlerts = 1 << 1, // 2
        NonInteractive = 1 << 2, // 4
        NoScreenUpdating = 1 << 3, // 8
        DelayCompute = 1 << 4 // 16
    }

    /// <summary>
    /// Executes a provided action before running DoIdle().
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <param name="action">The action to be executed.</param>
    public static void DoIdle(this Application app, Action action)
    {
        action();
        app.DoIdle();
    }

    /// <summary>
    /// Executes an action from a list of actions and calls DoIdle() to allow Solid Edge to perform idle time activities.
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <param name="actions">The actions to be executed.</param>
    public static void DoIdle(this Application app, Action[] actions)
    {
        foreach (var action in actions)
        {
            action();
            app.DoIdle();
        }
    }

    /// <summary>
    /// Returns the background options of the application object.
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <returns>The background options of the application.</returns>
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
    
    /// <summary>
    /// Returns a bitmask representing the boolean values that represent various background options of the application object.
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <returns>A bitmask representing the boolean values that represent various background options of the application object.</returns>
    public static int GetBackgroundOptionsMask(this Application app)
    {
        return (int)GetBackgroundOptions(app);
    }

    /// <summary>
    /// Updates the background options for a Solid Edge application object.
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <param name="options">The background options to be set.</param>
    public static void SetBackgroundOptions(this Application app, BackgroundOptions options)
    {
        var optionsMask = (int)options;
        SetBackgroundOptionsMask(app, optionsMask);
        var currentMask = GetBackgroundOptionsMask(app);
        if (optionsMask != currentMask)
        {
            throw new Exception("Background options failed to update");
        }
    }
    
    /// <summary>
    /// Sets the background options of the Solid Edge application object using a bitmask.
    /// </summary>
    /// <param name="app">The Solid Edge application object.</param>
    /// <param name="bitMask">The bitmask representing the boolean values that represent the various background options.</param>
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

        var currentMask = app.GetBackgroundOptionsMask();
        if (bitMask != currentMask)
        {
            throw new Exception("Background options failed to update");
        }
    }
}