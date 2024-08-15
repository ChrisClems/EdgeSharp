using SolidEdgeFramework;
using SolidEdgeFrameworkSupport;
using SolidEdgePart;

// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedGetOnlyAutoProperty
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace EdgeSharp.Adapters;

public class PartDocumentAdapter : IPartMetalDocument
{
    private readonly PartDocument _partDocument;

    public PartDocumentAdapter(PartDocument partDocument)
    {
        _partDocument = partDocument;
    }

    public Application Application => _partDocument.Application;

    public string FullName => _partDocument.FullName;

    public string Name
    {
        get => _partDocument.Name;
        set => _partDocument.Name = value;
    }

    public Application Parent => _partDocument.Parent;

    public string Path => _partDocument.Path;

    public bool ReadOnly
    {
        get => _partDocument.ReadOnly;
        set => _partDocument.ReadOnly = value;
    }

    public object RoutingSlip => _partDocument.RoutingSlip;

    public SelectSet SelectSet => _partDocument.SelectSet;

    public object SummaryInfo => _partDocument.SummaryInfo;

    public Windows Windows => _partDocument.Windows;

    public object Properties => _partDocument.Properties;

    public bool IsTemplate
    {
        get => _partDocument.IsTemplate;
        set => _partDocument.IsTemplate = value;
    }

    public DocumentStatus Status
    {
        get => _partDocument.Status;
        set => _partDocument.Status = value;
    }

    public UnitsOfMeasure UnitsOfMeasure => _partDocument.UnitsOfMeasure;

    public object ActiveSketch => _partDocument.ActiveSketch;

    public DocumentTypeConstants Type => _partDocument.Type;

    public object DocumentEvents => _partDocument.DocumentEvents;

    public object RootStorage => _partDocument.RootStorage;

    public bool Dirty
    {
        get => _partDocument.Dirty;
        set => _partDocument.Dirty = value;
    }

    public AttributeQuery AttributeQuery => _partDocument.AttributeQuery;

    public string CreatedVersion => _partDocument.CreatedVersion;

    public string LastSavedVersion => _partDocument.LastSavedVersion;

    public HighlightSets HighlightSets => _partDocument.HighlightSets;

    public bool InPlaceActivated => _partDocument.InPlaceActivated;

    public int UndoSteps
    {
        get => _partDocument.UndoSteps;
        set => _partDocument.UndoSteps = value;
    }

    public bool IsInsightFile => _partDocument.IsInsightFile;

    public NamedViews NamedViews => _partDocument.NamedViews;

    public Layers Layers => _partDocument.Layers;

    public bool IsGeometricVersionDirty => _partDocument.IsGeometricVersionDirty;

    public int ProfileUndoSteps
    {
        get => _partDocument.ProfileUndoSteps;
        set => _partDocument.ProfileUndoSteps = value;
    }

    public object Variables => _partDocument.Variables;

    public object InterpartLinks => _partDocument.InterpartLinks;

    public ProfileSets ProfileSets => _partDocument.ProfileSets;

    public RefPlanes RefPlanes => _partDocument.RefPlanes;

    public RefAxes RefAxes => _partDocument.RefAxes;

    public Models Models => _partDocument.Models;

    public HoleDataCollection HoleDataCollection => _partDocument.HoleDataCollection;

    public Sketchs Sketches => _partDocument.Sketches;

    public Constructions Constructions => _partDocument.Constructions;

    public FamilyMembers FamilyMembers => _partDocument.FamilyMembers;

    public DividedParts DividedParts => _partDocument.DividedParts;

    public StudyOwner StudyOwner => _partDocument.StudyOwner;

    public CoordinateSystems CoordinateSystems => _partDocument.CoordinateSystems;

    public PropertyTableDefinitions PropertyTableDefinitions => _partDocument.PropertyTableDefinitions;

    public AttachedPropertyTables AttachedPropertyTables => _partDocument.AttachedPropertyTables;

