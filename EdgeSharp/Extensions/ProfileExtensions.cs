using System.Runtime.InteropServices;
using SolidEdgePart;
using Thread = System.Threading.Thread;

namespace EdgeSharp.Extensions;

public static class ProfileExtensions
{
    /// <summary>
    ///     Retries the paste operation on a profile in Solid Edge.
    /// </summary>
    /// <param name="profile">The profile to paste.</param>
    /// <param name="retryCount">The maximum number of retry attempts. Default value is -1 (unlimited).</param>
    /// <param name="retryDelay">The delay (in milliseconds) between each retry attempt. Default value is 100 milliseconds.</param>
    /// <exception cref="System.Exception">Thrown when an error occurs while pasting the profile.</exception>
    public static void PasteRetry(this Profile profile, int retryCount = -1, int retryDelay = 100)
    {
        const uint CLIPBRD_E_CANT_OPEN = 0x800401D0;
        while (retryCount != 0)
            try
            {
                profile.Paste();
                break;
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != CLIPBRD_E_CANT_OPEN)
                    throw new Exception(
                        "Error pasting text profile. Try opening and closing the text profile dialog in Solid Edge to fix and re-run.",
                        ex);
                if (retryCount > 0) retryCount--;
                Thread.Sleep(retryDelay);
            }
    }
}