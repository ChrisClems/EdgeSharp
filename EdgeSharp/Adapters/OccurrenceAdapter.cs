using SolidEdgeAssembly;
using SolidEdgeFramework;
using SolidEdgePart;

namespace EdgeSharp.Adapters;

public class OccurrenceAdapter : IOccurrenceEsx
{
    private Occurrence _occurrence;

    public OccurrenceAdapter(Occurrence occurrence)
    {
        _occurrence = occurrence;
    }
    
    public void Delete()
    {
        _occurrence.Delete();
    }

    public void Select(bool Replace)
    {
        _occurrence.Select(Replace);
    }

    public void PutTransform(double OriginX, double OriginY, double OriginZ, double AngleX, double AngleY, double AngleZ)
    {
        _occurrence.PutTransform(OriginX, OriginY, OriginZ, AngleX, AngleY, AngleZ);
    }

    public void GetTransform(out double OriginX, out double OriginY, out double OriginZ, out double AngleX, out double AngleY,
        out double AngleZ)
    {
        _occurrence.GetTransform(out OriginX, out OriginY, out OriginZ, out AngleX, out AngleY, out AngleZ);
    }

    public void PutOrigin(double OriginX, double OriginY, double OriginZ)
    {
        _occurrence.PutOrigin(OriginX, OriginY, OriginZ);
    }

    public void GetOrigin(out double OriginX, out double OriginY, out double OriginZ)
    {
        _occurrence.GetOrigin(out OriginX, out OriginY, out OriginZ);
    }

    public void Move(double DeltaX, double DeltaY, double DeltaZ)
    {
        _occurrence.Move(DeltaX, DeltaY, DeltaZ);
    }

    public void Rotate(double AxisX1, double AxisY1, double AxisZ1, double AxisX2, double AxisY2, double AxisZ2, double Angle)
    {
        _occurrence.Rotate(AxisX1, AxisY1, AxisZ1, AxisX2, AxisY2, AxisZ2, Angle);
    }

    public void PutMatrix(ref Array Matrix, bool Replace)
    {
        _occurrence.PutMatrix(ref Matrix, Replace);
    }

    public void GetMatrix(ref Array Matrix)
    {
        _occurrence.GetMatrix(ref Matrix);
    }

    public void Replace(string NewOccurrenceFileName, bool ReplaceAll, object NewFamilyMemberName = null!)
    {
        _occurrence.Replace(NewOccurrenceFileName, ReplaceAll, NewFamilyMemberName);
    }

    public void Mirror(object pPlane)
    {
        _occurrence.Mirror(pPlane);
    }

    public void MakeWritable()
    {
        _occurrence.MakeWritable();
    }

    public void GetReferenceKey(ref Array ReferenceKey, out object KeySize)
    {
        _occurrence.GetReferenceKey(ref ReferenceKey, out KeySize);
    }

    public void CreateTopologyReference(ref Array ReferenceKey, out TopologyReference TopologyReference)
    {
        _occurrence.CreateTopologyReference(ref ReferenceKey, out TopologyReference);
    }

    public bool IsTube()
    {
        return _occurrence.IsTube();
    }

    public Tube GetTube()
    {
        return _occurrence.GetTube();
    }

