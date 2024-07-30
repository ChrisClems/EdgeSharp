using System.Diagnostics;
using System.Runtime.InteropServices;
using SolidEdgePart;
using System.Threading;
using Thread = System.Threading.Thread;

namespace EdgeSharp.Extensions;

public static class ProfileExtensions
{
    public static void PasteRetry(this Profile profile, int retryCount = -1, int retryDelay = 100)
    {
        const uint CLIPBRD_E_CANT_OPEN = 0x800401D0;
        while (retryCount != 0)
        {
            try
            {
                profile.Paste();
                break;
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != CLIPBRD_E_CANT_OPEN)
                {
                    throw new Exception(
                        "Error pasting text profile. Try opening and closing the text profile dialog in Solid Edge to fix and re-run.",
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