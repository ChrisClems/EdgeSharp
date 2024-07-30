namespace EdgeSharp.Extensions;

public static class ConversionExtensions
{
    public static double InchesToMeters(this double inches)
    {
        const double conversionFactor = 0.0254;
        return inches * conversionFactor;
    }
    
    public static double MetersToInches(this double meters)
    {
        const double conversionFactor = 39.37;
        return meters * conversionFactor;
    }

    public static double DegreesToRadians(this double degrees)
    {
        return degrees * (Math.PI / 180);
    }

    public static double RadiansToDegrees(this double radians)
    {
        return radians * (180 / Math.PI);
    }
    
}