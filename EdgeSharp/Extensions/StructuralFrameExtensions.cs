using SolidEdgeAssembly;

namespace EdgeSharp.Extensions;

public static class StructuralFrameExtensions
{
    public static int[] GetSectionIds(this StructuralFrame frame)
    {
        var sectionCount = 0;
        Array sections = new int[1];
        frame.GetSections(out sectionCount, ref sections);
        return (int[])sections;
    }

    /// <summary>
    /// Gets the structural frame sections for a given StructuralFrame.
    /// </summary>
    /// <param name="frame">The StructuralFrame to retrieve sections for.</param>
    /// <returns>A list of StructuralFrameSection objects representing the sections of the given StructuralFrame.</returns>
    public static List<StructuralFrameSection> GetStructuralFrameSections(this StructuralFrame frame)
    {
        var sectionList = new List<StructuralFrameSection>();
        var sectionIds = GetSectionIds(frame);
        foreach (var sectionId in sectionIds)
        {
            var section = new StructuralFrameSection(frame, sectionId);
            sectionList.Add(section);
        }

        return sectionList;
    }
}