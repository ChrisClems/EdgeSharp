using SolidEdgeFramework;
using SolidEdgeFrameworkSupport;
using SolidEdgePart;

// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedGetOnlyAutoProperty
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace EdgeSharp.Adapters;

public class SheetMetalDocumentAdapter : IPartDocumentEsx
{
    private readonly SheetMetalDocument _sheetMetalDocument;

    public SheetMetalDocumentAdapter(SheetMetalDocument sheetMetalDocument)
    {
        _sheetMetalDocument = sheetMetalDocument;
    }

    public Application Application => _sheetMetalDocument.Application;

    public string FullName => _sheetMetalDocument.FullName;

    public string Name
    {
        get => _sheetMetalDocument.Name;
        set => _sheetMetalDocument.Name = value;
    }

    public Application Parent => _sheetMetalDocument.Parent;

    public string Path => _sheetMetalDocument.Path;

    public bool ReadOnly
    {
        get => _sheetMetalDocument.ReadOnly;
        set => _sheetMetalDocument.ReadOnly = value;
    }

    public object RoutingSlip => _sheetMetalDocument.RoutingSlip;

    public SelectSet SelectSet => _sheetMetalDocument.SelectSet;

    public object SummaryInfo => _sheetMetalDocument.SummaryInfo;

    public Windows Windows => _sheetMetalDocument.Windows;

    public object Properties => _sheetMetalDocument.Properties;

    public bool IsTemplate
    {
        get => _sheetMetalDocument.IsTemplate;
        set => _sheetMetalDocument.IsTemplate = value;
    }

    public DocumentStatus Status
    {
        get => _sheetMetalDocument.Status;
        set => _sheetMetalDocument.Status = value;
    }

    public UnitsOfMeasure UnitsOfMeasure => _sheetMetalDocument.UnitsOfMeasure;

    public object ActiveSketch => _sheetMetalDocument.ActiveSketch;

    public DocumentTypeConstants Type => _sheetMetalDocument.Type;

    public object DocumentEvents => _sheetMetalDocument.DocumentEvents;

    public object RootStorage => _sheetMetalDocument.RootStorage;

    public bool Dirty
    {
        get => _sheetMetalDocument.Dirty;
        set => _sheetMetalDocument.Dirty = value;
    }

    public AttributeQuery AttributeQuery => _sheetMetalDocument.AttributeQuery;

    public string CreatedVersion => _sheetMetalDocument.CreatedVersion;

    public string LastSavedVersion => _sheetMetalDocument.LastSavedVersion;

    public HighlightSets HighlightSets => _sheetMetalDocument.HighlightSets;

    public bool InPlaceActivated => _sheetMetalDocument.InPlaceActivated;

    public int UndoSteps
    {
        get => _sheetMetalDocument.UndoSteps;
        set => _sheetMetalDocument.UndoSteps = value;
    }

    public bool IsInsightFile => _sheetMetalDocument.IsInsightFile;

    public NamedViews NamedViews => _sheetMetalDocument.NamedViews;

    public Layers Layers => _sheetMetalDocument.Layers;

    public bool IsGeometricVersionDirty => _sheetMetalDocument.IsGeometricVersionDirty;

    public int ProfileUndoSteps
    {
        get => _sheetMetalDocument.ProfileUndoSteps;
        set => _sheetMetalDocument.ProfileUndoSteps = value;
    }

    public object Variables => _sheetMetalDocument.Variables;

    public object InterpartLinks => _sheetMetalDocument.InterpartLinks;

    public ProfileSets ProfileSets => _sheetMetalDocument.ProfileSets;

    public RefPlanes RefPlanes => _sheetMetalDocument.RefPlanes;

    public RefAxes RefAxes => _sheetMetalDocument.RefAxes;

    public Models Models => _sheetMetalDocument.Models;

    public HoleDataCollection HoleDataCollection => _sheetMetalDocument.HoleDataCollection;

    public Sketchs Sketches => _sheetMetalDocument.Sketches;

    public Constructions Constructions => _sheetMetalDocument.Constructions;

    public FamilyMembers FamilyMembers => _sheetMetalDocument.FamilyMembers;

