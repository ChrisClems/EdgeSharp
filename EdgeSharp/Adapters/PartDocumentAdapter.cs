using SolidEdgePart;

namespace EdgeSharp.Adapters;

public class PartDocumentAdapter : IDocument
{
    private PartDocument _partDocument;

    public PartDocumentAdapter(PartDocument partDocument)
    {
        _partDocument = partDocument;
    }
}