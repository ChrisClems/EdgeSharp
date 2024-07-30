using System.Diagnostics.CodeAnalysis;
using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

namespace EdgeSharp.Extensions;

[SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
public static class AssemblyExtensions
{
    /// <summary>
    /// Traverses an assembly document and performs an action on Solid Edge documents using a delegate.
    /// </summary>
    /// <param name="asm">The assembly document to traverse.</param>
    /// <param name="action">The action to perform on Solid Edge documents.</param>
    /// <param name="recursive">Optional. Indicates whether the traversal should be performed recursively in child assembly documents. Default is true.</param>
    public static void TraverseAssemblyWithAction(this AssemblyDocument asm, Action<SolidEdgeDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var isAsm = false;
            var document = (SolidEdgeDocument)occurrence.OccurrenceDocument;

            if (document.Type == DocumentTypeConstants.igAssemblyDocument)
            {
                isAsm = true;
            }

            action(document);

            if (!recursive || !isAsm) continue;
            var asmDoc = (AssemblyDocument)document;
            asmDoc.TraverseAssemblyWithAction(action, recursive);
        }
    }

    /// <summary>
    /// Traverses an assembly document and performs an action on Solid Edge documents using a delegate.
    /// </summary>
    /// <param name="asm">The assembly document to traverse.</param>
    /// <param name="actions">The actions to perform on Solid Edge documents.</param>
    /// <param name="recursive">Optional. Indicates whether the traversal should be performed recursively in child assembly documents. Default is true.</param>
    public static void TraverseAssemblyWithAction(this AssemblyDocument asm, Action<SolidEdgeDocument>[] actions, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence.OccurrenceDocument;

            foreach (var action in actions)
            {
                action(document);
            }

            if (recursive && document.Type == DocumentTypeConstants.igAssemblyDocument)
            {
                var asmDoc = (AssemblyDocument)document;
                asmDoc.TraverseAssemblyWithAction(actions, recursive);
            }
        }
    }

    /// <summary>
    /// Traverses the occurrences of an assembly document and performs an action on each occurrence using a delegate.
    /// </summary>
    /// <param name="asm">The assembly document to traverse.</param>
    /// <param name="action">The action to perform on each occurrence.</param>
    /// <param name="recursive">Optional. Indicates whether the traversal should be performed recursively in child assembly documents. Default is true.</param>
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<Occurrence> action,
        bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            action(occurrence);
            if (!occurrence.Subassembly) continue;
            if (!recursive) continue;
            var subOccurrences = occurrence.SubOccurrences;
            foreach (SubOccurrence subOccurrence in subOccurrences)
            {
                action(subOccurrence.ThisAsOccurrence);
                if (!subOccurrence.Subassembly) continue;
                TraverseSubOccurrences(subOccurrence, action);
            }
        }
    }
    
    /// <summary>
    /// Traverses the occurrences of an assembly document and performs an action on each occurrence using a delegate.
    /// </summary>
    /// <param name="asm">The assembly document to traverse.</param>
    /// <param name="actions">The actions to perform on each occurrence.</param>
    /// <param name="recursive">Optional. Indicates whether the traversal should be performed recursively in child assembly documents. Default is true.</param>
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<Occurrence>[] actions,
        bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            foreach (var action in actions)
            {
                action(occurrence);
            }
            if (!occurrence.Subassembly) continue;
            if (!recursive) continue;
            var subOccurrences = occurrence.SubOccurrences;
            foreach (SubOccurrence subOccurrence in subOccurrences)
            {
                foreach (var action in actions)
                {
                    action(subOccurrence.ThisAsOccurrence);
                }
                if (!subOccurrence.Subassembly) continue;
                TraverseSubOccurrences(subOccurrence, actions);
            }
        }
    }

    /// <summary>
    /// Recursively traverses SubOccurrences of a SubOccurrence SubAssembly and performs the delegate action
    /// </summary>
    /// <param name="subOccurrence">The sub-occurrence to start traversal from.</param>
    /// <param name="action">The action to perform on Solid Edge occurrences.</param>
    private static void TraverseSubOccurrences(SubOccurrence subOccurrence, Action<Occurrence> action)
    {
        var subOccurrences = subOccurrence.SubOccurrences;
        foreach (SubOccurrence subSubOccurrence in subOccurrences)
        {
            action(subSubOccurrence.ThisAsOccurrence);
            if (!subSubOccurrence.Subassembly) continue;
            TraverseSubOccurrences(subSubOccurrence, action);
        }
    }
    
    /// <summary>
    /// Recursively traverses SubOccurrences of a SubOccurrence SubAssembly and performs the delegate action
    /// </summary>
    /// <param name="subOccurrence">The sub-occurrence to start traversal from.</param>
    /// <param name="actions">The actions to perform on Solid Edge occurrences.</param>
    private static void TraverseSubOccurrences(SubOccurrence subOccurrence, Action<Occurrence>[] actions)
    {
        var subOccurrences = subOccurrence.SubOccurrences;
        foreach (SubOccurrence subSubOccurrence in subOccurrences)
        {
            foreach (var action in actions)
            {
                action(subSubOccurrence.ThisAsOccurrence);
            }
            if (!subSubOccurrence.Subassembly) continue;
            TraverseSubOccurrences(subSubOccurrence, actions);
        }
    }

    /// <summary>
    /// Removes parts from an assembly document based on a given property key-value pair.
    /// </summary>
    /// <param name="asm">The assembly document.</param>
    /// <param name="kvp">The key-value pair representing the property to match.</param>
    /// <param name="caseSensitive">Optional. Indicates whether the property comparison should be case-sensitive. Default is true.</param>
    /// <param name="recursive">Optional. Indicates whether the removal should be performed recursively in child assembly documents. Default is true.</param>
    public static void RemovePartsByProperty(this AssemblyDocument asm, KeyValuePair<string, string> kvp, bool caseSensitive = true, bool recursive = true)
    {
        var valueMatch = false;
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence.OccurrenceDocument;

            var propSets = document.PropertySetsToDictionary();

            foreach (var propSet in propSets)
            {
                foreach (var prop in propSet.Value)
                {
                    var keyMatch = caseSensitive ? kvp.Key.Equals(prop.Key) : kvp.Key.Equals(prop.Key, StringComparison.OrdinalIgnoreCase);
                    if (keyMatch)
                    {
                        valueMatch = caseSensitive
                            ? kvp.Value.Equals(prop.Value) :
                            kvp.Value.Equals(prop.Value, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }

            if (valueMatch)
            {
                occurrence.Delete();
            }

            if (recursive && document.Type == DocumentTypeConstants.igAssemblyDocument)
            {
                var asmDoc = (AssemblyDocument)document;
                asmDoc.RemovePartsByProperty(kvp, caseSensitive, recursive);
            }
        }
    }
}