    public DividedParts DividedParts => _sheetMetalDocument.DividedParts;

    public CoordinateSystems CoordinateSystems => _sheetMetalDocument.CoordinateSystems;

    public StudyOwner StudyOwner => _sheetMetalDocument.StudyOwner;

    public PropertyTableDefinitions PropertyTableDefinitions => _sheetMetalDocument.PropertyTableDefinitions;

    public AttachedPropertyTables AttachedPropertyTables => _sheetMetalDocument.AttachedPropertyTables;

    public bool IsFeatureLibrary => _sheetMetalDocument.IsFeatureLibrary;

    public object FamilyOfPartsEvents => _sheetMetalDocument.FamilyOfPartsEvents;

    public object DividePartEvents => _sheetMetalDocument.DividePartEvents;

    public bool BodyCheck
    {
        get => _sheetMetalDocument.BodyCheck;
        set => _sheetMetalDocument.BodyCheck = value;
    }

    public SimplifiedModels SimplifiedModels => _sheetMetalDocument.SimplifiedModels;

    public object ViewStyles => _sheetMetalDocument.ViewStyles;

    public object FaceStyles => _sheetMetalDocument.FaceStyles;

    public bool DesignBodyVisible
    {
        get => _sheetMetalDocument.DesignBodyVisible;
        set => _sheetMetalDocument.DesignBodyVisible = value;
    }

    public int GeometricVersion => _sheetMetalDocument.GeometricVersion;

    public EdgebarFeatures DesignEdgebarFeatures => _sheetMetalDocument.DesignEdgebarFeatures;

    public EdgebarFeatures SimplifyEdgebarFeatures => _sheetMetalDocument.SimplifyEdgebarFeatures;

    public EdgebarFeatures FlatPatternEdgebarFeatures => _sheetMetalDocument.FlatPatternEdgebarFeatures;

    public PhysicalPropertiesStatusConstants PhysicalPropertiesStatus => _sheetMetalDocument.PhysicalPropertiesStatus;

    public DimensionStyles DimensionStyles => _sheetMetalDocument.DimensionStyles;

    public AdjustableDefinition AdjustableDefinition => _sheetMetalDocument.AdjustableDefinition;

    public bool IsAdjustablePart => _sheetMetalDocument.IsAdjustablePart;

    public bool HardwareFile
    {
        get => _sheetMetalDocument.HardwareFile;
        set => _sheetMetalDocument.HardwareFile = value;
    }

    public bool HasCapturedRelationships => _sheetMetalDocument.HasCapturedRelationships;

    public int CapturedRelationshipCount => _sheetMetalDocument.CapturedRelationshipCount;

    public ComponentSketches ComponentSketches => _sheetMetalDocument.ComponentSketches;

    public string ComponentName
    {
        get => _sheetMetalDocument.ComponentName;
        set => _sheetMetalDocument.ComponentName = value;
    }

    public Terminals Terminals => _sheetMetalDocument.Terminals;

    public object FamilyOfPartsExEvents => _sheetMetalDocument.FamilyOfPartsExEvents;

    public BendTable BendTable => _sheetMetalDocument.BendTable;

    public PMI PMI => _sheetMetalDocument.PMI;

    public ModelingModeConstants ModelingMode
    {
        get => _sheetMetalDocument.ModelingMode;
        set => _sheetMetalDocument.ModelingMode = value;
    }

    public UserDefinedSets UserDefinedSets => _sheetMetalDocument.UserDefinedSets;

    public object LockedSketch => _sheetMetalDocument.LockedSketch;

    public bool DisableMoveToSynchronous
    {
        get => _sheetMetalDocument.DisableMoveToSynchronous;
        set => _sheetMetalDocument.DisableMoveToSynchronous = value;
    }

    public Constraints Constraints => _sheetMetalDocument.Constraints;

    public object LinearStyles => _sheetMetalDocument.LinearStyles;

    public object FillStyles => _sheetMetalDocument.FillStyles;

    public object HatchPatternStyles => _sheetMetalDocument.HatchPatternStyles;

    public bool AutomaticTransitionToSolutionManager
    {
        get => _sheetMetalDocument.AutomaticTransitionToSolutionManager;
        set => _sheetMetalDocument.AutomaticTransitionToSolutionManager = value;
    }

