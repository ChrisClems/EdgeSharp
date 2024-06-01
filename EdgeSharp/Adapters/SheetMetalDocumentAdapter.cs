using SolidEdgePart;

namespace EdgeSharp.Adapters;

public class SheetMetalDocumentAdapter : IDocument
{
    private SheetMetalDocument _sheetMetalDocument;

    public SheetMetalDocumentAdapter(SheetMetalDocument sheetMetalDocument)
    {
        _sheetMetalDocument = sheetMetalDocument;
    }
    
}