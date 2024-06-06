﻿using System.Diagnostics.CodeAnalysis;
using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

namespace EdgeSharp.Extensions;

[SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
public static class AssemblyExtensions
{
    // Process all Solid Edge documents in assembly using delegate action
    public static void TraverseOccurrencesWithAction(this AssemblyDocument asm, Action<SolidEdgeDocument> action, bool recursive)
    {
        var occurrences = asm.Occurrences;
        foreach (Occurrence occurrence in occurrences)
        {
            var document = (SolidEdgeDocument)occurrence;

            action(document);

            if (recursive && document.Type == DocumentTypeConstants.igAssemblyDocument)
            {
                var asmDoc = (AssemblyDocument)document;
                asmDoc.TraverseOccurrencesWithAction(action, recursive);
            }
        }
    }
}