    public bool IsMultiCADDriven => _sheetMetalDocument.IsMultiCADDriven;

    public InterDocumentUpdate InterDocumentUpdate => _sheetMetalDocument.InterDocumentUpdate;

    public Sketches3D Sketches3D => _sheetMetalDocument.Sketches3D;

    public int CutawaysCount => _sheetMetalDocument.CutawaysCount;

    public SketchBlocks Blocks => _sheetMetalDocument.Blocks;

    public bool OrderedBodyInSyncVisible
    {
        get => _sheetMetalDocument.OrderedBodyInSyncVisible;
        set => _sheetMetalDocument.OrderedBodyInSyncVisible = value;
    }

    public object PhysicalPropertiesChangeEvents => _sheetMetalDocument.PhysicalPropertiesChangeEvents;

    public object TextStyles => _sheetMetalDocument.TextStyles;

    public object TextCharStyles => _sheetMetalDocument.TextCharStyles;

    public bool UpdateOnFileSave
    {
        get => _sheetMetalDocument.UpdateOnFileSave;
        set => _sheetMetalDocument.UpdateOnFileSave = value;
    }

    public bool IsFamilyOfPartsMaster => _sheetMetalDocument.IsFamilyOfPartsMaster;

    public bool IsFamilyOfPartsMember => _sheetMetalDocument.IsFamilyOfPartsMember;

    public SteeringWheel SteeringWheel => _sheetMetalDocument.SteeringWheel;

    public UsedSketches UsedSketches => _sheetMetalDocument.UsedSketches;

    public SectionViews SectionViews => _sheetMetalDocument.SectionViews;

    public Decals Decals => _sheetMetalDocument.Decals;

    public bool IsFamilyOfPartsSource => _sheetMetalDocument.IsFamilyOfPartsSource;

    public void Activate()
    {
        _sheetMetalDocument.Activate();
    }

    public FlatPatternModels FlatPatternModels => _sheetMetalDocument.FlatPatternModels;

    public void Close(object SaveChanges = null, object FileName = null, object RouteWorkbook = null)
    {
        _sheetMetalDocument.Close(SaveChanges, FileName, RouteWorkbook);
    }

    public void PrintOut(object Printer = null, object NumCopies = null, object Orientation = null,
        object PaperSize = null,
        object Scale = null, object PrintToFile = null, object OutputFileName = null, object PrintRange = null,
        object Sheets = null, object ColorAsBlack = null, object Collate = null)
    {
        _sheetMetalDocument.PrintOut(Printer, NumCopies, Orientation, PaperSize, Scale, PrintToFile, OutputFileName,
            PrintRange, Sheets, ColorAsBlack, Collate);
    }

    public void Save()
    {
        _sheetMetalDocument.Save();
    }

    public void SaveAs(string NewName, object IsATemplate = null, object FileFormat = null,
        object ReadOnlyEnforced = null,
        object ReadOnlyRecommended = null, object NewStatus = null, object CreateBackup = null,
        object UpdateLinkInContainer = null, object UpdateAllLinksInContainer = null)
    {
        _sheetMetalDocument.SaveAs(NewName, IsATemplate, FileFormat, ReadOnlyEnforced, ReadOnlyRecommended, NewStatus,
            CreateBackup, UpdateLinkInContainer, UpdateAllLinksInContainer);
    }

    public void SaveCopyAs(string NewCopyName)
    {
        _sheetMetalDocument.SaveCopyAs(NewCopyName);
    }

