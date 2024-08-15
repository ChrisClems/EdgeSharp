using SolidEdgeFramework;
using SolidEdgeFrameworkSupport;
using SolidEdgePart;

namespace EdgeSharp.Adapters;

public interface IPartMetalDocument
{
    Application Application { get; }

    string FullName { get; }

    string Name { get; set; }
    Application Parent { get; }

    string Path { get; }

    bool ReadOnly { get; set; }
    object RoutingSlip { get; }

    SelectSet SelectSet { get; }

    object SummaryInfo { get; }

    Windows Windows { get; }

    object Properties { get; }

    bool IsTemplate { get; set; }
    DocumentStatus Status { get; set; }
    UnitsOfMeasure UnitsOfMeasure { get; }

    object ActiveSketch { get; }

    DocumentTypeConstants Type { get; }

    object DocumentEvents { get; }

    object RootStorage { get; }

    bool Dirty { get; set; }
    AttributeQuery AttributeQuery { get; }

    string CreatedVersion { get; }

    string LastSavedVersion { get; }

    HighlightSets HighlightSets { get; }

    bool InPlaceActivated { get; }

    int UndoSteps { get; set; }
    bool IsInsightFile { get; }

    NamedViews NamedViews { get; }

    Layers Layers { get; }

    bool IsGeometricVersionDirty { get; }

    int ProfileUndoSteps { get; set; }
    object Variables { get; }

    object InterpartLinks { get; }

    ProfileSets ProfileSets { get; }

    RefPlanes RefPlanes { get; }

    RefAxes RefAxes { get; }

    Models Models { get; }

    HoleDataCollection HoleDataCollection { get; }

    Sketchs Sketches { get; }

    Constructions Constructions { get; }

    FamilyMembers FamilyMembers { get; }

    DividedParts DividedParts { get; }

    StudyOwner StudyOwner { get; }

    CoordinateSystems CoordinateSystems { get; }

    PropertyTableDefinitions PropertyTableDefinitions { get; }

    AttachedPropertyTables AttachedPropertyTables { get; }

    bool IsFeatureLibrary { get; }

    object FamilyOfPartsEvents { get; }

    object DividePartEvents { get; }

    bool BodyCheck { get; set; }
    SimplifiedModels SimplifiedModels { get; }

    object ViewStyles { get; }

    object FaceStyles { get; }

    bool DesignBodyVisible { get; set; }
    
    int GeometricVersion { get; }

    EdgebarFeatures DesignEdgebarFeatures { get; }

    EdgebarFeatures SimplifyEdgebarFeatures { get; }

    PhysicalPropertiesStatusConstants PhysicalPropertiesStatus { get; }

    DimensionStyles DimensionStyles { get; }

    AdjustableDefinition AdjustableDefinition { get; }

    bool IsAdjustablePart { get; }

    bool HardwareFile { get; set; }
    bool HasCapturedRelationships { get; }

    int CapturedRelationshipCount { get; }

    ComponentSketches ComponentSketches { get; }

    string ComponentName { get; set; }
    Terminals Terminals { get; }

    object FamilyOfPartsExEvents { get; }

    object LockedSketch { get; }

    Constraints Constraints { get; }

    UserDefinedSets UserDefinedSets { get; }

    PMI PMI { get; }

    ModelingModeConstants ModelingMode { get; set; }
    bool DisableMoveToSynchronous { get; set; }
    object LinearStyles { get; }

    object FillStyles { get; }

    object HatchPatternStyles { get; }

    bool AutomaticTransitionToSolutionManager { get; set; }
    EdgebarFeatures FlatPatternEdgebarFeatures { get; }

    BendTable BendTable { get; }

    bool IsMultiCADDriven { get; }

    InterDocumentUpdate InterDocumentUpdate { get; }

    Sketches3D Sketches3D { get; }

    int CutawaysCount { get; }

    SketchBlocks Blocks { get; }

    bool OrderedBodyInSyncVisible { get; set; }
    object PhysicalPropertiesChangeEvents { get; }

    object TextStyles { get; }

    object TextCharStyles { get; }

    bool UpdateOnFileSave { get; set; }
    bool IsFamilyOfPartsMaster { get; }

    bool IsFamilyOfPartsMember { get; }

    SteeringWheel SteeringWheel { get; }

    UsedSketches UsedSketches { get; }

    SectionViews SectionViews { get; }

    Decals Decals { get; }

    bool IsFamilyOfPartsSource { get; }

    FlatPatternModels FlatPatternModels { get; }

    public void Activate();

    public void Close(object SaveChanges = null, object FileName = null, object RouteWorkbook = null);

    public void PrintOut(object Printer = null, object NumCopies = null, object Orientation = null,
        object PaperSize = null,
        object Scale = null, object PrintToFile = null, object OutputFileName = null, object PrintRange = null,
        object Sheets = null, object ColorAsBlack = null, object Collate = null);

