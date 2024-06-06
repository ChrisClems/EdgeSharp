using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

namespace EdgeSharp.Extensions;

public static class AssemblyExtensions
{
    # region TraverseOccurencesWithAction
    // Process all Solid Edge documents in assembly using delegate action
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<SolidEdgeDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence;

            switch (document.Type)
            {
                case DocumentTypeConstants.igAssemblyDocument:
                    // If recursion enabled, reprocess assembly
                    if (!recursive) continue;
                    var asmDoc = (AssemblyDocument)document;
                    asmDoc.TraverseOccurrencesWithAction(action, recursive);
                    break;
                default:
                    // Process document with action delegate
                    action(document);
                    break;
            }
        }
    }
    
    // Process all part documents in assembly using delegate action
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<PartDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence;

            switch (document.Type)
            {
                case DocumentTypeConstants.igAssemblyDocument:
                    // If recursion enabled, reprocess assembly
                    if (!recursive) continue;
                    var asmDoc = (AssemblyDocument)document;
                    asmDoc.TraverseOccurrencesWithAction(action, recursive);
                    break;
                case DocumentTypeConstants.igPartDocument:
                    // Process part document with action delegate
                    var partDoc = (PartDocument)document;
                    action(partDoc);
                    break;
            }
        }
    }
    
    // Process all sheet metal documents in assembly using delegate action
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<SheetMetalDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence;

            switch (document.Type)
            {
                case DocumentTypeConstants.igAssemblyDocument:
                    // If recursion enabled, reprocess assembly
                    if (!recursive) continue;
                    var asmDoc = (AssemblyDocument)document;
                    asmDoc.TraverseOccurrencesWithAction(action, recursive);
                    break;
                case DocumentTypeConstants.igPartDocument:
                    // Process sheet metal document with action delegate
                    var sheetMetalDoc = (SheetMetalDocument)document;
                    action(sheetMetalDoc);
                    break;
            }
        }
    }
    // TODO: Implement unified PartMetal type traversal once adapter is implemented
    #endregion
}