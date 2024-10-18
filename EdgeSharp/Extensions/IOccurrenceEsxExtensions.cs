using System.Runtime.InteropServices;
using EdgeSharp.Adapters;
using SolidEdgeAssembly;
using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class IOccurrenceEsxExtensions
{
    /// <summary>
    /// Retrieves the AssemblyDocument in which the currently shown FaceStyle is set when viewing from a higher level in the assembly tree.
    /// </summary>
    /// <param name="occurrence">The occurrence for which to find the containing AssemblyDocument with a FaceStyle property.</param>
    /// <returns>The AssemblyDocument that contains the FaceStyle property for the specified occurrence, or null if none is found.</returns>
    public static AssemblyDocument? GetFaceStyleAssemblyContext(this IOccurrenceEsx occurrence)
    {
        var occurrenceId = occurrence.OccurrenceId;
        var parentTree = occurrence.GetParentTree();

        foreach (var assembly in parentTree)
        {
            var faceOccurrence = assembly.FindOccurrencesById(occurrenceId);
            try
            {
                // Non-existant FaceStyle properties do not return null. They throw E_FAIL
                // Must catch exception to traverse assemblies searching for FaceStyles.
                if (faceOccurrence.FaceStyle is FaceStyle faceStyle)
                {
                    return assembly;
                }
            }
            catch (COMException){}
        }

        return null;
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