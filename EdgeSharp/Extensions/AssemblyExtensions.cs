using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

namespace EdgeSharp.Extensions;

public static class AssemblyExtensions
{
    public static void TraverseOccurencesWithAction(this AssemblyDocument asm, Action<AssemblyDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = occurrence as AssemblyDocument;
            if (document == null)
            {
                continue;
            }

            action(document);
        }
        
    }
    
    public static void TraverseOccurencesWithAction(this AssemblyDocument asm, Action<PartDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence;

            switch (document.Type)
            {
                case DocumentTypeConstants.igAssemblyDocument:
                    // recurive
                case DocumentTypeConstants.igPartDocument:
                    // action
                default:
                    continue;
            }
        }
        
    }
    
    public static void TraverseOccurencesWithAction(this AssemblyDocument asm, Action<SheetMetalDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = occurrence as SheetMetalDocument;
            if (document == null)
            {
                continue;
            }

            action(document);
        }
        
    }
    
    
}