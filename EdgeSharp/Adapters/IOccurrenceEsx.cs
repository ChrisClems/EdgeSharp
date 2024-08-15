using SolidEdgeAssembly;

namespace EdgeSharp.Adapters;

public interface IOccurrenceEsx
{
    bool Visible { get; set; }

    bool UseSimplified { get; set; }

    bool DisplayReferencePlanes { get; set; }
    bool DisplayCoordinateSystems { get; set; }
    bool DisplayConstructions { get; set; }
    bool DisplayConstrCurves { get; set; }

    bool DisplayReferenceAxes { get; set; }

    bool DisplaySketches { get; set; }
    bool DisplayAsLastSaved { get; set; }
    bool Adjustable { get; set; }
    int ItemNumber { get; set; }
    bool ReferencePlanesVisible { get; set; }
    bool CoordinateSystemsVisible { get; set; }
    bool SketchesVisible { get; set; }
    bool DisplayCenterline { get; set; }
    bool DisplayLiveSections { get; set; }
    bool DisplayDimensions { get; set; }
    bool DisplayAnnotations { get; set; }
    bool DisplayDesignBody { get; set; }
    string Name { get; }

    bool Subassembly { get; }

    SubOccurrences SubOccurrences { get; }
    string GetCustomPropertyValue(string key);

    void SetCustomPropertyValue(string key, string value);
    void GetMatrix(ref Array Matrix);
    void CreateTopologyReference(ref Array ReferenceKey, out TopologyReference TopologyReference);
    AdjustablePart MakeAdjustablePart();
    AdjustablePart GetAdjustablePart();
    void GetExplodeMatrix(ref Array Matrix);
    void RemoveOverrideBody();
    void GetRangeBox(ref Array MinRangePoint, ref Array MaxRangePoint);
    public void GetInterpartDrivingOccurrences(out int NumDrivingOccurrences, ref Array DrivingOccurrences);
    public void GetInterpartDrivenOccurrences(out int NumDrivenOccurrences, ref Array DrivenOccurrences);
    void CreateTopologyReferenceToBodyOverride(ref Array ReferenceKey, out TopologyReference TopologyReference);

    void Range(out double x_min, out double y_min, out double z_min, out double x_max, out double y_max,
        out double z_max);

    bool FileMissing();

    bool RecheckMissingFile();

    void PutStyleUsePartStyle();
    void PutStyleNone();
    bool GetStyleNone();
    bool GetStyleUsePartStyle();
    object BindKeyToTopology(bool BodyOverride, ref Array ReferenceKey);

    void GetSectionedFacetData(int PartID, out OccurrenceSectionedFacetDataConstants FacetDataPresence,
        out int FacetCount,
        ref Array Points, ref Array Normals, ref Array TextureCoords, ref Array StyleIDs, ref Array FaceIDs);
}