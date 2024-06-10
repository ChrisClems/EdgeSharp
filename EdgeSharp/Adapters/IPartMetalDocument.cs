using SolidEdgePart;

namespace EdgeSharp.Adapters;

public interface IPartMetalDocument
{
    public abstract void Activate();
    FlatPatternModels FlatPatternModels { get; }
}