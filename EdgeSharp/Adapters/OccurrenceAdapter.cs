using EdgeSharp.Extensions;
using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

// ReSharper disable InconsistentNaming

namespace EdgeSharp.Adapters;

public class OccurrenceAdapter : IOccurrenceEsx
{
    private readonly Occurrence _occurrence;

    public OccurrenceAdapter(Occurrence occurrence)
    {
        _occurrence = occurrence;
    }

    public object OccurrenceDocument => _occurrence.OccurrenceDocument;

    public Occurrence ThisAsOccurrence => _occurrence;

    public int OccurrenceId => _occurrence.OccurrenceID;
    
    public SolidEdgeDocument SEDocEsx => (SolidEdgeDocument)_occurrence.OccurrenceDocument;
    
    public string OccurrenceFileName => _occurrence.OccurrenceFileName;

    public object Application => _occurrence.Application;

    public object Parent => _occurrence.Parent;

    public ObjectType Type => _occurrence.Type;

    public DocumentTypeConstants DocumentTypeEsx => _occurrence.GetSeDocument().Type;

    public string OccurrenceType => EsxDocumentTypeConstants.OccurrenceDocument;

    public bool Visible
    {
        get => _occurrence.Visible;
        set => _occurrence.Visible = value;
    }

    public bool Locatable
    {
        get => _occurrence.Locatable;
        set => _occurrence.Locatable = value;
    }

    public string Style
    {
        get => _occurrence.Style;
        set => _occurrence.Style = value;
    }

    public object FaceStyle
    {
        get => _occurrence.FaceStyle;
        set => _occurrence.FaceStyle = value;
    }

    public AssemblyDocument TopLevelDocument => _occurrence.TopLevelDocument;

    public bool UseSimplified
    {
        get => _occurrence.UseSimplified;
        set => _occurrence.UseSimplified = value;
    }

    public bool DisplayReferencePlanes
    {
        get => _occurrence.DisplayReferencePlanes;
        set => _occurrence.DisplayReferencePlanes = value;
    }

    public bool DisplayCoordinateSystems
    {
        get => _occurrence.DisplayCoordinateSystems;
        set => _occurrence.DisplayCoordinateSystems = value;
    }

    public bool DisplayConstructions
    {
        get => _occurrence.DisplayConstructions;
        set => _occurrence.DisplayConstructions = value;
    }

    public bool DisplayConstrCurves
    {
        get => _occurrence.DisplayConstrCurves;
        set => _occurrence.DisplayConstrCurves = value;
    }

    public bool DisplayReferenceAxes
    {
        get => _occurrence.DisplayReferenceAxes;
        set => _occurrence.DisplayReferenceAxes = value;
    }

    public bool DisplaySketches
    {
        get => _occurrence.DisplaySketches;
        set => _occurrence.DisplaySketches = value;
    }

    public bool DisplayAsLastSaved
    {
        get => _occurrence.DisplayAsLastSaved;
        set => _occurrence.DisplayAsLastSaved = value;
    }

    public bool Adjustable
    {
        get => _occurrence.Adjustable;
        set => _occurrence.Adjustable = value;
    }

    public bool IsAdjustablePart => _occurrence.IsAdjustablePart;

    public bool HasBodyOverride => _occurrence.HasBodyOverride;

    public object Body => _occurrence.Body;

    public bool IsPatterned => _occurrence.IsPatterned;

    public bool IsPatternItem => _occurrence.IsPatternItem;

    public SubassemblyBodies SubassemblyBodies => _occurrence.SubassemblyBodies;

    public int ItemNumber
    {
        get => _occurrence.ItemNumber;
        set => _occurrence.ItemNumber = value;
    }

    public bool ReferencePlanesVisible
    {
        get => _occurrence.ReferencePlanesVisible;
        set => _occurrence.ReferencePlanesVisible = value;
    }

    public bool CoordinateSystemsVisible
    {
        get => _occurrence.CoordinateSystemsVisible;
        set => _occurrence.CoordinateSystemsVisible = value;
    }

    public bool SketchesVisible
    {
        get => _occurrence.SketchesVisible;
        set => _occurrence.SketchesVisible = value;
    }

    public bool DisplayCenterline
    {
        get => _occurrence.DisplayCenterline;
        set => _occurrence.DisplayCenterline = value;
    }

    public ObjectType NodeType => _occurrence.NodeType;

    public bool DisplayLiveSections
    {
        get => _occurrence.DisplayLiveSections;
        set => _occurrence.DisplayLiveSections = value;
    }

    public bool DisplayDimensions
    {
        get => _occurrence.DisplayDimensions;
        set => _occurrence.DisplayDimensions = value;
    }

    public bool DisplayAnnotations
    {
        get => _occurrence.DisplayAnnotations;
        set => _occurrence.DisplayAnnotations = value;
    }

