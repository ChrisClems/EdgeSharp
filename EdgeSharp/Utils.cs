using System.Collections;
using SolidEdgeFramework;
using DocumentTypeConstants = SolidEdgeConstants.DocumentTypeConstants;

namespace EdgeSharp;

public class Utils
{
    /// <summary>
    /// Retrieves the first parent part or sheet metal document from the arbitrary object as a SolidEdgeDocument
    /// </summary>
    /// <param name="seObject">The Solid Edge object.</param>
    /// <returns>The first part or sheet metal document in the parent tree of the given object.</returns>
    public static SolidEdgeDocument GetFirstParentDocFromObject(object seObject)
    {
        dynamic comObject = seObject;
        var parent = comObject.Parent;
        var parentType = (DocumentTypeConstants)parent.Type;
        if (parentType is DocumentTypeConstants.igSheetMetalDocument
            or DocumentTypeConstants.igPartDocument)
        {
            return (SolidEdgeDocument)parent;
        }

        return GetFirstParentDocFromObject(parent);
    }
}