    public bool IsFeatureLibrary => _partDocument.IsFeatureLibrary;

    public object FamilyOfPartsEvents => _partDocument.FamilyOfPartsEvents;

    public object DividePartEvents => _partDocument.DividePartEvents;

    public Sensors Sensors => _partDocument.Sensors;

    public bool BodyCheck
    {
        get => _partDocument.BodyCheck;
        set => _partDocument.BodyCheck = value;
    }

    public SimplifiedModels SimplifiedModels => _partDocument.SimplifiedModels;

    public object ViewStyles => _partDocument.ViewStyles;

    public object FaceStyles => _partDocument.FaceStyles;

    public bool DesignBodyVisible
    {
        get => _partDocument.DesignBodyVisible;
        set => _partDocument.DesignBodyVisible = value;
    }

    public bool ShowCurvatureCombs
    {
        get => _partDocument.ShowCurvatureCombs;
        set => _partDocument.ShowCurvatureCombs = value;
    }

    public int GeometricVersion => _partDocument.GeometricVersion;

    public EdgebarFeatures DesignEdgebarFeatures => _partDocument.DesignEdgebarFeatures;

    public EdgebarFeatures SimplifyEdgebarFeatures => _partDocument.SimplifyEdgebarFeatures;

    public PhysicalPropertiesStatusConstants PhysicalPropertiesStatus => _partDocument.PhysicalPropertiesStatus;

    public DimensionStyles DimensionStyles => _partDocument.DimensionStyles;

    public AdjustableDefinition AdjustableDefinition => _partDocument.AdjustableDefinition;

    public bool IsAdjustablePart => _partDocument.IsAdjustablePart;

    public bool HardwareFile
    {
        get => _partDocument.HardwareFile;
        set => _partDocument.HardwareFile = value;
    }

    public bool HasCapturedRelationships => _partDocument.HasCapturedRelationships;

    public int CapturedRelationshipCount => _partDocument.CapturedRelationshipCount;

    public ComponentSketches ComponentSketches => _partDocument.ComponentSketches;

    public string ComponentName
    {
        get => _partDocument.ComponentName;
        set => _partDocument.ComponentName = value;
    }

    public Terminals Terminals => _partDocument.Terminals;

    public object FamilyOfPartsExEvents => _partDocument.FamilyOfPartsExEvents;

    public object LockedSketch => _partDocument.LockedSketch;

    public Constraints Constraints => _partDocument.Constraints;

    public UserDefinedSets UserDefinedSets => _partDocument.UserDefinedSets;

    public PMI PMI => _partDocument.PMI;

    public ModelingModeConstants ModelingMode
    {
        get => _partDocument.ModelingMode;
        set => _partDocument.ModelingMode = value;
    }

    public bool DisableMoveToSynchronous
    {
        get => _partDocument.DisableMoveToSynchronous;
        set => _partDocument.DisableMoveToSynchronous = value;
    }

    public object LinearStyles => _partDocument.LinearStyles;

    public object FillStyles => _partDocument.FillStyles;

    public object HatchPatternStyles => _partDocument.HatchPatternStyles;

    public bool AutomaticTransitionToSolutionManager
    {
        get => _partDocument.AutomaticTransitionToSolutionManager;
        set => _partDocument.AutomaticTransitionToSolutionManager = value;
    }

    public EdgebarFeatures FlatPatternEdgebarFeatures => _partDocument.FlatPatternEdgebarFeatures;

    public BendTable BendTable => _partDocument.BendTable;

    public bool IsMultiCADDriven => _partDocument.IsMultiCADDriven;

    public InterDocumentUpdate InterDocumentUpdate => _partDocument.InterDocumentUpdate;

    public Sketches3D Sketches3D => _partDocument.Sketches3D;

    public LabelWeldDataCollection LabelWeldDataCollection => _partDocument.LabelWeldDataCollection;

    public int CutawaysCount => _partDocument.CutawaysCount;

    public SketchBlocks Blocks => _partDocument.Blocks;

