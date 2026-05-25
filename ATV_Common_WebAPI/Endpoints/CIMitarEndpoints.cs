
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Interfaces;
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATV_Common_WebAPI.Endpoints;

public static class CIMitarEndpoints
{
    public static void MapCIMitarEndpoints(this IEndpointRouteBuilder app)
    {
        var cimitarGroupRoute = app.MapGroup("/ATV_CIMitar_Launcher");

        cimitarGroupRoute.MapGet("/check_version", ([FromServices] ICIMitarAutoUpdateService cimitarAutoUpdateService) => {
            return cimitarAutoUpdateService.GetVersion();
        })
        .WithName("GetLatestVersionInfo")
        .WithOpenApi();

        cimitarGroupRoute.MapGet("/check_changelog", ([FromServices] ICIMitarAutoUpdateService cimitarAutoUpdateService) => {
            return cimitarAutoUpdateService.GetChangeLog();
        })
        .WithName("GetLatestChangelog")
        .WithOpenApi();

        cimitarGroupRoute.MapGet("/get_latest_atv_cimitar", ([FromServices] ICIMitarAutoUpdateService cimitarAutoUpdateService) =>
        {
            return cimitarAutoUpdateService.GetLatestATVCIMitar();
        })
        .WithName("GetLatestFile")
        .WithOpenApi();

        app.MapPost("/ATV_CIMitar_Launcher/upload_latest_atv_cimitar", async ([FromServices] ICIMitarAutoUpdateService cimitarAutoUpdateService, CIMitarUploadModel model) =>
        {
            return await cimitarAutoUpdateService.UpdateLatestATVCIMitar(model);
        })
        .WithName("UploadFileLatest")
        .DisableAntiforgery();
    }
}
