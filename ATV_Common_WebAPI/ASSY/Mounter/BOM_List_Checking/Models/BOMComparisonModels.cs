namespace ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Models;

public class BOMPlacementFileUploadModel
{
    public required string FileName { get; set; }
    public required string FileType { get; set; }
    public required string FileFormat { get; set; }
    public required string FileContentBase64 { get; set; }
}

public class BOMListCheckingModel
{
    public required string Lot { get; set; }
    public required string Dcc { get; set; }
    public required string BomFilename { get; set; }
    public required string PlacementFilename { get; set; }
    public required string BomContent { get; set; }
    public required string PlacementContent { get; set; }
    public required bool ComparisonResult { get; set; }
    public required bool IgnorePcbCompare { get; set; }
    public required string DifferentItems { get; set; }
    public required string BadgeNo { get; set; }
}
