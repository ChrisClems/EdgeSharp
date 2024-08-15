using SolidEdgeAssembly;
using SolidEdgeFramework;

namespace EdgeSharp.Adapters;

public class SubOccurrenceAdapter : IOccurrenceEsx
{
    private readonly SubOccurrence _subOccurrence;

    public SubOccurrenceAdapter(SubOccurrence subOccurrence)
    {
        _subOccurrence = subOccurrence;
    }

    public Application Application => _subOccurrence.Application;

    public object Parent => _subOccurrence.Parent;

    public AssemblyDocument TopLevelDocument => _subOccurrence.TopLevelDocument;

    public object SubOccurrenceDocument => _subOccurrence.SubOccurrenceDocument;

    public string SubOccurrenceFileName => _subOccurrence.SubOccurrenceFileName;

    public ObjectType Type => _subOccurrence.Type;

    public bool Visible
    {
        get => _subOccurrence.Visible;
        set => _subOccurrence.Visible = value;
    }

    public bool UseSimplified
    {
        get => _subOccurrence.UseSimplified;
        set => _subOccurrence.UseSimplified = value;
    }

    public bool DisplayReferencePlanes
    {
        get => _subOccurrence.DisplayReferencePlanes;
        set => _subOccurrence.DisplayReferencePlanes = value;
    }

    public bool DisplayCoordinateSystems
    {
        get => _subOccurrence.DisplayCoordinateSystems;
        set => _subOccurrence.DisplayCoordinateSystems = value;
    }

    public bool DisplayConstructions
    {
        get => _subOccurrence.DisplayConstructions;
        set => _subOccurrence.DisplayConstructions = value;
    }

    public bool DisplayConstrCurves
    {
        get => _subOccurrence.DisplayConstrCurves;
        set => _subOccurrence.DisplayConstrCurves = value;
    }

    public bool DisplayReferenceAxes
    {
        get => _subOccurrence.DisplayReferenceAxes;
        set => _subOccurrence.DisplayReferenceAxes = value;
    }

    public bool DisplaySketches
    {
        get => _subOccurrence.DisplaySketches;
        set => _subOccurrence.DisplaySketches = value;
    }

    public bool DisplayAsLastSaved
    {
        get => _subOccurrence.DisplayAsLastSaved;
        set => _subOccurrence.DisplayAsLastSaved = value;
    }

    public bool Adjustable
    {
        get => _subOccurrence.Adjustable;
        set => _subOccurrence.Adjustable = value;
    }

    public Occurrence ThisAsOccurrence => _subOccurrence.ThisAsOccurrence;

    public bool HasBodyOverride => _subOccurrence.HasBodyOverride;

    public object Body => _subOccurrence.Body;

    public bool IsPatterned => _subOccurrence.IsPatterned;

    public bool IsPatternItem => _subOccurrence.IsPatternItem;

    public bool IsAdjustablePart => _subOccurrence.IsAdjustablePart;

    public SubassemblyBodies SubassemblyBodies => _subOccurrence.SubassemblyBodies;

    public int ItemNumber
    {
        get => _subOccurrence.ItemNumber;
        set => _subOccurrence.ItemNumber = value;
    }

    public bool ReferencePlanesVisible
    {
        get => _subOccurrence.ReferencePlanesVisible;
        set => _subOccurrence.ReferencePlanesVisible = value;
    }

    public bool CoordinateSystemsVisible
    {
        get => _subOccurrence.CoordinateSystemsVisible;
        set => _subOccurrence.CoordinateSystemsVisible = value;
    }

    public bool SketchesVisible
    {
        get => _subOccurrence.SketchesVisible;
        set => _subOccurrence.SketchesVisible = value;
    }

    public bool DisplayCenterline
    {
        get => _subOccurrence.DisplayCenterline;
        set => _subOccurrence.DisplayCenterline = value;
    }

    public Reference Reference => _subOccurrence.Reference;

    public ObjectType NodeType => _subOccurrence.NodeType;

    public bool DisplayLiveSections
    {
        get => _subOccurrence.DisplayLiveSections;
        set => _subOccurrence.DisplayLiveSections = value;
    }

    public bool DisplayDimensions
    {
        get => _subOccurrence.DisplayDimensions;
        set => _subOccurrence.DisplayDimensions = value;
    }

    public bool DisplayAnnotations
    {
        get => _subOccurrence.DisplayAnnotations;
        set => _subOccurrence.DisplayAnnotations = value;
    }

    public bool DisplayDesignBody
    {
        get => _subOccurrence.DisplayDesignBody;
        set => _subOccurrence.DisplayDesignBody = value;
    }

    public bool HideInDrawing
    {
        get => _subOccurrence.HideInDrawing;
        set => _subOccurrence.HideInDrawing = value;
    }

    public bool HideInSubassembly
    {
        get => _subOccurrence.HideInSubassembly;
        set => _subOccurrence.HideInSubassembly = value;
    }

    public bool Locatable
    {
        get => _subOccurrence.Locatable;
        set => _subOccurrence.Locatable = value;
    }

    public bool DisplayAsDraftReference
    {
        get => _subOccurrence.DisplayAsDraftReference;
        set => _subOccurrence.DisplayAsDraftReference = value;
    }

    public bool ExcludeFromPhysicalProperties
    {
        get => _subOccurrence.ExcludeFromPhysicalProperties;
        set => _subOccurrence.ExcludeFromPhysicalProperties = value;
    }

    public bool ExcludeFromReports
    {
        get => _subOccurrence.ExcludeFromReports;
        set => _subOccurrence.ExcludeFromReports = value;
    }

