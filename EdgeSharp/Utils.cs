using System.Collections;

namespace EdgeSharp;

public class Utils
{
    internal static int GenerateBitMask(bool[] bools)
    {
        BitArray bits = new BitArray(bools);
        if (bits.Length > 32) throw new ArgumentException("The BitArray is too large to fit in an integer.");

        int[] array = new int[1];
        bits.CopyTo(array, 0);
        return array[0];
    }

    internal static BitArray BitsFromMask(int mask, int length)
    {
        BitArray bits = new BitArray(new int[] { mask });
        BitArray trimmedBits = new BitArray(length);
        for (int i = 0; i < length; i++)
        {
            trimmedBits[i] = bits[i];
        }
        return trimmedBits;
    }
}