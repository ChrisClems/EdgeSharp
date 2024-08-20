using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class DocumentExtensions
{
    /// <summary>
    ///     Converts the properties of a SolidEdgeDocument to a nested dictionary.
    /// </summary>
    /// <param name="doc">The SolidEdgeDocument whose properties will be converted.</param>
    /// <param name="extendedProps">An optional dictionary of extended properties to be included in the result.</param>
    /// <returns>
    ///     A nested dictionary of the properties. The outer dictionary contains the property set names as keys, and the
    ///     inner dictionaries contain the property names and values.
    /// </returns>
    public static Dictionary<string, Dictionary<string, string?>> PropertySetsToDictionary(this SolidEdgeDocument doc,
        Dictionary<string, string>? extendedProps = null)
    {
        // Parent dictionary to hold all properties
        var propertySetDict =
            new Dictionary<string, Dictionary<string, string?>>();
        var propertySets = (PropertySets)doc.Properties;

        foreach (Properties properties in propertySets)
        {
            var propertyDict = new Dictionary<string, string?>();
            foreach (Property property in properties)
                try
                {
                    propertyDict.Add(property.Name, property.get_Value().ToString());
                }
                catch (Exception e) when (e is NullReferenceException | e is ArgumentNullException)
                {
                    // Ignore broken custom props with null keys.
                }

            try
            {
                propertySetDict.Add(properties.Name, propertyDict);
            }
            // Don't know how this happened. Should not be possible.
            // If it happens, report as issue: https://github.com/ChrisClems/EdgeSharp/issues
            catch (Exception ex) when (ex is NullReferenceException | ex is ArgumentNullException)
            {
                throw new Exception(
                    $"PropertySet Dict Key null exception on {doc.Name}. Please report as issue with SE document file attached: https://github.com/ChrisClems/EdgeSharp/issues ",
                    ex);
            }
        }

        // Optionally add an extra set of custom properties as an ExtendedProperties dictionary
        if (extendedProps == null) return propertySetDict;
        propertySetDict.Add("ExtendedProperties", extendedProps!);
        return propertySetDict;
    }
}