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
    public static SolidEdgeDocument GetDocumentEsx(this IOccurrenceEsx occurrence)
    {
        return (SolidEdgeDocument)occurrence.OccurrenceDocument;
    }

    /// <summary>
    /// Retrieves all parent assemblies of the provided occurrence up to the top level
    /// </summary>
    /// <param name="occurrence">The occurrence to retrieve the parent tree from.</param>
    /// <returns>A list of AssemblyDocument representing the parent tree, or null if the occurrence is a subassembly.</returns>
    public static List<AssemblyDocument> GetParentTree(this IOccurrenceEsx occurrence)
    {
        var topLevelDocument = occurrence.TopLevelDocument;
        IOccurrenceEsx? parentOccurrence = null;

        try
        {
            parentOccurrence = OccurrenceFactory.Create(occurrence.Parent);
        }
        catch (InvalidCastException) { }
        
        if (parentOccurrence?.OccurrenceDocument is not AssemblyDocument assemblyDocument) throw new Exception("Parent of provided occurrence is not an AssemblyDocument.");

        var parentTree = new List<AssemblyDocument> { assemblyDocument };
        AddParentDocumentsToTree(parentOccurrence, parentTree);

        parentTree.Add(topLevelDocument);
        parentTree.Reverse();

        return parentTree;
    }

    private static void AddParentDocumentsToTree(IOccurrenceEsx parentOccurrence, List<AssemblyDocument> parentTree)
    {
        while (true)
        {
            try
            {
                parentOccurrence = OccurrenceFactory.Create(parentOccurrence.Parent);
            }
            catch (InvalidCastException)
            {
                break;
            }
            if (parentOccurrence?.OccurrenceDocument is not AssemblyDocument assemblyDocument) throw new Exception("Parent of provided occurrence is not an AssemblyDocument.");
            parentTree.Add(assemblyDocument);
        }
    }
}