    public void SaveAsJT(string NewName, object Include_PreciseGeom = null, object Prod_Structure_Option = null,
        object Export_PMI = null, object Export_CoordinateSystem = null, object Export_3DBodies = null,
        object NumberofLODs = null, object JTFileUnit = null, object Write_Which_Files = null,
        object Use_Simplified_TopAsm = null, object Use_Simplified_SubAsm = null, object Use_Simplified_Part = null,
        object EnableDefaultOutputPath = null, object IncludeSEProperties = null, object Export_VisiblePartsOnly = null,
        object Export_VisibleConstructionsOnly = null, object RemoveUnsafeCharacters = null,
        object ExportSEPartFileAsSingleJTFile = null)
    {
        _sheetMetalDocument.SaveAsJT(NewName, Include_PreciseGeom, Prod_Structure_Option, Export_PMI,
            Export_CoordinateSystem, Export_3DBodies, NumberofLODs, JTFileUnit, Write_Which_Files,
            Use_Simplified_TopAsm, Use_Simplified_SubAsm, Use_Simplified_Part, EnableDefaultOutputPath,
            IncludeSEProperties, Export_VisiblePartsOnly, Export_VisibleConstructionsOnly, RemoveUnsafeCharacters,
            ExportSEPartFileAsSingleJTFile);
    }

    public string SaveAsBIDM(string FilePath, string DocumentNumber, string Revision, string Title)
    {
        return _sheetMetalDocument.SaveAsBIDM(FilePath, DocumentNumber, Revision, Title);
    }

    public string ReviseBIDM(string FilePath, string Revision, string Title)
    {
        return _sheetMetalDocument.ReviseBIDM(FilePath, Revision, Title);
    }

    public void SendMail(object Recipients = null, object Subject = null, object ReturnReceipt = null)
    {
        _sheetMetalDocument.SendMail(Recipients, Subject, ReturnReceipt);
    }

    public void EditProperties()
    {
        _sheetMetalDocument.EditProperties();
    }

    public void SeekWriteAccess(out bool WriteAccess)
    {
        _sheetMetalDocument.SeekWriteAccess(out WriteAccess);
    }

    public void CreatePreview()
    {
        _sheetMetalDocument.CreatePreview();
    }

    public void SeekReadOnlyAccess(out bool ReadOnlyAccess)
    {
        _sheetMetalDocument.SeekReadOnlyAccess(out ReadOnlyAccess);
    }

    public void ImportStyles2(seStyleTypeConstants StyleType, bool bReplace, object pSrcDocument)
    {
        _sheetMetalDocument.ImportStyles2(StyleType, bReplace, pSrcDocument);
    }

    public void GetRegisteredCustomPropertiesBiDM(out object varPropInfo)
    {
        _sheetMetalDocument.GetRegisteredCustomPropertiesBiDM(out varPropInfo);
    }

    public string SaveAsWithCustomPropertiesBIDM(string FilePath, string DocumentNumber, string Revision, string Title,
        object varPropInfo)
    {
        return _sheetMetalDocument.SaveAsWithCustomPropertiesBIDM(FilePath, DocumentNumber, Revision, Title,
            varPropInfo);
    }

    public string ReviseWithCustomPropertiesBIDM(string FilePath, string Revision, string Title, object varPropInfo)
    {
        return _sheetMetalDocument.ReviseWithCustomPropertiesBIDM(FilePath, Revision, Title, varPropInfo);
    }

    public void SaveAsPRC(string FileName)
    {
        _sheetMetalDocument.SaveAsPRC(FileName);
    }

    public void FreezeAllInterpartLinks()
    {
        _sheetMetalDocument.FreezeAllInterpartLinks();
    }

    public void BreakAllInterpartLinks()
    {
        _sheetMetalDocument.BreakAllInterpartLinks();
    }

    public void ThawAllInterpartLinks()
    {
        _sheetMetalDocument.ThawAllInterpartLinks();
    }

    public void HasInterpartLinks(ref bool pbHasInterpartLinks)
    {
        _sheetMetalDocument.HasInterpartLinks(ref pbHasInterpartLinks);
    }

    public void GetInContextAssemblyNameForInterpartLinks(ref string pbstrAssemblyName)
    {
        _sheetMetalDocument.GetInContextAssemblyNameForInterpartLinks(ref pbstrAssemblyName);
    }

    public object NewWindow(object NewWindowOptions = null, object Environment = null)
    {
        return _sheetMetalDocument.NewWindow(NewWindowOptions, Environment);
    }

    public void ToggleRefPlanesDisplay(bool Display)
    {
        _sheetMetalDocument.ToggleRefPlanesDisplay(Display);
    }

