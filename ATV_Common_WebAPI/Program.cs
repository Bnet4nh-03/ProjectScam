using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Models;
using ATV_Common_WebAPI.Common.Services;
using ATV_Common_WebAPI.Common.Utilities;
using ATV_Common_WebAPI.Common.Middleware;
using ATV_Common_WebAPI.Endpoints;
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Services;
using ATV_Common_WebAPI.TEST.KIOXIA.Services;
using ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Interfaces;
using ATV_Common_WebAPI.TEST.KIOXIA.Interfaces;
using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Get configuration
var smtpSetting = builder.Configuration.GetSection("SmtpSetting").Get<ATV_Common_WebAPI.Common.Models.AppSettingsModel.SmtpSettingModel>();
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<ATV_Common_WebAPI.Common.Models.LoginModel.JwtSettings>();

// Configure FormOptions to support large file uploads for the /Set endpoint.
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    // Allow unlimited length for individual form values.
    options.ValueLengthLimit = int.MaxValue;
    // Allow unlimited length for the entire multipart body.
    options.MultipartBodyLengthLimit = long.MaxValue;
    // Do not buffer the request body in memory, stream directly to disk.
    options.MemoryBufferThreshold = int.MaxValue;
});

// Initialize database utilities
var dbUtilities = new Dictionary<string, ATV_Common_WebAPI.Common.Utilities.DatabaseUtility>
{
    { "CIMitar", new ATV_Common_WebAPI.Common.Utilities.DatabaseUtility(builder.Configuration.GetConnectionString("CIMitar_DB_Connection")) },
    { "CIMitar_Dev", new ATV_Common_WebAPI.Common.Utilities.DatabaseUtility(builder.Configuration.GetConnectionString("DevDb_30_Connection")) },
    { "HR_Automation_PRD", new ATV_Common_WebAPI.Common.Utilities.DatabaseUtility(builder.Configuration.GetConnectionString("HR_Automation_PRD_Connection")) },
    { "HR_Automation_DEV", new ATV_Common_WebAPI.Common.Utilities.DatabaseUtility(builder.Configuration.GetConnectionString("HR_Automation_DEV_Connection")) }
};

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();

// Auth & CORS
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            ClockSkew = TimeSpan.FromSeconds(jwtSettings.ClockSkewInSeconds),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("kxi", "Content-Disposition");         // Add specific kxi header (Key x IV) for using to decrypt response body
    });
});

// Custom services
builder.Services.Configure<FileServiceSettings>(builder.Configuration.GetSection("FileServiceSettings"));       // Configure FileServiceSettings
builder.Services.Configure<ATV_Common_WebAPI.Common.Middleware.IpBlockingConfig>(builder.Configuration.GetSection("IpBlocking"));
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IAuthService>(
    provider => new ATV_Common_WebAPI.Common.Services.LoginService.AuthService(
        provider.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>(), 
        dbUtilities["CIMitar"], provider.GetRequiredService<ATV_Common_WebAPI.Common.Services.HashService.PasswordHasherBCrypt>()
        )
    );
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IDataService>(new ATV_Common_WebAPI.Common.Services.DataService(dbUtilities));
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.ILoggerService>(
    provider => provider.GetRequiredService<IDataService>() as ATV_Common_WebAPI.Common.Services.DataService);
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Services.HashService.PasswordHasherBCrypt>();
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IEmailService>(new ATV_Common_WebAPI.Common.Services.EmailService(smtpSetting));
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IExcelService>(new ATV_Common_WebAPI.Common.Services.ExcelService());
// Register the new FileService for dependency injection.
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IFileService, ATV_Common_WebAPI.Common.Services.FileService>();
builder.Services.AddSingleton<
    ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Interfaces.ICIMitarAutoUpdateService, 
    ATV_Common_WebAPI.TEST.CIMitar_Auto_Update.Services.CIMitarAutoUpdate
    >();
builder.Services.AddSingleton<ATV_Common_WebAPI.TEST.KIOXIA.Interfaces.IKioxiaService>(
    provider => new ATV_Common_WebAPI.TEST.KIOXIA.Services.GetLotInfoService(dbUtilities["CIMitar"])
    );
builder.Services.AddSingleton<ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Interfaces.IBOMComparisonService>(
    provider => new ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Services.Placement_Compare(
        dbUtilities["CIMitar"])
    );
builder.Services.AddSingleton<ATV_Common_WebAPI.Common.Interfaces.IEncryptionService, ATV_Common_WebAPI.Common.Services.EncryptionService>();
builder.Services.AddSingleton<Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider>();

var app = builder.Build();

// Middleware Pipeline
app.UseMiddleware<ATV_Common_WebAPI.Common.Middleware.BlockIpMiddleware>();
app.UseMiddleware<ATV_Common_WebAPI.Common.Middleware.EncryptionCompressionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

// Developing environment only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAntiforgery();
}

// API Endpoints
app.MapGet("/", () => "ATV Common API")
   .WithName("GetATVCommonWebAPIInfo")
   .WithOpenApi().RequireAuthorization();

app.MapCIMitarEndpoints();
app.MapCommonEndpoints();
app.MapAssyEndpoints();
app.MapTestEndpoints();


app.Run();