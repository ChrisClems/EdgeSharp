using EdgeSharp.Adapters;
using SolidEdgeAssembly;
using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class SubOccurrenceExtensions
{
    public static SolidEdgeDocument GetSeDocument(this SubOccurrence subOccurrence)
    {
        return (SolidEdgeDocument)subOccurrence.SubOccurrenceDocument;
    }
}