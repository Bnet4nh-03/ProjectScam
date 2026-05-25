
using Microsoft.AspNetCore.Mvc;
using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Models;
using ATV_Common_WebAPI.Common.Services;
using ATV_Common_WebAPI.Common.Utilities;
using ATV_Common_WebAPI.TEST.KIOXIA.Interfaces;

namespace ATV_Common_WebAPI.Endpoints;

public static class TestEndpoints
{
    public static void MapTestEndpoints(this IEndpointRouteBuilder app)
    {
        var testGroupRoute = app.MapGroup("/TEST");

        testGroupRoute.MapGet("/KIOXIA/Get_Lot_Info/GetPKGSort_COMBINE_INF", async ([FromServices] IKioxiaService kioxiaService, string lotno) =>
        {
            return Results.Ok(await kioxiaService.GetPKGSort_COMBINE_INF(lotno));
        });
    }
}
