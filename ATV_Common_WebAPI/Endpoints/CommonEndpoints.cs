using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Models;
using ATV_Common_WebAPI.Common.Services;
using ATV_Common_WebAPI.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ATV_Common_WebAPI.Endpoints;

public static class CommonEndpoints
{
    public static void MapCommonEndpoints(this IEndpointRouteBuilder app)
    {
        var commonGroupRoute = app.MapGroup("/Common");

        commonGroupRoute.MapPost("/Send_Email", async (ATV_Common_WebAPI.Common.Models.EmailModel.EmailRequestModel request, [FromServices] ATV_Common_WebAPI.Common.Interfaces.IEmailService emailService) =>
        {
            return await emailService.SendEmail(request);
        }).WithName("SendEmail")
        .WithOpenApi();

        commonGroupRoute.MapPost("/Email_EnCo/Send_Email", async (ATV_Common_WebAPI.Common.Models.EmailModel.EmailRequestModel request, [FromServices] ATV_Common_WebAPI.Common.Interfaces.IEmailService emailService) =>
        {
            return await emailService.SendEmail(request);
        }).WithName("SendEmailEnCo")
        .WithOpenApi();

        commonGroupRoute.MapPost("/Login", async ([FromServices] ATV_Common_WebAPI.Common.Interfaces.IAuthService authService, [FromBody] ATV_Common_WebAPI.Common.Models.LoginModel.LoginRequest request) =>
        {
            if (string.IsNullOrEmpty(request.AppInfo?.Trim())) return await authService.Login(request.LdapName, request.UserId, request.Password); 
            return await authService.Login(request.LdapName, request.UserId, request.Password, request.AppInfo);
        }).WithName("Login")
        .WithOpenApi();

        commonGroupRoute.MapPost("/Login/Refresh_Token", async ([FromServices] ATV_Common_WebAPI.Common.Interfaces.IAuthService authService, [FromBody] ATV_Common_WebAPI.Common.Models.LoginModel.RefreshTokenRequest request) =>
        {
            return await authService.RequestGenerateRefreshToken(request);
        }).WithName("LoginRefreshToken")
        .WithOpenApi();

        commonGroupRoute.MapGet("/Get_Client_Info", async (HttpContext context) =>
        {
            return await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
        });

        commonGroupRoute.MapGet("/BCrypt_Hash", ([FromServices] ATV_Common_WebAPI.Common.Services.HashService.PasswordHasherBCrypt passwordHasher, string text) =>
        {
            return passwordHasher.HashPassword(text);
        });

        commonGroupRoute.MapPost("/Data_Method/Get_Request_Validate_Code", async ([FromServices] IDataService dataService) =>
        {
            return await dataService.GetRequestValidateCode();
        });

        commonGroupRoute.MapPost("/Data_Method/DB/Call_SQL_Command", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestSqlCommand sqlCommand) =>
        {
            var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
            if (sqlCommand.LogSave == null || sqlCommand.LogSave == true) await dataService.SetDbCallLog(clientInfo, sqlCommand, null);
            return new { sqlResult = await dataService.CallSqlCommand(sqlCommand) };
        });

        commonGroupRoute.MapPost("/Data_Method/DB/Call_Store_Procedure", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestStoreProcedure sp) =>
        {
            var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
            if (sp.LogSave == null || sp.LogSave == true) await dataService.SetDbCallLog(clientInfo, null, sp);
            return new { spResult = await dataService.CallStoreProcedure(sp) };
        });

        commonGroupRoute.MapPost("/Data_Method/DB/Call_SQL_Command_Get_JsonStr", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestSqlCommand sqlCommand) =>
        {
            var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
            if (sqlCommand.LogSave == null || sqlCommand.LogSave == true) await dataService.SetDbCallLog(clientInfo, sqlCommand, null);
            return Results.Text(await dataService.CallSqlCommandGetJsonString(sqlCommand));
        });

        commonGroupRoute.MapPost("/Data_Method/DB/Call_Store_Procedure_Get_JsonStr", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestStoreProcedure sp) =>
        {
            var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
            if (sp.LogSave == null || sp.LogSave == true) await dataService.SetDbCallLog(clientInfo, null, sp);
            return Results.Text(await dataService.CallStoreProcedureGetJsonString(sp));
        });

        var dbEnCoGroupRoute = commonGroupRoute.MapGroup("/Data_Method/DB_EnCo");

        dbEnCoGroupRoute.MapPost("/Call_SC", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestSC requestSC) =>
        {
            if (requestSC.logSave == null || requestSC.logSave == true)
            {
                var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
                await dataService.SetDbCallLogEnCo(clientInfo, requestSC, null);
            }
            return Results.Ok(await dataService.CallSC(requestSC));
        });

        dbEnCoGroupRoute.MapPost("/Call_SP", async (HttpContext context, [FromServices] IDataService dataService, ATV_Common_WebAPI.Common.Services.DataService.RequestSP requestSP) =>
        {
            if (requestSP.logSave == null || requestSP.logSave == true)
            {
                var clientInfo = await ATV_Common_WebAPI.Common.Utilities.OtherUtility.GetClientInfo(context);
                await dataService.SetDbCallLogEnCo(clientInfo, null, requestSP); 
            }
            return Results.Ok(await dataService.CallSP(requestSP));
        });

        // --- File Method Endpoints --- 

        // Create a new group for file-related endpoints under /Common/File_Method
        var fileGroup = commonGroupRoute.MapGroup("/File_Method");

        /// <summary>
        /// Endpoint to download a file. This endpoint streams the file content directly to the response.
        /// The request body should be an encrypted JSON object: { "filePath": "..." }
        /// The response is a raw file stream and is NOT encrypted by the middleware.
        /// </summary>
        fileGroup.MapPost("/Get", async (HttpContext context, [FromBody] GetFileRequest request, IFileService fileService) =>
        {
            await fileService.HandleGetFileRequestAsync(context, request);
        });

        /// <summary>
        /// Endpoint to upload a file using multipart/form-data.
        /// It expects an encrypted 'Set-File-Info' header and a 'file' part in the body.
        /// The response is an encrypted JSON object confirming the upload details.
        /// </summary>
        fileGroup.MapPost("/Set", [DisableRequestSizeLimit] async (HttpContext context, [FromServices] IFileService fileService) =>
        {
            return Results.Ok(await fileService.HandleSetFileRequestAsync(context));

        }).DisableAntiforgery();    // Antiforgery token validation must be disabled for multipart form - data endpoints that are called from external clients.

        /// <summary>
        /// Endpoint for file system operations like move, copy, delete, and list.
        /// The request and response bodies are encrypted JSON.
        /// </summary>
        fileGroup.MapPost("/File_Ops", async ([FromBody] FileOperationRequest request, [FromServices] IFileService fileService) =>
        {
            // Exceptions are handled by the EncryptionCompressionMiddleware
            return Results.Ok(await fileService.PerformFileOperationAsync(request));
        });
    }
}
