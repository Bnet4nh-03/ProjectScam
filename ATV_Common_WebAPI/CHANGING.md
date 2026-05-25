# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed

- Refactored the encrypted endpoints (`/Common/Data_Method/DB_EnCo/*`) to use `System.Text.Json` for improved performance and to produce a cleaner JSON response body, avoiding double-escaped strings.
- Simplified the `Base85` encoding utility in `EncryptionService` by removing unnecessary padding logic, making it more robust.

### Fixed

- Corrected the response format of the encrypted endpoints, which was causing client-side parsing issues due to incorrect JSON string escaping.
- Improved error handling in `DataService` to throw exceptions instead of returning error strings, allowing for centralized error management in the middleware.

### Added

- New endpoints for encrypted and compressed database queries:
  - `POST /Common/Data_Method/DB_EnCo/Call_SC`
  - `POST /Common/Data_Method/DB_EnCo/Call_SP`
- `EncryptionCompressionMiddleware` to handle encryption, decryption, compression, and decompression of request and response payloads for the new endpoints.
- `IEncryptionService` and `EncryptionService` to provide encryption and decryption services.
- `test_client.py` to demonstrate how to use the new encrypted endpoints.
- Initial creation of CHANGING.md
- Created `IEmailService` interface.
- Created `IAuthService` interface.
- Created `IExcelService` interface.
- Created `ILoggerService` interface.
- Created `ICIMitarAutoUpdateService` interface.
- Created `IKioxiaService` interface.
- Created `IBOMComparisonService` interface.
- Created `DateTimeConverter.cs` for date/time format conversions.

### Changed

- Switched from Base64 to Z85 encoding for better space efficiency.
- Refactored `Program.cs` to separate endpoint definitions into dedicated files (`CommonEndpoints.cs`, `CIMitarEndpoints.cs`, `AssyEndpoints.cs`, `TestEndpoints.cs`) within a new `Endpoints` folder.
- Refactored `Data_Method.cs`:
    - Extracted data conversion logic into a new `DataConverter.cs` class.
    - Introduced `IDataService` interface for data operations.
    - Implemented dependency injection for `Database_Utility` instances instead of using a static dictionary.
    - Implemented `ILoggerService` interface.
- Updated `Program.cs` to register `IDataService` and `Data_Method` with the DI container.
- Updated `CommonEndpoints.cs` to use `IDataService` via dependency injection.
- Updated `README.md` to include detailed documentation on the architectural refactoring, including key changes, conceptual overview, and benefits.
- Refactored `Email_Method.cs`:
    - Implemented `IEmailService` interface.
    - Made methods non-static and injected `AppSettings_Model.SmtpSettingModel` via constructor.
- Refactored `Login_Method.cs` (`AuthService`):
    - Implemented `IAuthService` interface.
    - Injected `Database_Utility` into `AuthService`'s constructor.
    - Made `GetUserInfoFromDb` and `SetUserInfoToDb` non-static and part of `AuthService`.
- Refactored `Excel_Method.cs`:
    - Implemented `IExcelService` interface.
    - Made methods non-static.
- Refactored `Hash_Method.cs`:
    - Made `PasswordHasherBCrypt` non-static.
    - Injected `ILoggerService` into `PasswordHasherBCrypt`'s constructor.
- Refactored `CIMitarAutoUpdate.cs`:
    - Implemented `ICIMitarAutoUpdateService` interface.
    - Made methods non-static and injected `IWebHostEnvironment`.
- Refactored `Get_Lot_Info.cs`:
    - Implemented `IKioxiaService` interface.
    - Made methods non-static and injected `Database_Utility`.
- Refactored `Placement_Compare.cs`:
    - Implemented `IBOMComparisonService` interface.
    - Made methods non-static and injected `Database_Utility`.
- Updated `Program.cs` to register `IEmailService`, `IAuthService`, `IExcelService`, `ILoggerService`, `Hash_Method.PasswordHasherBCrypt`, `ICIMitarAutoUpdateService`, `IKioxiaService`, and `IBOMComparisonService` with the DI container.
- Updated `CommonEndpoints.cs` to inject `IEmailService`, `IAuthService`, and `Hash_Method.PasswordHasherBCrypt`.
- Updated `CIMitarEndpoints.cs` to inject `ICIMitarAutoUpdateService`.
- Updated `TestEndpoints.cs` to inject `IKioxiaService`.
- Updated `AssyEndpoints.cs` to inject `IBOMComparisonService`.

### Fixed
- Corrected `Placement_Compare.cs` to use `DateTimeConverter.ConvertToDateTimeFormat` and removed the local `ConvertToDateTimeFormat` method.
- Corrected `Data_Method.cs`:
    - Renamed `functioName` parameter to `functionName` in `SetCommonApiLog` method and its call.
    - Fixed `public public` syntax error in `SetCommonApiLog` method signature.
    - Renamed `SetCommonApiLog` to `Log` to correctly implement `ILoggerService.Log`.
    - Removed `SetCommonApiLog` from `IDataService` interface as it belongs to `ILoggerService`.
- Corrected `Login_Method.cs`:
    - Injected `Hash_Method.PasswordHasherBCrypt` into `AuthService` constructor.
    - Updated calls to `HashPassword` and `VerifyPassword` to use the injected `_passwordHasher` instance.
    - Corrected return type of `RequestGenerateRefreshToken` to `Task<Login_Method.RefreshTokenResponse>` to match `IAuthService`.
    - Implemented cross-platform LDAP authentication using `Novell.Directory.Ldap.NETStandard`.