    public bool OrderedBodyInSyncVisible
    {
        get => _partDocument.OrderedBodyInSyncVisible;
        set => _partDocument.OrderedBodyInSyncVisible = value;
    }

    public object PhysicalPropertiesChangeEvents => _partDocument.PhysicalPropertiesChangeEvents;

    public object TextStyles => _partDocument.TextStyles;

    public object TextCharStyles => _partDocument.TextCharStyles;

    public bool UpdateOnFileSave
    {
        get => _partDocument.UpdateOnFileSave;
        set => _partDocument.UpdateOnFileSave = value;
    }

    public bool IsFamilyOfPartsMaster => _partDocument.IsFamilyOfPartsMaster;

    public bool IsFamilyOfPartsMember => _partDocument.IsFamilyOfPartsMember;

    public GenerativeStudies GenerativeStudies => _partDocument.GenerativeStudies;

    public SteeringWheel SteeringWheel => _partDocument.SteeringWheel;

    public UsedSketches UsedSketches => _partDocument.UsedSketches;

    public SectionViews SectionViews => _partDocument.SectionViews;

    public Decals Decals => _partDocument.Decals;

    public bool IsFamilyOfPartsSource => _partDocument.IsFamilyOfPartsSource;

    public void Activate()
    {
        _partDocument.Activate();
    }

    public FlatPatternModels FlatPatternModels => _partDocument.FlatPatternModels;

    public void Close(object SaveChanges = null, object FileName = null, object RouteWorkbook = null)
    {
        _partDocument.Close(SaveChanges, FileName, RouteWorkbook);
    }

    public void PrintOut(object Printer = null, object NumCopies = null, object Orientation = null,
        object PaperSize = null,
        object Scale = null, object PrintToFile = null, object OutputFileName = null, object PrintRange = null,
        object Sheets = null, object ColorAsBlack = null, object Collate = null)
    {
        _partDocument.PrintOut(Printer, NumCopies, Orientation, PaperSize, Scale, PrintToFile, OutputFileName,
            PrintRange, Sheets, ColorAsBlack, Collate);
    }

    public void Save()
    {
        _partDocument.Save();
    }

    public void SaveAs(string NewName, object IsATemplate = null, object FileFormat = null,
        object ReadOnlyEnforced = null,
        object ReadOnlyRecommended = null, object NewStatus = null, object CreateBackup = null,
        object UpdateLinkInContainer = null, object UpdateAllLinksInContainer = null)
    {
        _partDocument.SaveAs(NewName, IsATemplate, FileFormat, ReadOnlyEnforced, ReadOnlyRecommended, NewStatus,
            CreateBackup, UpdateLinkInContainer, UpdateAllLinksInContainer);
    }

    public void SaveCopyAs(string Name)
    {
        _partDocument.SaveCopyAs(Name);
    }

    public void SaveAsJT(string NewName, object Include_PreciseGeom = null, object Prod_Structure_Option = null,
        object Export_PMI = null, object Export_CoordinateSystem = null, object Export_3DBodies = null,
        object NumberofLODs = null, object JTFileUnit = null, object Write_Which_Files = null,
        object Use_Simplified_TopAsm = null, object Use_Simplified_SubAsm = null, object Use_Simplified_Part = null,
        object EnableDefaultOutputPath = null, object IncludeSEProperties = null, object Export_VisiblePartsOnly = null,
        object Export_VisibleConstructionsOnly = null, object RemoveUnsafeCharacters = null,
        object ExportSEPartFileAsSingleJTFile = null)
    {
        _partDocument.SaveAsJT(NewName, Include_PreciseGeom, Prod_Structure_Option, Export_PMI, Export_CoordinateSystem,
            Export_3DBodies, NumberofLODs, JTFileUnit, Write_Which_Files, Use_Simplified_TopAsm, Use_Simplified_SubAsm,
            Use_Simplified_Part, EnableDefaultOutputPath, IncludeSEProperties, Export_VisiblePartsOnly,
            Export_VisibleConstructionsOnly, RemoveUnsafeCharacters, ExportSEPartFileAsSingleJTFile);
    }