    public void BindKeyToObject(ref Array ReferenceKey, out object Object)
    {
        _sheetMetalDocument.BindKeyToObject(ref ReferenceKey, out Object);
    }

    public void BindKeyToObjectEx(bool TopologyOnly, ref Array ReferenceKey, out object Object)
    {
        _sheetMetalDocument.BindKeyToObjectEx(TopologyOnly, ref ReferenceKey, out Object);
    }

    public object QueryByProperty(PropertyTableConstants QueryType, object TableName = null, object NumProps = null,
        object PropName = null, object PropType = null, object PropVal = null)
    {
        return _sheetMetalDocument.QueryByProperty(QueryType, TableName, NumProps, PropName, PropType, PropVal);
    }

    public void MinimumDistance(object Element1, object Element2, out double Distance, ref Array Point1,
        ref Array Point2)
    {
        _sheetMetalDocument.MinimumDistance(Element1, Element2, out Distance, ref Point1, ref Point2);
    }

    public void Undo(object NumTransactions = null)
    {
        _sheetMetalDocument.Undo(NumTransactions);
    }

    public void Redo(object NumTransactions = null)
    {
        _sheetMetalDocument.Redo(NumTransactions);
    }

    public void MeasureAngle(object Element1, object Element2, out double TrueAngle, out double ApparentAngle,
        object Element3 = null)
    {
        _sheetMetalDocument.MeasureAngle(Element1, Element2, out TrueAngle, out ApparentAngle, Element3);
    }

    public void NormalDistance(object Element1, object Element2, out double TrueDistance, out double ApparentDistance,
        out double DeltaX, out double DeltaY, out double DeltaZ, object CoordinateSystem = null)
    {
        _sheetMetalDocument.NormalDistance(Element1, Element2, out TrueDistance, out ApparentDistance, out DeltaX,
            out DeltaY, out DeltaZ, CoordinateSystem);
    }

    public void GetBaseStyle(PartBaseStylesConstants BaseStyleType, out FaceStyle BaseStyle)
    {
        _sheetMetalDocument.GetBaseStyle(BaseStyleType, out BaseStyle);
    }

    public void SetBaseStyle(PartBaseStylesConstants BaseStyleType, FaceStyle BaseStyle)
    {
        _sheetMetalDocument.SetBaseStyle(BaseStyleType, BaseStyle);
    }

    public void ImportStyles(string FileName, object Overwrite = null)
    {
        _sheetMetalDocument.ImportStyles(FileName, Overwrite);
    }

    public void GetContainerDocumentAndMatrixOfIPADoc(out object ContainerDocument, ref Array Matrix)
    {
        _sheetMetalDocument.GetContainerDocumentAndMatrixOfIPADoc(out ContainerDocument, ref Matrix);
    }

    public void GetUserPhysicalProperties(out double Volume, out double Area, out double Mass,
        out Array CenterOfGravity,
        out Array CenterOfVolume, out Array GlobalMomentsOfInertia, out Array PrincipalMomentsOfInertia,
        out Array PrincipalAxes, out Array RadiiOfGyration)
    {
        _sheetMetalDocument.GetUserPhysicalProperties(out Volume, out Area, out Mass, out CenterOfGravity,
            out CenterOfVolume, out GlobalMomentsOfInertia, out PrincipalMomentsOfInertia, out PrincipalAxes,
            out RadiiOfGyration);
    }

    public void PutUserPhysicalProperties(ref double Volume, ref double Area, ref double Mass,
        ref Array CenterOfGravity,
        ref Array CenterOfVolume, ref Array GlobalMomentsOfInertia, ref Array PrincipalMomentsOfInertia,
        ref Array PrincipalAxes, ref Array RadiiOfGyration)
    {
        _sheetMetalDocument.PutUserPhysicalProperties(ref Volume, ref Area, ref Mass, ref CenterOfGravity,
            ref CenterOfVolume, ref GlobalMomentsOfInertia, ref PrincipalMomentsOfInertia, ref PrincipalAxes,
            ref RadiiOfGyration);
    }