    public void SwapFamilyMember(string MemberName, bool SwapAllOccurrences)
    {
        _occurrence.SwapFamilyMember(MemberName, SwapAllOccurrences);
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

    public bool IsAlternateComponent()
    {
        return _occurrence.IsAlternateComponent();
    }

    public void AddAlternateComponent(string AlternateComponentFileName)
    {
        _occurrence.AddAlternateComponent(AlternateComponentFileName);
    }

    public void RemoveAlternateComponent(string AlternateComponentFileName)
    {
        _occurrence.RemoveAlternateComponent(AlternateComponentFileName);
    }

    public void RemoveAllAlternateComponents()
    {
        _occurrence.RemoveAllAlternateComponents();
    }

    public void GetAllAlternateComponents(out int AlternateComponentCount, out Array AlternateComponentFileNames)
    {
        _occurrence.GetAllAlternateComponents(out AlternateComponentCount, out AlternateComponentFileNames);
    }

    public void GetSimplifiedBodies(out int NumBodies, ref Array SimplifiedBodies)
    {
        _occurrence.GetSimplifiedBodies(out NumBodies, ref SimplifiedBodies);
    }

    public void CaptureRelationships(int RelationshipCount, ref Array RelationshipsToCapture)
    {
        _occurrence.CaptureRelationships(RelationshipCount, ref RelationshipsToCapture);
    }

    public void ClearCapturedRelationships()
    {
        _occurrence.ClearCapturedRelationships();
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

    public void RetrieveHoleLocation()
    {
        _occurrence.RetrieveHoleLocation();
    }

    public void DeleteHoleLocation()
    {
        _occurrence.DeleteHoleLocation();
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

    public void ResetName()
    {
        _occurrence.ResetName();
    }

    public void Range(out double x_min, out double y_min, out double z_min, out double x_max, out double y_max, out double z_max)
    {
        _occurrence.Range(out x_min, out y_min, out z_min, out x_max, out y_max, out z_max);
    }

    public void GetSimplifiedBodies2(out int NumBodies, ref Array SimplifiedBodies, ref Array Transforms)
    {
        _occurrence.GetSimplifiedBodies2(out NumBodies, ref SimplifiedBodies, ref Transforms);
    }

    public bool FileMissing()
    {
        return _occurrence.FileMissing();
    }

    public bool RecheckMissingFile()
    {
        return _occurrence.RecheckMissingFile();
    }

    public void FrameSaveAs(string FileName)
    {
        _occurrence.FrameSaveAs(FileName);
    }

    public void FrameSaveAsTranslated(string FileName)
    {
        _occurrence.FrameSaveAsTranslated(FileName);
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

    public string FrameSaveAsBiDM(string FilePath, string DocumentNumber, string Revision, string Title)
    {
        return _occurrence.FrameSaveAsBiDM(FilePath, DocumentNumber, Revision, Title);
    }

    public object BindKeyToTopology(bool BodyOverride, ref Array ReferenceKey)
    {
        return _occurrence.BindKeyToTopology(BodyOverride, ref ReferenceKey);
    }

    public void GetSectionedFacetData(int PartID, out OccurrenceSectionedFacetDataConstants FacetDataPresence, out int FacetCount,
        ref Array Points, ref Array Normals, ref Array TextureCoords, ref Array StyleIDs, ref Array FaceIDs)
    {
        _occurrence.GetSectionedFacetData(PartID, out FacetDataPresence, out FacetCount, ref Points, ref Normals, ref TextureCoords, ref StyleIDs, ref FaceIDs);
    }

    public void CutLength(out double dCutLength)
    {
        _occurrence.CutLength(out dCutLength);
    }

    public void MiterCut(out double MiterCut1, out double MiterCut2)
    {
        _occurrence.MiterCut(out MiterCut1, out MiterCut2);
    }

    public void SideFaceEndAngle(out double SideFaceEndAngle1, out double SideFaceEndAngle2)
    {
        _occurrence.SideFaceEndAngle(out SideFaceEndAngle1, out SideFaceEndAngle2);
    }

    public void EndFaceEndAngle(out double EndFaceEndAngle1, out double EndFaceEndAngle2)
    {
        _occurrence.EndFaceEndAngle(out EndFaceEndAngle1, out EndFaceEndAngle2);
    }

    public SuppressVariable GetSuppressionVariable()
    {
        return _occurrence.GetSuppressionVariable();
    }

    public SuppressVariable AddSuppressionVariable()
    {
        return _occurrence.AddSuppressionVariable();
    }

    public void DeleteSuppressionVariable()
    {
        _occurrence.DeleteSuppressionVariable();
    }

    public bool HasSuppressionVariable()
    {
        return _occurrence.HasSuppressionVariable();
    }

    public object Application => _occurrence.Application;

    public object Parent => _occurrence.Parent;

    public int Index => _occurrence.Index;

    public string Name
    {
        get => _occurrence.Name;
        set => _occurrence.Name = value;
    }

    public string PartFileName => _occurrence.PartFileName;

    public object PartDocument => _occurrence.PartDocument;

    public bool ReferenceOnly
    {
        get => _occurrence.ReferenceOnly;
        set => _occurrence.ReferenceOnly = value;
    }

    public bool Subassembly => _occurrence.Subassembly;

    public ObjectType Type => _occurrence.Type;

    public int Quantity
    {
        get => _occurrence.Quantity;
        set => _occurrence.Quantity = value;
    }

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

    public OccurrenceStatusConstants Status => _occurrence.Status;

    public object Relations3d => _occurrence.Relations3d;

    public bool IncludeInBom
    {
        get => _occurrence.IncludeInBom;
        set => _occurrence.IncludeInBom = value;
    }

    public bool DisplayInDrawings
    {
        get => _occurrence.DisplayInDrawings;
        set => _occurrence.DisplayInDrawings = value;
    }

    public bool DisplayInSubAssembly
    {
        get => _occurrence.DisplayInSubAssembly;
        set => _occurrence.DisplayInSubAssembly = value;
    }

    public bool IncludeInPhysicalProperties
    {
        get => _occurrence.IncludeInPhysicalProperties;
        set => _occurrence.IncludeInPhysicalProperties = value;
    }

    public bool IsForeign => _occurrence.IsForeign;

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

    public object AttributeSets => _occurrence.AttributeSets;

    public string OccurrenceFileName => _occurrence.OccurrenceFileName;

    public object OccurrenceDocument => _occurrence.OccurrenceDocument;

    public bool Activate
    {
        get => _occurrence.Activate;
        set => _occurrence.Activate = value;
    }

    public AssemblyDocument TopLevelDocument => _occurrence.TopLevelDocument;

    public SubOccurrences SubOccurrences => _occurrence.SubOccurrences;

    public double NongraphicQuantity
    {
        get => _occurrence.NongraphicQuantity;
        set => _occurrence.NongraphicQuantity = value;
    }

    public bool IsNongraphic => _occurrence.IsNongraphic;

    public bool HasNongraphicQuantity => _occurrence.HasNongraphicQuantity;

    public int NongraphicPrecision => _occurrence.NongraphicPrecision;

    public string NongraphicDescription => _occurrence.NongraphicDescription;

    public bool IsFamilyOfAssembly => _occurrence.IsFamilyOfAssembly;

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

    public bool IncludeInInterference
    {
        get => _occurrence.IncludeInInterference;
        set => _occurrence.IncludeInInterference = value;
    }

    public bool DisplayAsReference
    {
        get => _occurrence.DisplayAsReference;
        set => _occurrence.DisplayAsReference = value;
    }

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

    public bool HasUserDefinedName => _occurrence.HasUserDefinedName;

    public bool IsStructuralFrameItem => _occurrence.IsStructuralFrameItem;

    public bool IsWire => _occurrence.IsWire;

    public bool IsPipeFitting => _occurrence.IsPipeFitting;

    public bool IsPipeSegment => _occurrence.IsPipeSegment;

    public bool IsFastenerSystemItem => _occurrence.IsFastenerSystemItem;

    public bool DisplayCenterline
    {
        get => _occurrence.DisplayCenterline;
        set => _occurrence.DisplayCenterline = value;
    }

    public ObjectType NodeType => _occurrence.NodeType;

    public bool IsCopy => _occurrence.IsCopy;

    public bool IsFamilyOfParts => _occurrence.IsFamilyOfParts;

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

    public int OccurrenceID => _occurrence.OccurrenceID;

    public bool IsInternalComponent => _occurrence.IsInternalComponent;

    public InternalComponent InternalComponent => _occurrence.InternalComponent;

    public void SetCustomPropertyValue(string customPropertyName, string value)
    {
        _occurrence.CustomPropertyValue[customPropertyName] = value;
    }

    public string GetCustomPropertyValue(string customPropertyName)
    {
        return _occurrence.CustomPropertyValue[customPropertyName];
    }

    public bool GetIsAttributeSetPresent(string Name)
    {
        return _occurrence.IsAttributeSetPresent[Name];
    }
}