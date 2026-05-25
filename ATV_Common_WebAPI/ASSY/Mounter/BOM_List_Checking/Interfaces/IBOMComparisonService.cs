using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Interfaces;

public interface IBOMComparisonService
{
    Task<IResult> CompareBOMPlacement(HttpRequest request);
    IResult GetCompareBOMPlacementPermission(string badgeNo);
    IResult SetBOMListCheckingResult(BOMListCheckingModel request);
    IResult GetBOMListCheckingResult(string startTime, string endTime);
    IResult GetBOMListCheckingResultStatus(string lot, string? dcc, long? id = 0);
}