    public string SaveAsBIDM(string FilePath, string DocumentNumber, string Revision, string Title)
    {
        return _partDocument.SaveAsBIDM(FilePath, DocumentNumber, Revision, Title);
    }

    public string ReviseBIDM(string FilePath, string Revision, string Title)
    {
        return _partDocument.ReviseBIDM(FilePath, Revision, Title);
    }

    public void SendMail(object Recipients = null, object Subject = null, object ReturnReceipt = null)
    {
        _partDocument.SendMail(Recipients, Subject, ReturnReceipt);
    }

    public void EditProperties()
    {
        _partDocument.EditProperties();
    }

    public void SeekWriteAccess(out bool WriteAccess)
    {
        _partDocument.SeekWriteAccess(out WriteAccess);
    }

    public void CreatePreview()
    {
        _partDocument.CreatePreview();
    }

    public void SeekReadOnlyAccess(out bool ReadOnlyAccess)
    {
        _partDocument.SeekReadOnlyAccess(out ReadOnlyAccess);
    }

    public void ImportStyles2(seStyleTypeConstants StyleType, bool bReplace, object pSrcDocument)
    {
        _partDocument.ImportStyles2(StyleType, bReplace, pSrcDocument);
    }

    public void GetRegisteredCustomPropertiesBiDM(out object varPropInfo)
    {
        _partDocument.GetRegisteredCustomPropertiesBiDM(out varPropInfo);
    }

    public string SaveAsWithCustomPropertiesBIDM(string FilePath, string DocumentNumber, string Revision, string Title,
        object varPropInfo)
    {
        return _partDocument.SaveAsWithCustomPropertiesBIDM(FilePath, DocumentNumber, Revision, Title, varPropInfo);
    }

    public string ReviseWithCustomPropertiesBIDM(string FilePath, string Revision, string Title, object varPropInfo)
    {
        return _partDocument.ReviseWithCustomPropertiesBIDM(FilePath, Revision, Title, varPropInfo);
    }

    public void SaveAsPRC(string FileName)
    {
        _partDocument.SaveAsPRC(FileName);
    }

    public void FreezeAllInterpartLinks()
    {
        _partDocument.FreezeAllInterpartLinks();
    }

    public void BreakAllInterpartLinks()
    {
        _partDocument.BreakAllInterpartLinks();
    }

    public void ThawAllInterpartLinks()
    {
        _partDocument.ThawAllInterpartLinks();
    }

    public void HasInterpartLinks(ref bool pbHasInterpartLinks)
    {
        _partDocument.HasInterpartLinks(ref pbHasInterpartLinks);
    }

    public void GetInContextAssemblyNameForInterpartLinks(ref string pbstrAssemblyName)
    {
        _partDocument.GetInContextAssemblyNameForInterpartLinks(ref pbstrAssemblyName);
    }

    public object NewWindow(object NewWindowOptions = null, object Environment = null)
    {
        return _partDocument.NewWindow(NewWindowOptions, Environment);
    }

    public void ToggleRefPlanesDisplay(bool Display)
    {
        _partDocument.ToggleRefPlanesDisplay(Display);
    }

    public void BindKeyToObject(ref Array ReferenceKey, out object Object)
    {
        _partDocument.BindKeyToObject(ref ReferenceKey, out Object);
    }

    public void BindKeyToObjectEx(bool TopologyOnly, ref Array ReferenceKey, out object Object)
    {
        _partDocument.BindKeyToObjectEx(TopologyOnly, ref ReferenceKey, out Object);
    }

    public object QueryByProperty(PropertyTableConstants QueryType, object TableName = null, object NumProps = null,
        object PropName = null, object PropType = null, object PropVal = null)
    {
        return _partDocument.QueryByProperty(QueryType, TableName, NumProps, PropName, PropType, PropVal);
    }