    public void Save();

    public void SaveAs(string NewName, object IsATemplate = null, object FileFormat = null,
        object ReadOnlyEnforced = null,
        object ReadOnlyRecommended = null, object NewStatus = null, object CreateBackup = null,
        object UpdateLinkInContainer = null, object UpdateAllLinksInContainer = null);

    public void SaveCopyAs(string Name);

    public void SaveAsJT(string NewName, object Include_PreciseGeom = null, object Prod_Structure_Option = null,
        object Export_PMI = null, object Export_CoordinateSystem = null, object Export_3DBodies = null,
        object NumberofLODs = null, object JTFileUnit = null, object Write_Which_Files = null,
        object Use_Simplified_TopAsm = null, object Use_Simplified_SubAsm = null, object Use_Simplified_Part = null,
        object EnableDefaultOutputPath = null, object IncludeSEProperties = null, object Export_VisiblePartsOnly = null,
        object Export_VisibleConstructionsOnly = null, object RemoveUnsafeCharacters = null,
        object ExportSEPartFileAsSingleJTFile = null);

    public string SaveAsBIDM(string FilePath, string DocumentNumber, string Revision, string Title);

    public string ReviseBIDM(string FilePath, string Revision, string Title);

    public void SendMail(object Recipients = null, object Subject = null, object ReturnReceipt = null);

    public void EditProperties();

    public void SeekWriteAccess(out bool WriteAccess);

    public void CreatePreview();

    public void SeekReadOnlyAccess(out bool ReadOnlyAccess);

    public void ImportStyles2(seStyleTypeConstants StyleType, bool bReplace, object pSrcDocument);

    public void GetRegisteredCustomPropertiesBiDM(out object varPropInfo);

    public string SaveAsWithCustomPropertiesBIDM(string FilePath, string DocumentNumber, string Revision, string Title,
        object varPropInfo);

    public string ReviseWithCustomPropertiesBIDM(string FilePath, string Revision, string Title, object varPropInfo);

    public void SaveAsPRC(string FileName);

    public void FreezeAllInterpartLinks();

    public void BreakAllInterpartLinks();

    public void ThawAllInterpartLinks();

    public void HasInterpartLinks(ref bool pbHasInterpartLinks);

    public void GetInContextAssemblyNameForInterpartLinks(ref string pbstrAssemblyName);

    public object NewWindow(object NewWindowOptions = null, object Environment = null);

    public void ToggleRefPlanesDisplay(bool Display);

    public void BindKeyToObject(ref Array ReferenceKey, out object Object);

    public void BindKeyToObjectEx(bool TopologyOnly, ref Array ReferenceKey, out object Object);

    public object QueryByProperty(PropertyTableConstants QueryType, object TableName = null, object NumProps = null,
        object PropName = null, object PropType = null, object PropVal = null);

    public void MinimumDistance(object Element1, object Element2, out double Distance, ref Array Point1,
        ref Array Point2);

    public void Undo(object NumTransactions = null);

    public void Redo(object NumTransactions = null);

    public void MeasureAngle(object Element1, object Element2, out double TrueAngle, out double ApparentAngle,
        object Element3 = null);

    public void NormalDistance(object Element1, object Element2, out double TrueDistance, out double ApparentDistance,
        out double DeltaX, out double DeltaY, out double DeltaZ, object CoordinateSystem = null);

    public void GetBaseStyle(PartBaseStylesConstants BaseStyleType, out FaceStyle BaseStyle);

    public void SetBaseStyle(PartBaseStylesConstants BaseStyleType, FaceStyle BaseStyle);

    public void ImportStyles(string FileName, object Overwrite = null);

    public void GetContainerDocumentAndMatrixOfIPADoc(out object ContainerDocument, ref Array Matrix);

    public void GetUserPhysicalProperties(out double Volume, out double Area, out double Mass,
        out Array CenterOfGravity,
        out Array CenterOfVolume, out Array GlobalMomentsOfInertia, out Array PrincipalMomentsOfInertia,
        out Array PrincipalAxes, out Array RadiiOfGyration);

    public void PutUserPhysicalProperties(ref double Volume, ref double Area, ref double Mass,
        ref Array CenterOfGravity,
        ref Array CenterOfVolume, ref Array GlobalMomentsOfInertia, ref Array PrincipalMomentsOfInertia,
        ref Array PrincipalAxes, ref Array RadiiOfGyration);

    public void SaveBody(string FileName, object NewDocumentType = null, object ParasolidVersion = null,
        object NumModelsToBeSaved = null, object ModelsToBeSaved = null);

    public void Recompute();

    public void Show(object NumObjects = null, object Objects = null);

