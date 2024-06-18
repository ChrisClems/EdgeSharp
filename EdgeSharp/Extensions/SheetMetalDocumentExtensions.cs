using OpenMcdf;
using SolidEdgePart;

namespace EdgeSharp.Extensions;

public static class SheetMetalDocumentExtensions
{
    /// <summary>
    /// Forces the specified Sheet Metal Document to be saved as a Part Document.
    /// WARNING: EXPERIMENTAL! MODIFIES THE CLSID OF THE COM STRUCTURED STORAGE FILE.
    /// </summary>
    /// <param name="doc">The Sheet Metal Document to be saved.</param>
    /// <param name="newName">The new path and filename for the Part Document.</param>
    public static void ForceSaveAsPart(this SheetMetalDocument doc, string newName)
    {
        // TODO: Error handling.
        var partClsid = new System.Guid("23c52e80-4698-11ce-b307-0800363a1e02");
        var originalDocPath = Path.GetFullPath(doc.FullName);
        var compoundFile = new CompoundFile(originalDocPath);
        var rootStorage = compoundFile.RootStorage;
        rootStorage.CLSID = partClsid;
        compoundFile.SaveAs(newName);
    }
}