    public void SaveBody(string FileName, object NewDocumentType = null, object ParasolidVersion = null,
        object NumModelsToBeSaved = null, object ModelsToBeSaved = null)
    {
        _sheetMetalDocument.SaveBody(FileName, NewDocumentType, ParasolidVersion, NumModelsToBeSaved, ModelsToBeSaved);
    }

    public void Recompute()
    {
        _sheetMetalDocument.Recompute();
    }

    public void Show(object NumObjects = null, object Objects = null)
    {
        _sheetMetalDocument.Show(NumObjects, Objects);
    }

    public void Hide(object NumObjects = null, object Objects = null)
    {
        _sheetMetalDocument.Hide(NumObjects, Objects);
    }

    public void ShowOnly(object NumObjects = null, object Objects = null)
    {
        _sheetMetalDocument.ShowOnly(NumObjects, Objects);
    }

    public MeasureVariable AddMeasureVariable(MeasureVariableTypeConstants VariableType,
        MeasureVariableValueConstants ValueType,
        object Geom1, object Geom2, object Geom3 = null)
    {
        return _sheetMetalDocument.AddMeasureVariable(VariableType, ValueType, Geom1, Geom2, Geom3);
    }

    public void GetCapturedRelationshipInformation(out Array RelationshipTypes, out Array OffsetTypes,
        out Array Offsets,
        out object Faces)
    {
        _sheetMetalDocument.GetCapturedRelationshipInformation(out RelationshipTypes, out OffsetTypes, out Offsets,
            out Faces);
    }

    public void PlaceFeatureLibrary(string LibName, object RefPlane, double xOrigin, double yOrigin, double Zorigin,
        out Array Features)
    {
        _sheetMetalDocument.PlaceFeatureLibrary(LibName, RefPlane, xOrigin, yOrigin, Zorigin, out Features);
    }

    public void CreateFeatureLibrary(string LibName, int NumberOfFeatures, ref Array Features)
    {
        _sheetMetalDocument.CreateFeatureLibrary(LibName, NumberOfFeatures, ref Features);
    }

    public void GetDefaultCutSizeValues(out double DefaultCutSizeX, out double DefaultCutSizeY)
    {
        _sheetMetalDocument.GetDefaultCutSizeValues(out DefaultCutSizeX, out DefaultCutSizeY);
    }

    public void SetDefaultCutSizeValues(double DefaultCutSizeX, double DefaultCutSizeY)
    {
        _sheetMetalDocument.SetDefaultCutSizeValues(DefaultCutSizeX, DefaultCutSizeY);
    }

    public void ShowParentsAndChildren()
    {
        _sheetMetalDocument.ShowParentsAndChildren();
    }

    public void GoalSeek(string NameTargetVariable, string NameVariableToChange, double dTargetValue,
        double dTimeLimitInSecs,
        int NumIterationsLimit, out double dTimeElapsed, out int NumIterations, out bool TimeLimitExceeded,
        out bool IterationsLimitExceeded)
    {
        _sheetMetalDocument.GoalSeek(NameTargetVariable, NameVariableToChange, dTargetValue, dTimeLimitInSecs,
            NumIterationsLimit, out dTimeElapsed, out NumIterations, out TimeLimitExceeded,
            out IterationsLimitExceeded);
    }

    public object QueryByEntity(object Entity)
    {
        return _sheetMetalDocument.QueryByEntity(Entity);
    }

    public void PMI_ByModelState(out PMI PMIObj, PMIModelStateConstants PMIModelState = 0)
    {
        _sheetMetalDocument.PMI_ByModelState(out PMIObj, PMIModelState);
    }

    public void Separate(int NumberOfFeatures, ref Array Features)
    {
        _sheetMetalDocument.Separate(NumberOfFeatures, ref Features);
    }

    public void Break(int NumberOfFeatures, ref Array Features)
    {
        _sheetMetalDocument.Break(NumberOfFeatures, ref Features);
    }

    public void DeleteEntities(ref Array EntitiesToDelete, out Array EntitiesNotDeleted)
    {
        _sheetMetalDocument.DeleteEntities(ref EntitiesToDelete, out EntitiesNotDeleted);
    }