    public void MinimumDistance(object Element1, object Element2, out double Distance, ref Array Point1,
        ref Array Point2)
    {
        _partDocument.MinimumDistance(Element1, Element2, out Distance, ref Point1, ref Point2);
    }

    public void Undo(object NumTransactions = null)
    {
        _partDocument.Undo(NumTransactions);
    }

    public void Redo(object NumTransactions = null)
    {
        _partDocument.Redo(NumTransactions);
    }

    public void GetGlobalParameter(PartGlobalConstants Parameter, out object Value)
    {
        _partDocument.GetGlobalParameter(Parameter, out Value);
    }

    public void SetGlobalParameter(PartGlobalConstants Parameter, object Value)
    {
        _partDocument.SetGlobalParameter(Parameter, Value);
    }

    public void MeasureAngle(object Element1, object Element2, out double TrueAngle, out double ApparentAngle,
        object Element3 = null)
    {
        _partDocument.MeasureAngle(Element1, Element2, out TrueAngle, out ApparentAngle, Element3);
    }

    public void NormalDistance(object Element1, object Element2, out double TrueDistance, out double ApparentDistance,
        out double DeltaX, out double DeltaY, out double DeltaZ, object CoordinateSystem = null)
    {
        _partDocument.NormalDistance(Element1, Element2, out TrueDistance, out ApparentDistance, out DeltaX, out DeltaY,
            out DeltaZ, CoordinateSystem);
    }

    public void GetBaseStyle(PartBaseStylesConstants BaseStyleType, out FaceStyle BaseStyle)
    {
        _partDocument.GetBaseStyle(BaseStyleType, out BaseStyle);
    }

    public void SetBaseStyle(PartBaseStylesConstants BaseStyleType, FaceStyle BaseStyle)
    {
        _partDocument.SetBaseStyle(BaseStyleType, BaseStyle);
    }

    public void ImportStyles(string FileName, object Overwrite = null)
    {
        _partDocument.ImportStyles(FileName, Overwrite);
    }

    public void GetContainerDocumentAndMatrixOfIPADoc(out object ContainerDocument, ref Array Matrix)
    {
        _partDocument.GetContainerDocumentAndMatrixOfIPADoc(out ContainerDocument, ref Matrix);
    }

    public void GetUserPhysicalProperties(out double Volume, out double Area, out double Mass,
        out Array CenterOfGravity,
        out Array CenterOfVolume, out Array GlobalMomentsOfInertia, out Array PrincipalMomentsOfInertia,
        out Array PrincipalAxes, out Array RadiiOfGyration)
    {
        _partDocument.GetUserPhysicalProperties(out Volume, out Area, out Mass, out CenterOfGravity, out CenterOfVolume,
            out GlobalMomentsOfInertia, out PrincipalMomentsOfInertia, out PrincipalAxes, out RadiiOfGyration);
    }

    public void PutUserPhysicalProperties(ref double Volume, ref double Area, ref double Mass,
        ref Array CenterOfGravity,
        ref Array CenterOfVolume, ref Array GlobalMomentsOfInertia, ref Array PrincipalMomentsOfInertia,
        ref Array PrincipalAxes, ref Array RadiiOfGyration)
    {
        _partDocument.PutUserPhysicalProperties(ref Volume, ref Area, ref Mass, ref CenterOfGravity, ref CenterOfVolume,
            ref GlobalMomentsOfInertia, ref PrincipalMomentsOfInertia, ref PrincipalAxes, ref RadiiOfGyration);
    }

    public void SaveBody(string FileName, object NewDocumentType = null, object ParasolidVersion = null,
        object NumModelsToBeSaved = null, object ModelsToBeSaved = null)
    {
        _partDocument.SaveBody(FileName, NewDocumentType, ParasolidVersion, NumModelsToBeSaved, ModelsToBeSaved);
    }

    public void Recompute()
    {
        _partDocument.Recompute();
    }

