

using SolidEdgeAssembly;

namespace EdgeSharp.Adapters;

public interface IOccurrenceEsx
{
    string Name { get; }
    string GetCustomPropertyValue(string key);
    void SetCustomPropertyValue(string key, string value);
    bool Subassembly { get; }

    SubOccurrences SubOccurrences { get; }
}