    public void GetContainerDocumentAndOccurrenceOfIPADoc(out object ContainerDocument, out object IPAOccurrence)
    {
        _sheetMetalDocument.GetContainerDocumentAndOccurrenceOfIPADoc(out ContainerDocument, out IPAOccurrence);
    }

    public void GetTopDocumentAndSubOccurrenceOfIPADoc(out object TopDocument, out object IPASubOccurrence)
    {
        _sheetMetalDocument.GetTopDocumentAndSubOccurrenceOfIPADoc(out TopDocument, out IPASubOccurrence);
    }

    public void TransformToSynchronousSheetmetal(object pRefFace, int nEdgeNum, ref Array EdgesArray,
        object BRType = null, double dBRWidth = 0, double dBRLength = 0, double dBendRadius = 0,
        double dNeutralFactor = 0)
    {
        _sheetMetalDocument.TransformToSynchronousSheetmetal(pRefFace, nEdgeNum, ref EdgesArray, BRType, dBRWidth,
            dBRLength, dBendRadius, dNeutralFactor);
    }

    public void SetLiveRules(LiveRulesConstants LiveRule, bool bMaintain)
    {
        _sheetMetalDocument.SetLiveRules(LiveRule, bMaintain);
    }

    public void GetLiveRules(LiveRulesConstants LiveRule, out bool bMaintain)
    {
        _sheetMetalDocument.GetLiveRules(LiveRule, out bMaintain);
    }

    public void RestoreLiveRules()
    {
        _sheetMetalDocument.RestoreLiveRules();
    }

    public void SuspendLiveRules(bool bSuspend)
    {
        _sheetMetalDocument.SuspendLiveRules(bSuspend);
    }

    public void SuspendPMI(bool bSuspend)
    {
        _sheetMetalDocument.SuspendPMI(bSuspend);
    }

    public void SuspendPersistedRelationships(bool bSuspend)
    {
        _sheetMetalDocument.SuspendPersistedRelationships(bSuspend);
    }

    public void GetMultiBodyPublishMembers(out int NumMembers, out Array Members, out bool AssemblyExist,
        out string AssemblyFileName, out MultiBodyPublishStatusConstants AssemblyStatus)
    {
        _sheetMetalDocument.GetMultiBodyPublishMembers(out NumMembers, out Members, out AssemblyExist,
            out AssemblyFileName, out AssemblyStatus);
    }

    public void SaveMultiBodyPublishMembers(int NumMembers, ref Array Members, bool CreateAssembly, string FileName,
        out MultiBodyPublishStatusConstants AssemblyStatus)
    {
        _sheetMetalDocument.SaveMultiBodyPublishMembers(NumMembers, ref Members, CreateAssembly, FileName,
            out AssemblyStatus);
    }

    public void SaveMultiBodyPublish(bool CreateAssemblyIfNeeded)
    {
        _sheetMetalDocument.SaveMultiBodyPublish(CreateAssemblyIfNeeded);
    }

    public void ActivateReflectivePlane()
    {
        _sheetMetalDocument.ActivateReflectivePlane();
    }

    public void DeActivateReflectivePlane()
    {
        _sheetMetalDocument.DeActivateReflectivePlane();
    }