    public void Hide(object NumObjects = null, object Objects = null);

    public void ShowOnly(object NumObjects = null, object Objects = null);

    public MeasureVariable AddMeasureVariable(MeasureVariableTypeConstants Type,
        MeasureVariableValueConstants ValueType,
        object Geom1, object Geom2, object Geom3 = null);

    public void GetCapturedRelationshipInformation(out Array RelationshipTypes, out Array OffsetTypes,
        out Array Offsets,
        out object Faces);

    public void PlaceFeatureLibrary(string LibName, object RefPlane, double xOrigin, double yOrigin, double Zorigin,
        out Array Features);

    public void CreateFeatureLibrary(string LibName, int NumberOfFeatures, ref Array Features);

    public void ShowParentsAndChildren();

    public void GoalSeek(string NameTargetVariable, string NameVariableToChange, double dTargetValue,
        double dTimeLimitInSecs,
        int NumIterationsLimit, out double dTimeElapsed, out int NumIterations, out bool TimeLimitExceeded,
        out bool IterationsLimitExceeded);

    public object QueryByEntity(object Entity);

    public void DeleteEntities(ref Array EntitiesToDelete, out Array EntitiesNotDeleted);

    public void SetLiveRules(LiveRulesConstants LiveRule, bool bMaintain);

    public void GetLiveRules(LiveRulesConstants LiveRule, out bool bMaintain);

    public void SuspendLiveRules(bool bSuspend);

    public void RestoreLiveRules();

    public void PMI_ByModelState(out PMI PMIObj, PMIModelStateConstants PMIModelState = 0);

    public void Separate(int NumberOfFeatures, ref Array Features);

    public void Break(int NumberOfFeatures, ref Array Features);

    public void GetContainerDocumentAndOccurrenceOfIPADoc(out object ContainerDocument, out object IPAOccurrence);

    public void GetTopDocumentAndSubOccurrenceOfIPADoc(out object TopDocument, out object IPASubOccurrence);

    public void TransformToSynchronousSheetmetal(object pRefFace, int nEdgeNum, ref Array EdgesArray,
        object BRType = null, double dBRWidth = 0, double dBRLength = 0, double dBendRadius = 0,
        double dNeutralFactor = 0);

    public void SuspendPMI(bool bSuspend);

    public void SuspendPersistedRelationships(bool bSuspend);

    public void GetDefaultCutSizeValues(out double DefaultCutSizeX, out double DefaultCutSizeY);

    public void SetDefaultCutSizeValues(double DefaultCutSizeX, double DefaultCutSizeY);

    public void GetMultiBodyPublishMembers(out int NumMembers, out Array Members, out bool AssemblyExist,
        out string AssemblyFileName, out MultiBodyPublishStatusConstants AssemblyStatus);

    public void SaveMultiBodyPublishMembers(int NumMembers, ref Array Members, bool CreateAssembly, string FileName,
        out MultiBodyPublishStatusConstants AssemblyStatus);

    public void SaveMultiBodyPublish(bool CreateAssemblyIfNeeded);

    public void ActivateReflectivePlane();

    public void DeActivateReflectivePlane();

    public void SetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, bool bStatus, double dDistance);

    public void GetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, out bool bStatus, out double dDistance);

    public void SetReflectivePlaneTransparency(bool bStatus, int dTransparency);

    public void GetReflectivePlaneTransparency(out bool bStatus, out int dTransparency);

    public void GetNumberOfParentsAndDependents(object pObject, out int NumberOfParents, out int NumberOfDependents);

    public void GetParentsAndDependents(object pObject, out Array Parents, out Array Dependents);

    public void MeasureDistance(object Element1, object Element2, MeasureDistanceTypeConstants DistanceType,
        out double Distance,
        out double DX, out double DY, out double DZ, ref Array Point1, ref Array Point2);

    public void MeasureAngleEx(object Element1, object Element2, object Element3, out double Angle1, out double Angle2,
        out double Angle3, out double Angle4);

    public void InquireElement(object Element, ref Array InPoint, object CoordinateSystem, ref Array Point,
        out double SurfaceArea,
        out double Volume, out double Length);

    public void Get3dPrintInfo(out int iNumberOfTriangles, out int iNumberOfPoints, out int iNumberOfEdges,
        out double dMeshSurfaceArea, out double dMeshVolume, out double dFileSize, out double dExportToleranceValue,
        out double dSurfacePlaneAngTol, Print3DFileType Type = 0);

    public void GetParentsAndChildren(object Object, out int NumParents, ref Array Parents, out int NumChildrens,
        ref Array Childrens);

    public void LoadUOMPreferences(bool UpdateUomGlobals);

    public void CopytoPMI(object featureObj, seCopytoPMIConstants Type);

    public object get_AddInsStorage(string Name, int grfMode);
}