    public bool DisplayDesignBody
    {
        get => _occurrence.DisplayDesignBody;
        set => _occurrence.DisplayDesignBody = value;
    }

    public bool IsInternalComponent => _occurrence.IsInternalComponent;

    public InternalComponent InternalComponent => _occurrence.InternalComponent;

    public string Name
    {
        get => _occurrence.Name;
        set => _occurrence.Name = value;
    }

    public bool Subassembly => _occurrence.Subassembly;

    public SubOccurrences SubOccurrences => _occurrence.SubOccurrences;

    public void SetCustomPropertyValue(string customPropertyName, string value)
    {
        _occurrence.CustomPropertyValue[customPropertyName] = value;
    }

    public string GetCustomPropertyValue(string customPropertyName)
    {
        return _occurrence.CustomPropertyValue[customPropertyName];
    }

    public void PutMatrix(ref Array Matrix, bool Replace)
    {
        _occurrence.PutMatrix(ref Matrix, Replace);
    }

    public void GetMatrix(ref Array Matrix)
    {
        _occurrence.GetMatrix(ref Matrix);
    }

    public void GetReferenceKey(ref Array ReferenceKey, out object KeySize)
    {
        _occurrence.GetReferenceKey(ref ReferenceKey, out KeySize);
    }

    public void CreateTopologyReference(ref Array ReferenceKey, out TopologyReference TopologyReference)
    {
        _occurrence.CreateTopologyReference(ref ReferenceKey, out TopologyReference);
    }

    public object GetFaceStyle2(bool vbHonourPrefs)
    {
        return _occurrence.GetFaceStyle2(vbHonourPrefs);
    }

    public AdjustablePart MakeAdjustablePart()
    {
        return _occurrence.MakeAdjustablePart();
    }

    public AdjustablePart GetAdjustablePart()
    {
        return _occurrence.GetAdjustablePart();
    }

    public void GetSimplifiedBodies(out int NumBodies, ref Array SimplifiedBodies)
    {
        _occurrence.GetSimplifiedBodies(out NumBodies, ref SimplifiedBodies);
    }

    public void GetBodyInversionMatrix(ref Array InvMatrix)
    {
        _occurrence.GetBodyInversionMatrix(ref InvMatrix);
    }

    public void GetExplodeMatrix(ref Array Matrix)
    {
        _occurrence.GetExplodeMatrix(ref Matrix);
    }

    public void RemoveOverrideBody()
    {
        _occurrence.RemoveOverrideBody();
    }

    public void GetRangeBox(ref Array MinRangePoint, ref Array MaxRangePoint)
    {
        _occurrence.GetRangeBox(ref MinRangePoint, ref MaxRangePoint);
    }

    public void GetInterpartDrivingOccurrences(out int NumDrivingOccurrences, ref Array DrivingOccurrences)
    {
        _occurrence.GetInterpartDrivingOccurrences(out NumDrivingOccurrences, ref DrivingOccurrences);
    }

    public void GetInterpartDrivenOccurrences(out int NumDrivenOccurrences, ref Array DrivenOccurrences)
    {
        _occurrence.GetInterpartDrivenOccurrences(out NumDrivenOccurrences, ref DrivenOccurrences);
    }

    public void CreateTopologyReferenceToBodyOverride(ref Array ReferenceKey, out TopologyReference TopologyReference)
    {
        _occurrence.CreateTopologyReferenceToBodyOverride(ref ReferenceKey, out TopologyReference);
    }

    public void Range(out double x_min, out double y_min, out double z_min, out double x_max, out double y_max,
        out double z_max)
    {
        _occurrence.Range(out x_min, out y_min, out z_min, out x_max, out y_max, out z_max);
    }

    public bool FileMissing()
    {
        return _occurrence.FileMissing();
    }

    public bool RecheckMissingFile()
    {
        return _occurrence.RecheckMissingFile();
    }

    public void PutStyleUsePartStyle()
    {
        _occurrence.PutStyleUsePartStyle();
    }

    public void PutStyleNone()
    {
        _occurrence.PutStyleNone();
    }

    public bool GetStyleNone()
    {
        return _occurrence.GetStyleNone();
    }

    public bool GetStyleUsePartStyle()
    {
        return _occurrence.GetStyleUsePartStyle();
    }

    public object BindKeyToTopology(bool BodyOverride, ref Array ReferenceKey)
    {
        return _occurrence.BindKeyToTopology(BodyOverride, ref ReferenceKey);
    }

    public void GetSectionedFacetData(int PartID, out OccurrenceSectionedFacetDataConstants FacetDataPresence,
        out int FacetCount,
        ref Array Points, ref Array Normals, ref Array TextureCoords, ref Array StyleIDs, ref Array FaceIDs)
    {
        _occurrence.GetSectionedFacetData(PartID, out FacetDataPresence, out FacetCount, ref Points, ref Normals,
            ref TextureCoords, ref StyleIDs, ref FaceIDs);
    }
}