- Corrected `Program.cs`:
    - Added missing `using` directives for new namespaces.
    - Corrected `MapTestEndpoints` call to remove `dbUtilities` parameter.
    - Updated `AuthService` service registration to pass `Hash_Method.PasswordHasherBCrypt` to its constructor.
    - Updated `Database_Utility` references to use fully qualified names.
    - Corrected `Excel_Method` service registration.
    - Corrected `CIMitarAutoUpdate` service registration.
    - Corrected `IKioxiaService` service registration.
    - Corrected `ILoggerService` service registration order.
    - Corrected `IEmailService` service registration.
    - Corrected `Hash_Method.PasswordHasherBCrypt` service registration.
    - Corrected `IBOMComparisonService` service registration.
- Corrected `CIMitarEndpoints.cs`:
    - Added missing `using Microsoft.AspNetCore.Mvc;` directive.
    - Updated `CIMitarUploadModel` reference to use fully qualified name.
- Corrected `AssyEndpoints.cs`:
    - Added missing `using Microsoft.AspNetCore.Mvc;` directive.
    - Updated `BOMListCheckingModel` reference to use fully qualified name.
- Corrected `TestEndpoints.cs`:
    - Added missing `using Microsoft.AspNetCore.Mvc;` directive.
    - Added missing `using ATV_Common_WebAPI.TEST.KIOXIA;` directive.

### Refactoring (Project Structure)
- Created new subdirectories: `Common/Interfaces`, `Common/Models`, `Common/Services`, `Common/Utilities`, `ASSY/Mounter/BOM_List_Checking/Interfaces`, `ASSY/Mounter/BOM_List_Checking/Models`, `ASSY/Mounter/BOM_List_Checking/Services`, `TEST/CIMitar_Auto_Update/Interfaces`, `TEST/CIMitar_Auto_Update/Models`, `TEST/CIMitar_Auto_Update/Services`, `TEST/KIOXIA/Interfaces`, `TEST/KIOXIA/Services`.
- Moved files to their respective new subdirectories:
    - `Common/AppSettings_Model.cs` -> `Common/Models/AppSettings_Model.cs`
    - `Common/Data_Method.cs` -> `Common/Services/Data_Method.cs`
    - `Common/Database_Utility.cs` -> `Common/Utilities/Database_Utility.cs`
    - `Common/Directory_Method.cs` -> `Common/Utilities/Directory_Method.cs`
    - `Common/Email_Method.cs` -> `Common/Services/Email_Method.cs`
    - `Common/Excel_Method.cs` -> `Common/Services/Excel_Method.cs`
    - `Common/Hash_Method.cs` -> `Common/Services/Hash_Method.cs`
    - `Common/Login_Method.cs` -> `Common/Services/Login_Method.cs`
    - `Common/Other_Method.cs` -> `Common/Utilities/Other_Method.cs`
    - `Common/DataConverter.cs` -> `Common/Utilities/DataConverter.cs`
    - `Common/DateTimeConverter.cs` -> `Common/Utilities/DateTimeConverter.cs`
    - `Common/IEmailService.cs` -> `Common/Interfaces/IEmailService.cs`
    - `Common/IAuthService.cs` -> `Common/Interfaces/IAuthService.cs`
    - `Common/IExcelService.cs` -> `Common/Interfaces/IExcelService.cs`
    - `Common/ILoggerService.cs` -> `Common/Interfaces/ILoggerService.cs`
    - `ASSY/Mounter/BOM_List_Checking/IBOMComparisonService.cs` -> `ASSY/Mounter/BOM_List_Checking/Interfaces/IBOMComparisonService.cs`
    - `ASSY/Mounter/BOM_List_Checking/Placement_Compare.cs` -> `ASSY/Mounter/BOM_List_Checking/Services/Placement_Compare.cs`
    - Extracted `BOMPlacementFileUploadModel` and `BOMListCheckingModel` from `Placement_Compare.cs` to `ASSY/Mounter/BOM_List_Checking/Models/BOMComparisonModels.cs`.
    - `TEST/CIMitar_Auto_Update/ICIMitarAutoUpdateService.cs` -> `TEST/CIMitar_Auto_Update/Interfaces/ICIMitarAutoUpdateService.cs`
    - `TEST/CIMitar_Auto_Update/CIMitarAutoUpdate.cs` -> `TEST/CIMitar_Auto_Update/Services/CIMitarAutoUpdate.cs`
    - Extracted `CIMitarUploadModel` and `CIMitarFileModel` from `CIMitarAutoUpdate.cs` to `TEST/CIMitar_Auto_Update/Models/CIMitarModels.cs`.
    - `TEST/KIOXIA/IKioxiaService.cs` -> `TEST/KIOXIA/Interfaces/IKioxiaService.cs`
    - `TEST/KIOXIA/Get_Lot_Info.cs` -> `TEST/KIOXIA/Services/Get_Lot_Info.cs`
- Updated namespaces in all moved files to reflect the new directory structure.
- Updated `using` directives in all files that reference moved types.
- Adjusted service registrations in `Program.cs` and endpoint mappings in the `Endpoints` folder to reflect the new namespaces and service implementations.

### Warnings Addressed
- Addressed `CS8618`, `CS8601`, `CS8602`, `CS8603`, `CS8604`, `CS8619`, `CS8600` (nullable reference type warnings) by adding null checks or using the null-forgiving operator (`!`) where appropriate.
- Addressed `CS7022` warning by suppressing it in `TestRequestSqlByApi.cs`.
- Addressed `CS1998` warning by ensuring `await` is used with `async` methods.
- Addressed `CA1416` (Windows-specific API) warnings by replacing `System.DirectoryServices` with `System.DirectoryServices.Protocols` in `LoginService.cs`.
