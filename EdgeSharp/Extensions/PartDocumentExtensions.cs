﻿using SolidEdgePart;
using OpenMcdf;

namespace EdgeSharp.Extensions;

public static class PartDocumentExtensions
{
    /// <summary>
    /// Forces the specified Part Document to be saved as a Sheet Metal Document.
    /// WARNING: EXPERIMENTAL! MODIFIES THE CLSID OF THE COM STRUCTURED STORAGE FILE.
    /// </summary>
    /// <param name="doc">The Part Document to be saved.</param>
    /// <param name="newName">The new path and filename for the Sheet Metal Document.</param>
    public static void ForceSaveAsSheetMetal(this PartDocument doc, string newName)
    {
        // TODO: Error handling.
        var sheetMetalClsid = new System.Guid("dd8522e0-2375-11d0-ac05-080036fd1802");
        var originalDocPath = Path.GetFullPath(doc.FullName);
        var compoundFile = new CompoundFile(originalDocPath);
        var rootStorage = compoundFile.RootStorage;
        rootStorage.CLSID = sheetMetalClsid;
        compoundFile.SaveAs(newName);
    }
}