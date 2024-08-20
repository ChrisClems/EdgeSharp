using SolidEdgeFramework;

// ReSharper disable InconsistentNaming

namespace EdgeSharp.Extensions;

public static class DocumentsExtensions
{
    /// <summary>
    ///     Opens a Solid Edge document in the background without creating a window.
    /// </summary>
    /// <param name="documents">The Documents object.</param>
    /// <param name="Filename">The name of the file to open.</param>
    /// <param name="AltPath">The alternative file path (optional).</param>
    /// <param name="RecognizeFeaturesIfPartTemplate">Whether to recognize features if the file is a part template (optional).</param>
    /// <param name="RevisionRuleOption">The revision rule option (optional).</param>
    /// <param name="StopFileOpenIfRevisionRuleNotApplicable">
    ///     Whether to stop file open if the revision rule is not applicable
    ///     (optional).
    /// </param>
    /// <returns>
    ///     The opened document object.
    /// </returns>
    public static object OpenInBackground(this Documents documents, string Filename, object? AltPath = null,
        object? RecognizeFeaturesIfPartTemplate = null, object? RevisionRuleOption = null,
        object? StopFileOpenIfRevisionRuleNotApplicable = null)
    {
        RevisionRuleOption ??= 0;

        StopFileOpenIfRevisionRuleNotApplicable ??= false;

        var document = documents.Open(Filename, 0x00000008, AltPath, RecognizeFeaturesIfPartTemplate,
            RevisionRuleOption, StopFileOpenIfRevisionRuleNotApplicable);
        return document;
    }
}