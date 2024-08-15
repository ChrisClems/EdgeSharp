using SolidEdgeAssembly;
using SolidEdgePart;

namespace EdgeSharp;

public class Coordinate
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    
}

/// <summary>
/// Represents a structural frame section.
/// A custom type to organize structural frame section/segment properties.
/// </summary>
public class StructuralFrameSection
{
    public int SectionId { get; private set; }
    public StructuralFrame Parent;
    public Occurrence SectionOccurrence;
    public int OccurrenceId = 0;
    public double EndAngle1 = 0;
    public double EndAngle2 = 0;
    public double SideAngle1 = 0;
    public double SideAngle2 = 0;
    public double Length = 0;
    //public static double ExactLength = 0;
    public Coordinate Offset;
    public Coordinate Rotation;

    internal StructuralFrameSection(StructuralFrame frame, int sectionId)
    {
        Parent = frame;
        SectionId = sectionId;
        Offset = new Coordinate();
        Rotation = new Coordinate();
        object objOccurenceId = 0;
        var objOccurrence = new object();
        object xOffsetObj = 0.0;
        object yOffsetObj = 0.0;
        object zOffsetObj = 0.0;
        object xRotationObj = 0.0;
        object yRotationObj = 0.0;
        object zRotationObj = 0.0;
        frame.ReturnOccurrenceForGivenSectionID(SectionId, out objOccurenceId, out objOccurrence);
        SectionOccurrence = (Occurrence)objOccurrence;
        OccurrenceId = (int)objOccurenceId;
        frame.GetPlaneOrientationForGivenSectionID(SectionId, out xOffsetObj, out yOffsetObj, out zOffsetObj, out xRotationObj, out yRotationObj, out zRotationObj);
        Offset.X = (double)xOffsetObj;
        Offset.Y = (double)yOffsetObj;
        Offset.Z = (double)zOffsetObj;
        Rotation.X = (double)xRotationObj;
        Rotation.Y = (double)yRotationObj;
        Rotation.Z = (double)zRotationObj;
        
        frame.SegmentCutLength(SectionId, out Length, out _);
        frame.EndFaceEndAngle(SectionId, out EndAngle1, out EndAngle2);
        frame.SideFaceEndAngle(SectionId, out SideAngle1, out SideAngle2);
    }

    public PartDocument GetPartDocument()
    {
        return (PartDocument)SectionOccurrence.PartDocument;
    }
}