    public void Show(object NumObjects = null, object Objects = null)
    {
        _partDocument.Show(NumObjects, Objects);
    }

    public void Hide(object NumObjects = null, object Objects = null)
    {
        _partDocument.Hide(NumObjects, Objects);
    }

    public void ShowOnly(object NumObjects = null, object Objects = null)
    {
        _partDocument.ShowOnly(NumObjects, Objects);
    }

    public MeasureVariable AddMeasureVariable(MeasureVariableTypeConstants Type,
        MeasureVariableValueConstants ValueType,
        object Geom1, object Geom2, object Geom3 = null)
    {
        return _partDocument.AddMeasureVariable(Type, ValueType, Geom1, Geom2, Geom3);
    }

    public void GetCapturedRelationshipInformation(out Array RelationshipTypes, out Array OffsetTypes,
        out Array Offsets,
        out object Faces)
    {
        _partDocument.GetCapturedRelationshipInformation(out RelationshipTypes, out OffsetTypes, out Offsets,
            out Faces);
    }

    public void PlaceFeatureLibrary(string LibName, object RefPlane, double xOrigin, double yOrigin, double Zorigin,
        out Array Features)
    {
        _partDocument.PlaceFeatureLibrary(LibName, RefPlane, xOrigin, yOrigin, Zorigin, out Features);
    }

    public void CreateFeatureLibrary(string LibName, int NumberOfFeatures, ref Array Features)
    {
        _partDocument.CreateFeatureLibrary(LibName, NumberOfFeatures, ref Features);
    }

    public void ShowParentsAndChildren()
    {
        _partDocument.ShowParentsAndChildren();
    }

    public void GoalSeek(string NameTargetVariable, string NameVariableToChange, double dTargetValue,
        double dTimeLimitInSecs,
        int NumIterationsLimit, out double dTimeElapsed, out int NumIterations, out bool TimeLimitExceeded,
        out bool IterationsLimitExceeded)
    {
        _partDocument.GoalSeek(NameTargetVariable, NameVariableToChange, dTargetValue, dTimeLimitInSecs,
            NumIterationsLimit, out dTimeElapsed, out NumIterations, out TimeLimitExceeded,
            out IterationsLimitExceeded);
    }

    public object QueryByEntity(object Entity)
    {
        return _partDocument.QueryByEntity(Entity);
    }

    public void DeleteEntities(ref Array EntitiesToDelete, out Array EntitiesNotDeleted)
    {
        _partDocument.DeleteEntities(ref EntitiesToDelete, out EntitiesNotDeleted);
    }

    public void SetLiveRules(LiveRulesConstants LiveRule, bool bMaintain)
    {
        _partDocument.SetLiveRules(LiveRule, bMaintain);
    }

    public void GetLiveRules(LiveRulesConstants LiveRule, out bool bMaintain)
    {
        _partDocument.GetLiveRules(LiveRule, out bMaintain);
    }

    public void SuspendLiveRules(bool bSuspend)
    {
        _partDocument.SuspendLiveRules(bSuspend);
    }

    public void RestoreLiveRules()
    {
        _partDocument.RestoreLiveRules();
    }

    public void PMI_ByModelState(out PMI PMIObj, PMIModelStateConstants PMIModelState = 0)
    {
        _partDocument.PMI_ByModelState(out PMIObj, PMIModelState);
    }

    public void Separate(int NumberOfFeatures, ref Array Features)
    {
        _partDocument.Separate(NumberOfFeatures, ref Features);
    }

    public void Break(int NumberOfFeatures, ref Array Features)
    {
        _partDocument.Break(NumberOfFeatures, ref Features);
    }

    public void MoveToSynchronous(object pFeatureUnk, bool bIgnoreWarnings, bool bExtendSelection,
        out int NumberOfFeaturesCausingError, out Array ErrorMessageArray, out int NumberOfFeaturesCausingWarning,
        out Array WarningMessageArray, out double VolumeDifference)
    {
        _partDocument.MoveToSynchronous(pFeatureUnk, bIgnoreWarnings, bExtendSelection,
            out NumberOfFeaturesCausingError, out ErrorMessageArray, out NumberOfFeaturesCausingWarning,
            out WarningMessageArray, out VolumeDifference);
    }

