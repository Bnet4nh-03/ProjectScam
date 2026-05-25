namespace ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Models;

public class CIMitarUploadModel
{
    public required string Changelog { get; set; }
    public required CIMitarFileModel File { get; set; }
}

public class CIMitarFileModel
{
    public required string FileName { get; set; }
    public required string Data { get; set; }  // base64 string
}
