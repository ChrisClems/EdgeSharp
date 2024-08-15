using SolidEdgePart;

namespace EdgeSharp.Adapters;

public interface IPartMetalDocument
{
    public void Activate();
    FlatPatternModels FlatPatternModels { get; }
}