    public void SetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, bool bStatus, double dDistance)
    {
        _sheetMetalDocument.SetReflectivePlane(ReflectivePlane, bStatus, dDistance);
    }

    public void GetReflectivePlane(ReflectivePlaneConstants ReflectivePlane, out bool bStatus, out double dDistance)
    {
        _sheetMetalDocument.GetReflectivePlane(ReflectivePlane, out bStatus, out dDistance);
    }

    public void SetReflectivePlaneTransparency(bool bStatus, int dTransparency)
    {
        _sheetMetalDocument.SetReflectivePlaneTransparency(bStatus, dTransparency);
    }

    public void GetReflectivePlaneTransparency(out bool bStatus, out int dTransparency)
    {
        _sheetMetalDocument.GetReflectivePlaneTransparency(out bStatus, out dTransparency);
    }

    public void GetNumberOfParentsAndDependents(object pObject, out int NumberOfParents, out int NumberOfDependents)
    {
        _sheetMetalDocument.GetNumberOfParentsAndDependents(pObject, out NumberOfParents, out NumberOfDependents);
    }

    public void GetParentsAndDependents(object pObject, out Array Parents, out Array Dependents)
    {
        _sheetMetalDocument.GetParentsAndDependents(pObject, out Parents, out Dependents);
    }

    public void MeasureDistance(object Element1, object Element2, MeasureDistanceTypeConstants DistanceType,
        out double Distance,
        out double DX, out double DY, out double DZ, ref Array Point1, ref Array Point2)
    {
        _sheetMetalDocument.MeasureDistance(Element1, Element2, DistanceType, out Distance, out DX, out DY, out DZ,
            ref Point1, ref Point2);
    }

    public void MeasureAngleEx(object Element1, object Element2, object Element3, out double Angle1, out double Angle2,
        out double Angle3, out double Angle4)
    {
        _sheetMetalDocument.MeasureAngleEx(Element1, Element2, Element3, out Angle1, out Angle2, out Angle3,
            out Angle4);
    }

    public void InquireElement(object Element, ref Array InPoint, object CoordinateSystem, ref Array Point,
        out double SurfaceArea,
        out double Volume, out double Length)
    {
        _sheetMetalDocument.InquireElement(Element, ref InPoint, CoordinateSystem, ref Point, out SurfaceArea,
            out Volume, out Length);
    }

    public void Get3dPrintInfo(out int iNumberOfTriangles, out int iNumberOfPoints, out int iNumberOfEdges,
        out double dMeshSurfaceArea, out double dMeshVolume, out double dFileSize, out double dExportToleranceValue,
        out double dSurfacePlaneAngTol, Print3DFileType Type = 0)
    {
        _sheetMetalDocument.Get3dPrintInfo(out iNumberOfTriangles, out iNumberOfPoints, out iNumberOfEdges,
            out dMeshSurfaceArea, out dMeshVolume, out dFileSize, out dExportToleranceValue, out dSurfacePlaneAngTol,
            Type);
    }

    public void GetParentsAndChildren(object Object, out int NumParents, ref Array Parents, out int NumChildrens,
        ref Array Childrens)
    {
        _sheetMetalDocument.GetParentsAndChildren(Object, out NumParents, ref Parents, out NumChildrens, ref Childrens);
    }

    public void LoadUOMPreferences(bool UpdateUomGlobals)
    {
        _sheetMetalDocument.LoadUOMPreferences(UpdateUomGlobals);
    }

    public void CopytoPMI(object featureObj, seCopytoPMIConstants PMIType)
    {
        _sheetMetalDocument.CopytoPMI(featureObj, PMIType);
    }

    public object get_AddInsStorage(string StorageName, int grfMode)
    {
        return _sheetMetalDocument.AddInsStorage[StorageName, grfMode];
    }

    public void GetGlobalParameter(SheetMetalGlobalConstants Parameter, out object Value)
    {
        _sheetMetalDocument.GetGlobalParameter(Parameter, out Value);
    }

    public void SetGlobalParameter(SheetMetalGlobalConstants Parameter, object Value)
    {
        _sheetMetalDocument.SetGlobalParameter(Parameter, Value);
    }

    public void MoveToSynchronous(object pFeatureUnk, bool bIgnoreWarnings, bool bExtendSelection,
        out int NumberOfFeaturesCausingError, out Array ErrorMessageArray, out int NumberOfFeaturesCausingWarning,
        out Array WarningMessageArray)
    {
        _sheetMetalDocument.MoveToSynchronous(pFeatureUnk, bIgnoreWarnings, bExtendSelection,
            out NumberOfFeaturesCausingError, out ErrorMessageArray, out NumberOfFeaturesCausingWarning,
            out WarningMessageArray);
    }

    public void ExportDesignCostToCSV(string bstrSEFileName, string bstrCSVFileName, out bool bSuccessful)
    {
        _sheetMetalDocument.ExportDesignCostToCSV(bstrSEFileName, bstrCSVFileName, out bSuccessful);
    }

    public void GetDesignForCostInfo(string bstrSEFileName, out object pvarDesignForCostInfo)
    {
        _sheetMetalDocument.GetDesignForCostInfo(bstrSEFileName, out pvarDesignForCostInfo);
    }
}