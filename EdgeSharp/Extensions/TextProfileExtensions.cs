using System.Runtime.InteropServices;
using SolidEdgeFrameworkSupport;

namespace EdgeSharp.Extensions;

public static class TextProfileExtensions
{
    /// <summary>
    /// Retries copying the text profile until it is successful or the specified number of retries has been reached.
    /// </summary>
    /// <param name="textProfile">The text profile to copy.</param>
    /// <param name="retryCount">The number of times to retry copying the text profile. Set to -1 to retry indefinitely.</param>
    /// <param name="retryDelay">The delay (in milliseconds) between retries.</param>
    public static void CopyRetry(this TextProfile textProfile, int retryCount = -1, int retryDelay = 100)
    {
        const uint CLIPBRD_E_CANT_OPEN = 0x800401D0;
        while (retryCount != 0)
        {
            try
            {
                textProfile.Copy();
                break;
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != CLIPBRD_E_CANT_OPEN)
                {
                    throw new Exception(
                        "Error copying text profile. Try opening and closing the text profile dialog in Solid Edge to fix and re-run.",
                        ex);
                }
                if (retryCount > 0)
                {
                    retryCount--;
                }
                Thread.Sleep(retryDelay);
            }
        }
    }
}