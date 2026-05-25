
using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Interfaces;
using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATV_Common_WebAPI.Endpoints;

public static class AssyEndpoints
{
    public static void MapAssyEndpoints(this IEndpointRouteBuilder app)
    {
        var assyGroupRoute = app.MapGroup("/ASSY");

        assyGroupRoute.MapPost("/Mounter/BOM_List_Checking/Compare_BOM_And_Placement_List", async ([FromServices] IBOMComparisonService bomComparisonService, HttpRequest request) =>
        {
            return await bomComparisonService.CompareBOMPlacement(request);
        }).WithName("CompareBOMAndPlacementList")
        .WithOpenApi();

        assyGroupRoute.MapGet("/Mounter/BOM_List_Checking/Get_Compare_BOM_Placement_Permission", ([FromServices] IBOMComparisonService bomComparisonService, string badgeNo) =>
        {
            return bomComparisonService.GetCompareBOMPlacementPermission(badgeNo);
        }).WithName("GetCompareBOMPlacementPermission")
        .WithOpenApi();

        assyGroupRoute.MapPost("/Mounter/BOM_List_Checking/Set_BOM_List_Checking_Result", ([FromServices] IBOMComparisonService bomComparisonService, BOMListCheckingModel request) =>
        {
            return bomComparisonService.SetBOMListCheckingResult(request);
        }).WithName("SetBOMListCheckingResult")
        .WithOpenApi();

        assyGroupRoute.MapGet("/Mounter/BOM_List_Checking/Get_BOM_List_Checking_Result", ([FromServices] IBOMComparisonService bomComparisonService, string startTime, string endTime) =>
        {
            return bomComparisonService.GetBOMListCheckingResult(startTime, endTime);
        }).WithName("GetBOMListCheckingResult")
        .WithOpenApi();

        assyGroupRoute.MapGet("/Mounter/BOM_List_Checking/Get_BOM_List_Checking_Result_Status", ([FromServices] IBOMComparisonService bomComparisonService, string lot, string? dcc, long? id) =>
        {
            return bomComparisonService.GetBOMListCheckingResultStatus(lot, dcc, id);
        }).WithName("GetBOMListCheckingResultStatus")
        .WithOpenApi();
    }
}
