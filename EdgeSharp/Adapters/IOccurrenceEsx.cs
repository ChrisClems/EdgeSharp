using SolidEdgeAssembly;
using SolidEdgeFramework;
// ReSharper disable InconsistentNaming

namespace EdgeSharp.Adapters;

// TODO: This factory should probably go somewhere else. It was dropped here for rapid prototyping
/// <summary>
/// A factory class responsible for creating instances of IOccurrenceEsx from COM objects.
/// </summary>
public static class OccurrenceFactory
{
    /// <summary>
    /// Creates an instance of IOccurrenceEsx from a given COM object of type Occurrence or SubOccurrence.
    /// </summary>
    /// <param name="comObject">The COM object to be adapted into an IOccurrenceEsx instance.</param>
    /// <returns>An instance of IOccurrenceEsx if the adaptation is successful; otherwise, null.</returns>
    public static IOccurrenceEsx? Create(object comObject)
    {
        if (comObject is SubOccurrence subOccurrence)
        {
            return new SubOccurrenceAdapter(subOccurrence);
        }
        if (comObject is Occurrence occurrence)
        {
            return new OccurrenceAdapter(occurrence);
        }
        throw new InvalidCastException("Object cannot be cast to Occurrence or SubOccurrence.");
    }
}

/// <summary>
/// Defines shared methods between Occurrence and SubOccurrences so they may be iterated over easily.
/// </summary>
public interface IOccurrenceEsx
{
    public object Application { get; }

    public object Parent { get; }
    
    public object OccurrenceDocument { get; }
    
    public Occurrence ThisAsOccurrence { get; }
    
    public int OccurrenceId { get; }
    
    public SolidEdgeDocument SEDocEsx { get; }

    public string OccurrenceFileName { get; }

    public AssemblyDocument TopLevelDocument { get; }

    public ObjectType Type { get; }
    
    public DocumentTypeConstants DocumentTypeEsx { get; }

    string OccurrenceType { get; }

    public bool Visible { get; set; }

    public bool UseSimplified { get; set; }

    public bool DisplayReferencePlanes { get; set; }

    public bool DisplayCoordinateSystems { get; set; }

    public bool DisplayConstructions { get; set; }

    public bool DisplayConstrCurves { get; set; }

    public bool DisplayReferenceAxes { get; set; }

    public bool DisplaySketches { get; set; }

    public bool DisplayAsLastSaved { get; set; }

    public bool Adjustable { get; set; }

    public bool HasBodyOverride { get; }

    public object Body { get; }

    public bool IsPatterned { get; }

    public bool IsPatternItem { get; }

    public bool IsAdjustablePart { get; }

    public SubassemblyBodies SubassemblyBodies { get; }

    public int ItemNumber { get; set; }

    public bool ReferencePlanesVisible { get; set; }

    public bool CoordinateSystemsVisible { get; set; }

    public bool SketchesVisible { get; set; }

    public bool DisplayCenterline { get; set; }

    public ObjectType NodeType { get; }

    public bool DisplayLiveSections { get; set; }

    public bool DisplayDimensions { get; set; }

    public bool DisplayAnnotations { get; set; }

    public bool DisplayDesignBody { get; set; }

    public bool Locatable { get; set; }

    public object FaceStyle { get; set; }

    public string Style { get; set; }

    public bool IsInternalComponent { get; }

    public InternalComponent InternalComponent { get; }

    public SubOccurrences SubOccurrences { get; }

    public bool Subassembly { get; }

    public string Name { get; }

    public void SetCustomPropertyValue(string customPropertyName, string value);

    public string GetCustomPropertyValue(string customPropertyName);

    public void GetReferenceKey(ref Array ReferenceKey, out object KeySize);

    public void GetMatrix(ref Array Matrix);

    public void CreateTopologyReference(ref Array ReferenceKey, out TopologyReference TopologyReference);

    public void PutMatrix(ref Array Matrix, bool Replace);

    public void GetSimplifiedBodies(out int NumBodies, ref Array SimplifiedBodies);

    public void GetBodyInversionMatrix(ref Array InvMatrix);

    public AdjustablePart MakeAdjustablePart();

    public AdjustablePart GetAdjustablePart();

    public void GetExplodeMatrix(ref Array Matrix);

    public void RemoveOverrideBody();

    public void GetRangeBox(ref Array MinRangePoint, ref Array MaxRangePoint);

    public void GetInterpartDrivingOccurrences(out int NumDrivingOccurrences, ref Array DrivingOccurrences);

    public void GetInterpartDrivenOccurrences(out int NumDrivenOccurrences, ref Array DrivenOccurrences);

    public void CreateTopologyReferenceToBodyOverride(ref Array ReferenceKey, out TopologyReference TopologyReference);

    public void Range(out double x_min, out double y_min, out double z_min, out double x_max, out double y_max,
        out double z_max);

    public bool FileMissing();

    public bool RecheckMissingFile();

    public object GetFaceStyle2(bool vbHonourPrefs);

    public void PutStyleUsePartStyle();

    public void PutStyleNone();

    public bool GetStyleNone();

    public bool GetStyleUsePartStyle();

    public object BindKeyToTopology(bool BodyOverride, ref Array ReferenceKey);

    public void GetSectionedFacetData(int PartID, out OccurrenceSectionedFacetDataConstants FacetDataPresence,
        out int FacetCount,
        ref Array Points, ref Array Normals, ref Array TextureCoords, ref Array StyleIDs, ref Array FaceIDs);
}