    public void GetContainerDocumentAndOccurrenceOfIPADoc(out object ContainerDocument, out object IPAOccurrence)
    {
        _partDocument.GetContainerDocumentAndOccurrenceOfIPADoc(out ContainerDocument, out IPAOccurrence);
    }

    public void GetTopDocumentAndSubOccurrenceOfIPADoc(out object TopDocument, out object IPASubOccurrence)
    {
        _partDocument.GetTopDocumentAndSubOccurrenceOfIPADoc(out TopDocument, out IPASubOccurrence);
    }

    public void TransformToSynchronousSheetmetal(object pRefFace, int nEdgeNum, ref Array EdgesArray,
        object BRType = null, double dBRWidth = 0, double dBRLength = 0, double dBendRadius = 0,
        double dNeutralFactor = 0)
    {
        _partDocument.TransformToSynchronousSheetmetal(pRefFace, nEdgeNum, ref EdgesArray, BRType, dBRWidth, dBRLength,
            dBendRadius, dNeutralFactor);
    }

    public void SuspendPMI(bool bSuspend)
    {
        _partDocument.SuspendPMI(bSuspend);
    }

    public void SuspendPersistedRelationships(bool bSuspend)
    {
        _partDocument.SuspendPersistedRelationships(bSuspend);
    }

    public void GetDefaultCutSizeValues(out double DefaultCutSizeX, out double DefaultCutSizeY)
    {
        _partDocument.GetDefaultCutSizeValues(out DefaultCutSizeX, out DefaultCutSizeY);
    }

    public void SetDefaultCutSizeValues(double DefaultCutSizeX, double DefaultCutSizeY)
    {
        _partDocument.SetDefaultCutSizeValues(DefaultCutSizeX, DefaultCutSizeY);
    }

    public void GetMultiBodyPublishMembers(out int NumMembers, out Array Members, out bool AssemblyExist,
        out string AssemblyFileName, out MultiBodyPublishStatusConstants AssemblyStatus)
    {
        _partDocument.GetMultiBodyPublishMembers(out NumMembers, out Members, out AssemblyExist, out AssemblyFileName,
            out AssemblyStatus);
    }

    public void SaveMultiBodyPublishMembers(int NumMembers, ref Array Members, bool CreateAssembly, string FileName,
        out MultiBodyPublishStatusConstants AssemblyStatus)
    {
        _partDocument.SaveMultiBodyPublishMembers(NumMembers, ref Members, CreateAssembly, FileName,
            out AssemblyStatus);
    }

    public void SaveMultiBodyPublish(bool CreateAssemblyIfNeeded)
    {
        _partDocument.SaveMultiBodyPublish(CreateAssemblyIfNeeded);
    }

    public void GetRayIntersections(ref Array Bodies, ref Array Origins, ref Array Directions, int NumRays,
        double Radius,
        double Offset, out int NumIntersections, ref Array BodyIndex, ref Array IntersectionPoints,
        ref Array IntersectionNormals, ref Array RayIndex, ref Array Entity, out object Type)
    {
        _partDocument.GetRayIntersections(ref Bodies, ref Origins, ref Directions, NumRays, Radius, Offset,
            out NumIntersections, ref BodyIndex, ref IntersectionPoints, ref IntersectionNormals, ref RayIndex,
            ref Entity, out Type);
    }

    public void SetFrameDefineOriginAndOrientation(object pOrientationLine, object pOriginPoint)
    {
        _partDocument.SetFrameDefineOriginAndOrientation(pOrientationLine, pOriginPoint);
    }

    public void GetFrameDefineOriginAndOrientation(out object ppOrientationLine, out object ppOriginPoint)
    {
        _partDocument.GetFrameDefineOriginAndOrientation(out ppOrientationLine, out ppOriginPoint);
    }

