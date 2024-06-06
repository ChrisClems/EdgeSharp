using SolidEdgeFramework;

namespace EdgeSharp.Extensions;

public static class DocumentsExtensions
{
    public static object OpenInBackground(this Documents documents, string Filename, object AltPath = null,
        object RecognizeFeaturesIfPartTemplate = null, object RevisionRuleOption = null,
        object StopFileOpenIfRevisionRuleNotApplicable = null)
    {
        RevisionRuleOption ??= 0;

        StopFileOpenIfRevisionRuleNotApplicable ??= false;
        
        var document = documents.Open(Filename, 0x00000008, AltPath, RecognizeFeaturesIfPartTemplate,
            RevisionRuleOption, StopFileOpenIfRevisionRuleNotApplicable);
        return document;
    }
}