    public bool ExcludeFromInterference
    {
        get => _subOccurrence.ExcludeFromInterference;
        set => _subOccurrence.ExcludeFromInterference = value;
    }

    public object FaceStyle
    {
        get => _subOccurrence.FaceStyle;
        set => _subOccurrence.FaceStyle = value;
    }

    public string Style
    {
        get => _subOccurrence.Style;
        set => _subOccurrence.Style = value;
    }

    public bool IsInternalComponent => _subOccurrence.IsInternalComponent;

    public InternalComponent InternalComponent => _subOccurrence.InternalComponent;

    public SubOccurrences SubOccurrences => _subOccurrence.SubOccurrences;

    public bool Subassembly => _subOccurrence.Subassembly;

    public string Name => _subOccurrence.Name;

    public void SetCustomPropertyValue(string customPropertyName, string value)
    {
        _subOccurrence.CustomPropertyValue[customPropertyName] = value;
    }

    public string GetCustomPropertyValue(string customPropertyName)
    {
        return _subOccurrence.CustomPropertyValue[customPropertyName];
    }

    public void GetReferenceKey(ref Array ReferenceKey, out object KeySize)
    {
        _subOccurrence.GetReferenceKey(ref ReferenceKey, out KeySize);
    }

    public void GetMatrix(ref Array Matrix)
    {
        _subOccurrence.GetMatrix(ref Matrix);
    }

    public void CreateTopologyReference(ref Array ReferenceKey, out TopologyReference TopologyReference)
    {
        _subOccurrence.CreateTopologyReference(ref ReferenceKey, out TopologyReference);
    }

    public void GetMaterial(ref Array DiffuseColor, ref Array AmbientColor, ref Array SpecularColor,
        ref Array EmissionColor,
        out double Shininess, out double Opacity)
    {
        _subOccurrence.GetMaterial(ref DiffuseColor, ref AmbientColor, ref SpecularColor, ref EmissionColor,
            out Shininess, out Opacity);
    }

    public void PutMatrix(ref Array Matrix, bool Replace)
    {
        _subOccurrence.PutMatrix(ref Matrix, Replace);
    }

    public void GetSimplifiedBodies(out int NumBodies, ref Array SimplifiedBodies)
    {
        _subOccurrence.GetSimplifiedBodies(out NumBodies, ref SimplifiedBodies);
    }

    public void GetBodyInversionMatrix(ref Array InvMatrix)
    {
        _subOccurrence.GetBodyInversionMatrix(ref InvMatrix);
    }

    public AdjustablePart MakeAdjustablePart()
    {
        return _subOccurrence.MakeAdjustablePart();
    }

    public AdjustablePart GetAdjustablePart()
    {
        return _subOccurrence.GetAdjustablePart();
    }

    public void GetExplodeMatrix(ref Array Matrix)
    {
        _subOccurrence.GetExplodeMatrix(ref Matrix);
    }

    public void RemoveOverrideBody()
    {
        _subOccurrence.RemoveOverrideBody();
    }

    public void GetRangeBox(ref Array MinRangePoint, ref Array MaxRangePoint)
    {
        _subOccurrence.GetRangeBox(ref MinRangePoint, ref MaxRangePoint);
    }

    public void GetInterpartDrivingOccurrences(out int NumDrivingOccurrences, ref Array DrivingOccurrences)
    {
        _subOccurrence.GetInterpartDrivingOccurrences(out NumDrivingOccurrences, ref DrivingOccurrences);
    }

    public void GetInterpartDrivenOccurrences(out int NumDrivenOccurrences, ref Array DrivenOccurrences)
    {
        _subOccurrence.GetInterpartDrivenOccurrences(out NumDrivenOccurrences, ref DrivenOccurrences);
    }

    public void CreateTopologyReferenceToBodyOverride(ref Array ReferenceKey, out TopologyReference TopologyReference)
    {
        _subOccurrence.CreateTopologyReferenceToBodyOverride(ref ReferenceKey, out TopologyReference);
    }

    public void Range(out double x_min, out double y_min, out double z_min, out double x_max, out double y_max,
        out double z_max)
    {
        _subOccurrence.Range(out x_min, out y_min, out z_min, out x_max, out y_max, out z_max);
    }

    public bool FileMissing()
    {
        return _subOccurrence.FileMissing();
    }

    public bool RecheckMissingFile()
    {
        return _subOccurrence.RecheckMissingFile();
    }

    public object GetFaceStyle2(bool vbHonourPrefs)
    {
        return _subOccurrence.GetFaceStyle2(vbHonourPrefs);
    }

    public void PutStyleUsePartStyle()
    {
        _subOccurrence.PutStyleUsePartStyle();
    }

    public void PutStyleNone()
    {
        _subOccurrence.PutStyleNone();
    }

    public bool GetStyleNone()
    {
        return _subOccurrence.GetStyleNone();
    }

    public bool GetStyleUsePartStyle()
    {
        return _subOccurrence.GetStyleUsePartStyle();
    }

    public object BindKeyToTopology(bool BodyOverride, ref Array ReferenceKey)
    {
        return _subOccurrence.BindKeyToTopology(BodyOverride, ref ReferenceKey);
    }

    public void GetSectionedFacetData(int PartID, out OccurrenceSectionedFacetDataConstants FacetDataPresence,
        out int FacetCount,
        ref Array Points, ref Array Normals, ref Array TextureCoords, ref Array StyleIDs, ref Array FaceIDs)
    {
        _subOccurrence.GetSectionedFacetData(PartID, out FacetDataPresence, out FacetCount, ref Points, ref Normals,
            ref TextureCoords, ref StyleIDs, ref FaceIDs);
    }
}