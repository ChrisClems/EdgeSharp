using EdgeSharp.Adapters;
using SolidEdgeAssembly;
using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class OccurrenceExtensions
{
    public static SolidEdgeDocument GetSeDocument(this Occurrence occurrence)
    {
        return (SolidEdgeDocument)occurrence.OccurrenceDocument;
    }
}