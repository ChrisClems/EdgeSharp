using EdgeSharp.Adapters;
using SolidEdgeAssembly;
using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class IOccurrenceEsxExtensions
{
    /// <summary>
    /// Retrieves the associated SolidEdgeDocument of the occurrence.
    /// </summary>
    /// <param name="occurrence">The occurrence to retrieve the document from.</param>
    /// <returns>The associated SolidEdgeDocument.</returns>
    public static SolidEdgeDocument GetDocmentEsx(this IOccurrenceEsx occurrence)
    {
        return (SolidEdgeDocument)occurrence.OccurrenceDocument;
    }
}