    public void DeleteFrameDefineOriginAndOrientation()
    {
        _partDocument.DeleteFrameDefineOriginAndOrientation();
    }

    public void ActivateReflectivePlane()
    {
        _partDocument.ActivateReflectivePlane();
    }

    public void DeActivateReflectivePlane()
    {
        _partDocument.DeActivateReflectivePlane();
    }

    public void SetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, bool bStatus, double dDistance)
    {
        _partDocument.SetReflectivePlane(ReflectivePlane, bStatus, dDistance);
    }

    public void GetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, out bool bStatus, out double dDistance)
    {
        _partDocument.GetReflectivePlane(ReflectivePlane, out bStatus, out dDistance);
    }

    public void SetReflectivePlaneTransparency(bool bStatus, int dTransparency)
    {
        _partDocument.SetReflectivePlaneTransparency(bStatus, dTransparency);
    }

    public void GetReflectivePlaneTransparency(out bool bStatus, out int dTransparency)
    {
        _partDocument.GetReflectivePlaneTransparency(out bStatus, out dTransparency);
    }

    public void GetNumberOfParentsAndDependents(object pObject, out int NumberOfParents, out int NumberOfDependents)
    {
        _partDocument.GetNumberOfParentsAndDependents(pObject, out NumberOfParents, out NumberOfDependents);
    }

    public void GetParentsAndDependents(object pObject, out Array Parents, out Array Dependents)
    {
        _partDocument.GetParentsAndDependents(pObject, out Parents, out Dependents);
    }

    public void MeasureDistance(object Element1, object Element2, MeasureDistanceTypeConstants DistanceType,
        out double Distance,
        out double DX, out double DY, out double DZ, ref Array Point1, ref Array Point2)
    {
        _partDocument.MeasureDistance(Element1, Element2, DistanceType, out Distance, out DX, out DY, out DZ,
            ref Point1, ref Point2);
    }

    public void MeasureAngleEx(object Element1, object Element2, object Element3, out double Angle1, out double Angle2,
        out double Angle3, out double Angle4)
    {
        _partDocument.MeasureAngleEx(Element1, Element2, Element3, out Angle1, out Angle2, out Angle3, out Angle4);
    }

    public void InquireElement(object Element, ref Array InPoint, object CoordinateSystem, ref Array Point,
        out double SurfaceArea,
        out double Volume, out double Length)
    {
        _partDocument.InquireElement(Element, ref InPoint, CoordinateSystem, ref Point, out SurfaceArea, out Volume,
            out Length);
    }

    public void Get3dPrintInfo(out int iNumberOfTriangles, out int iNumberOfPoints, out int iNumberOfEdges,
        out double dMeshSurfaceArea, out double dMeshVolume, out double dFileSize, out double dExportToleranceValue,
        out double dSurfacePlaneAngTol, Print3DFileType Type = 0)
    {
        _partDocument.Get3dPrintInfo(out iNumberOfTriangles, out iNumberOfPoints, out iNumberOfEdges,
            out dMeshSurfaceArea, out dMeshVolume, out dFileSize, out dExportToleranceValue, out dSurfacePlaneAngTol,
            Type);
    }

    public void GetParentsAndChildren(object Object, out int NumParents, ref Array Parents, out int NumChildrens,
        ref Array Childrens)
    {
        _partDocument.GetParentsAndChildren(Object, out NumParents, ref Parents, out NumChildrens, ref Childrens);
    }

    public void LoadUOMPreferences(bool UpdateUomGlobals)
    {
        _partDocument.LoadUOMPreferences(UpdateUomGlobals);
    }

    public void CopytoPMI(object featureObj, seCopytoPMIConstants Type)
    {
        _partDocument.CopytoPMI(featureObj, Type);
    }

    public object get_AddInsStorage(string Name, int grfMode)
    {
        return _partDocument.get_AddInsStorage(Name, grfMode);
    }
}