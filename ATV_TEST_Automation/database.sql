-- =================================================================================
-- T-SQL Schema for Checksheet Application
-- Database: SQL Server
-- Designed by: Gemini
-- Version: 1.2 (Added Demo Data)
-- Date: 2025-08-14
-- =================================================================================

-- Create the database if it does not already exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ATV_CHECK_SHEET')
BEGIN
    CREATE DATABASE ATV_CHECK_SHEET;
    PRINT 'Database ATV_CHECK_SHEET created successfully.';
END
GO

-- Switch to the context of the newly created database
USE ATV_CHECK_SHEET;
GO

-- =================================================================================
-- Drop existing tables in reverse order of dependency to avoid foreign key conflicts
-- =================================================================================
IF OBJECT_ID('dbo.AppLogs', 'U') IS NOT NULL DROP TABLE dbo.AppLogs;
IF OBJECT_ID('dbo.CheckResultDetails', 'U') IS NOT NULL DROP TABLE dbo.CheckResultDetails;
IF OBJECT_ID('dbo.CheckResults', 'U') IS NOT NULL DROP TABLE dbo.CheckResults;
IF OBJECT_ID('dbo.ChecklistItems', 'U') IS NOT NULL DROP TABLE dbo.ChecklistItems;
IF OBJECT_ID('dbo.ChecklistTemplates', 'U') IS NOT NULL DROP TABLE dbo.ChecklistTemplates;
IF OBJECT_ID('dbo.Devices', 'U') IS NOT NULL DROP TABLE dbo.Devices;
IF OBJECT_ID('dbo.DeviceTypes', 'U') IS NOT NULL DROP TABLE dbo.DeviceTypes;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID('dbo.Floors', 'U') IS NOT NULL DROP TABLE dbo.Floors;
IF OBJECT_ID('dbo.Buildings', 'U') IS NOT NULL DROP TABLE dbo.Buildings;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
IF OBJECT_ID('dbo.Sites', 'U') IS NOT NULL DROP TABLE dbo.Sites;
GO

-- =================================================================================
-- Group 1: Core Master Data (Organization, Location, Users)
-- =================================================================================

CREATE TABLE dbo.Sites (
    SiteID INT IDENTITY(1,1) PRIMARY KEY,
    SiteName NVARCHAR(100) NOT NULL UNIQUE,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(3) NULL
);
GO

CREATE TABLE dbo.Departments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    SiteID INT NOT NULL,
    DepartmentName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(3) NULL,
    CONSTRAINT FK_Departments_SiteID FOREIGN KEY (SiteID) REFERENCES dbo.Sites(SiteID) ON DELETE CASCADE
);
GO
CREATE INDEX IX_Departments_SiteID ON dbo.Departments(SiteID);
GO

CREATE TABLE dbo.Buildings (
    BuildingID INT IDENTITY(1,1) PRIMARY KEY,
    SiteID INT NOT NULL,
    BuildingName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(3) NULL,
    CONSTRAINT FK_Buildings_SiteID FOREIGN KEY (SiteID) REFERENCES dbo.Sites(SiteID) ON DELETE CASCADE
);
GO
CREATE INDEX IX_Buildings_SiteID ON dbo.Buildings(SiteID);
GO

CREATE TABLE dbo.Floors (
    FloorID INT IDENTITY(1,1) PRIMARY KEY,
    BuildingID INT NOT NULL,
    FloorName NVARCHAR(100) NOT NULL, -- e.g., '1F', '2F', 'Basement'
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(3) NULL,
    CONSTRAINT FK_Floors_BuildingID FOREIGN KEY (BuildingID) REFERENCES dbo.Buildings(BuildingID) ON DELETE CASCADE
);
GO
CREATE INDEX IX_Floors_BuildingID ON dbo.Floors(BuildingID);
GO

CREATE TABLE dbo.Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL, -- Store a hashed password, not plain text
    FullName NVARCHAR(150) NOT NULL,
    DepartmentID INT NULL,
    UserRole NVARCHAR(50) NOT NULL, -- e.g., 'Admin', 'Inspector', 'Manager'
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    LastLogin DATETIME2(3) NULL,
    CONSTRAINT FK_Users_DepartmentID FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID) ON DELETE SET NULL
);
GO
CREATE INDEX IX_Users_DepartmentID ON dbo.Users(DepartmentID);
GO

-- =================================================================================
-- Group 2: Device & Checklist Management
-- =================================================================================

CREATE TABLE dbo.DeviceTypes (
    DeviceTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(100) NOT NULL UNIQUE,
    TypeDescription NVARCHAR(500) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.Devices (
    DeviceID BIGINT IDENTITY(1,1) PRIMARY KEY,
    DeviceCode NVARCHAR(50) NOT NULL UNIQUE,
    DeviceName NVARCHAR(150) NOT NULL,
    DeviceTypeID INT NOT NULL,
    DepartmentID INT NOT NULL,
    BuildingID INT NOT NULL,
    FloorID INT NOT NULL,
    LocationDescription NVARCHAR(500) NULL,
    QRCode NVARCHAR(255) NOT NULL UNIQUE,
    CheckCycleDays INT NOT NULL DEFAULT 30,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2(3) NULL,
    CONSTRAINT FK_Devices_DeviceTypeID FOREIGN KEY (DeviceTypeID) REFERENCES dbo.DeviceTypes(DeviceTypeID) ON DELETE NO ACTION,
    CONSTRAINT FK_Devices_DepartmentID FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID) ON DELETE NO ACTION,
    CONSTRAINT FK_Devices_BuildingID FOREIGN KEY (BuildingID) REFERENCES dbo.Buildings(BuildingID) ON DELETE NO ACTION,
    CONSTRAINT FK_Devices_FloorID FOREIGN KEY (FloorID) REFERENCES dbo.Floors(FloorID) ON DELETE NO ACTION
);
GO
CREATE INDEX IX_Devices_DeviceTypeID ON dbo.Devices(DeviceTypeID);
CREATE INDEX IX_Devices_DepartmentID ON dbo.Devices(DepartmentID);
CREATE INDEX IX_Devices_Location ON dbo.Devices(BuildingID, FloorID);
GO

CREATE TABLE dbo.ChecklistTemplates (
    TemplateID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceTypeID INT NOT NULL,
    TemplateName NVARCHAR(150) NOT NULL,
    Version INT NOT NULL DEFAULT 1,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT UQ_ChecklistTemplates_DeviceType_Version UNIQUE (DeviceTypeID, Version),
    CONSTRAINT FK_ChecklistTemplates_DeviceTypeID FOREIGN KEY (DeviceTypeID) REFERENCES dbo.DeviceTypes(DeviceTypeID) ON DELETE CASCADE
);
GO

CREATE TABLE dbo.ChecklistItems (
    ItemID INT IDENTITY(1,1) PRIMARY KEY,
    TemplateID INT NOT NULL,
    ItemText NVARCHAR(500) NOT NULL,
    ItemOrder INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_ChecklistItems_TemplateID FOREIGN KEY (TemplateID) REFERENCES dbo.ChecklistTemplates(TemplateID) ON DELETE CASCADE
);
GO
CREATE INDEX IX_ChecklistItems_TemplateID ON dbo.ChecklistItems(TemplateID);
GO

-- =================================================================================
-- Group 3: Checklist Transaction Data
-- =================================================================================

CREATE TABLE dbo.CheckResults (
    CheckResultID BIGINT IDENTITY(1,1) PRIMARY KEY,
    DeviceID BIGINT NOT NULL,
    UserID INT NOT NULL,
    TemplateID INT NOT NULL,
    CheckTimestamp DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    DueDate AS (DATEADD(day, CheckCycleDays, CAST(CheckTimestamp AS DATE))),
    OverallStatus NVARCHAR(20) NOT NULL,
    CheckCycleDays INT NOT NULL,
    IsEditable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CheckResults_DeviceID FOREIGN KEY (DeviceID) REFERENCES dbo.Devices(DeviceID) ON DELETE CASCADE,
    CONSTRAINT FK_CheckResults_UserID FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID) ON DELETE NO ACTION,
    CONSTRAINT FK_CheckResults_TemplateID FOREIGN KEY (TemplateID) REFERENCES dbo.ChecklistTemplates(TemplateID) ON DELETE NO ACTION
);
GO
CREATE INDEX IX_CheckResults_DeviceID ON dbo.CheckResults(DeviceID);
CREATE INDEX IX_CheckResults_Timestamp ON dbo.CheckResults(CheckTimestamp);
GO

CREATE TABLE dbo.CheckResultDetails (
    CheckResultDetailID BIGINT IDENTITY(1,1) PRIMARY KEY,
    CheckResultID BIGINT NOT NULL,
    ItemID INT NOT NULL,
    Status NVARCHAR(10) NOT NULL,
    NG_Reason NVARCHAR(1000) NULL,
    NG_ImagePath NVARCHAR(1024) NULL,
    CONSTRAINT FK_CheckResultDetails_CheckResultID FOREIGN KEY (CheckResultID) REFERENCES dbo.CheckResults(CheckResultID) ON DELETE CASCADE,
    CONSTRAINT FK_CheckResultDetails_ItemID FOREIGN KEY (ItemID) REFERENCES dbo.ChecklistItems(ItemID) ON DELETE NO ACTION
);
GO
CREATE INDEX IX_CheckResultDetails_CheckResultID ON dbo.CheckResultDetails(CheckResultID);
GO

-- =================================================================================
-- Group 4: Auditing & Logging
-- =================================================================================

CREATE TABLE dbo.AppLogs (
    LogID BIGINT IDENTITY(1,1) PRIMARY KEY,
    LogTimestamp DATETIME2(3) NOT NULL DEFAULT GETUTCDATE(),
    LogLevel NVARCHAR(20) NOT NULL,
    Source NVARCHAR(255) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    UserID INT NULL,
    Exception NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AppLogs_UserID FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID) ON DELETE SET NULL
);
GO
CREATE INDEX IX_AppLogs_Timestamp ON dbo.AppLogs(LogTimestamp DESC);
CREATE INDEX IX_AppLogs_Level ON dbo.AppLogs(LogLevel);
GO

PRINT 'Database schema created successfully.';
GO

-- =================================================================================
-- DEMO DATA INSERTION
-- =================================================================================
BEGIN TRANSACTION;

BEGIN TRY
    -- Declare variables to hold IDs
    DECLARE @SiteA_ID INT, @DeptSafety_ID INT, @DeptFacility_ID INT;
    DECLARE @Building1_ID INT, @Building2_ID INT;
    DECLARE @Floor1_ID INT, @Floor2_ID INT, @Floor3_ID INT;
    DECLARE @AdminUser_ID INT, @InspectorUser_ID INT;
    DECLARE @DeviceTypeFEX_ID INT, @DeviceTypeFAK_ID INT, @DeviceTypeAED_ID INT;
    DECLARE @TemplateFEX_ID INT, @TemplateFAK_ID INT, @TemplateAED_ID INT;
    DECLARE @Item1_ID INT, @Item2_ID INT, @Item3_ID INT, @Item4_ID INT, @Item5_ID INT;
    DECLARE @Device1_ID BIGINT, @Device2_ID BIGINT, @Device3_ID BIGINT, @Device4_ID BIGINT, @Device5_ID BIGINT;
    DECLARE @CheckResult1_ID BIGINT, @CheckResult2_ID BIGINT;

    -- 1. Master Data
    INSERT INTO dbo.Sites (SiteName) VALUES ('Amkor Technology Vietnam');
    SET @SiteA_ID = SCOPE_IDENTITY();

    INSERT INTO dbo.Departments (SiteID, DepartmentName) VALUES (@SiteA_ID, 'Safety'), (@SiteA_ID, 'Facility');
    SELECT @DeptSafety_ID = DepartmentID FROM dbo.Departments WHERE DepartmentName = 'Safety';
    SELECT @DeptFacility_ID = DepartmentID FROM dbo.Departments WHERE DepartmentName = 'Facility';

    INSERT INTO dbo.Buildings (SiteID, BuildingName) VALUES (@SiteA_ID, 'Building 1'), (@SiteA_ID, 'Building 2');
    SELECT @Building1_ID = BuildingID FROM dbo.Buildings WHERE BuildingName = 'Building 1';
    SELECT @Building2_ID = BuildingID FROM dbo.Buildings WHERE BuildingName = 'Building 2';

    INSERT INTO dbo.Floors (BuildingID, FloorName) VALUES (@Building1_ID, '1F'), (@Building1_ID, '2F'), (@Building2_ID, '1F');
    SELECT @Floor1_ID = FloorID FROM dbo.Floors WHERE BuildingID = @Building1_ID AND FloorName = '1F';
    SELECT @Floor2_ID = FloorID FROM dbo.Floors WHERE BuildingID = @Building1_ID AND FloorName = '2F';
    SELECT @Floor3_ID = FloorID FROM dbo.Floors WHERE BuildingID = @Building2_ID AND FloorName = '1F';

    -- NOTE: In a real application, use a strong hashing algorithm like BCrypt or Argon2.
    INSERT INTO dbo.Users (Username, PasswordHash, FullName, DepartmentID, UserRole) VALUES 
    ('admin', 'AQAAAAEAACcQAAAAE... (this is a placeholder)', 'Admin User', @DeptSafety_ID, 'Admin'),
    ('inspector01', 'AQAAAAEAACcQAAAAE... (this is a placeholder)', 'John Doe', @DeptSafety_ID, 'Inspector');
    SELECT @AdminUser_ID = UserID FROM dbo.Users WHERE Username = 'admin';
    SELECT @InspectorUser_ID = UserID FROM dbo.Users WHERE Username = 'inspector01';

    -- 2. Device & Checklist Management
    INSERT INTO dbo.DeviceTypes (TypeName, TypeDescription) VALUES 
    ('Fire Extinguisher', 'Portable fire extinguisher'),
    ('First Aid Kit', 'First aid box for emergencies'),
    ('AED', 'Automated External Defibrillator');
    SELECT @DeviceTypeFEX_ID = DeviceTypeID FROM dbo.DeviceTypes WHERE TypeName = 'Fire Extinguisher';
    SELECT @DeviceTypeFAK_ID = DeviceTypeID FROM dbo.DeviceTypes WHERE TypeName = 'First Aid Kit';
    SELECT @DeviceTypeAED_ID = DeviceTypeID FROM dbo.DeviceTypes WHERE TypeName = 'AED';

    INSERT INTO dbo.Devices (DeviceCode, DeviceName, DeviceTypeID, DepartmentID, BuildingID, FloorID, LocationDescription, QRCode) VALUES
    ('FEX-001', 'Bình chữa cháy bột ABC', @DeviceTypeFEX_ID, @DeptSafety_ID, @Building1_ID, @Floor1_ID, 'Cạnh cửa thoát hiểm A', 'QR-FEX-001'),
    ('FEX-002', 'Bình chữa cháy CO2', @DeviceTypeFEX_ID, @DeptSafety_ID, @Building1_ID, @Floor2_ID, 'Hành lang khu văn phòng', 'QR-FEX-002'),
    ('FAK-001', 'Tủ cứu thương', @DeviceTypeFAK_ID, @DeptSafety_ID, @Building1_ID, @Floor1_ID, 'Phòng y tế', 'QR-FAK-001'),
    ('AED-001', 'Máy khử rung tim', @DeviceTypeAED_ID, @DeptSafety_ID, @Building2_ID, @Floor1_ID, 'Lối vào chính', 'QR-AED-001'),
    ('FEX-003', 'Bình chữa cháy bột ABC', @DeviceTypeFEX_ID, @DeptFacility_ID, @Building2_ID, @Floor1_ID, 'Xưởng sản xuất khu B', 'QR-FEX-003');
    SELECT @Device1_ID = DeviceID FROM dbo.Devices WHERE DeviceCode = 'FEX-001';
    SELECT @Device2_ID = DeviceID FROM dbo.Devices WHERE DeviceCode = 'FEX-002';
    SELECT @Device3_ID = DeviceID FROM dbo.Devices WHERE DeviceCode = 'FAK-001';

    -- Checklist Template for Fire Extinguisher
    INSERT INTO dbo.ChecklistTemplates (DeviceTypeID, TemplateName, Version, IsActive) VALUES (@DeviceTypeFEX_ID, 'Kiểm tra bình chữa cháy v1', 1, 1);
    SET @TemplateFEX_ID = SCOPE_IDENTITY();
    INSERT INTO dbo.ChecklistItems (TemplateID, ItemText, ItemOrder) VALUES 
    (@TemplateFEX_ID, 'Niêm phong còn nguyên vẹn?', 1),
    (@TemplateFEX_ID, 'Đồng hồ áp suất ở vạch xanh?', 2),
    (@TemplateFEX_ID, 'Vỏ bình có bị gỉ sét, hư hỏng?', 3),
    (@TemplateFEX_ID, 'Vòi phun có bị nứt, tắc nghẽn?', 4);

    -- Checklist Template for First Aid Kit
    INSERT INTO dbo.ChecklistTemplates (DeviceTypeID, TemplateName, Version, IsActive) VALUES (@DeviceTypeFAK_ID, 'Kiểm tra tủ cứu thương v1', 1, 1);
    SET @TemplateFAK_ID = SCOPE_IDENTITY();
    INSERT INTO dbo.ChecklistItems (TemplateID, ItemText, ItemOrder) VALUES 
    (@TemplateFAK_ID, 'Còn đủ gạc, băng keo?', 1),
    (@TemplateFAK_ID, 'Thuốc sát trùng còn hạn sử dụng?', 2),
    (@TemplateFAK_ID, 'Vỏ hộp có sạch sẽ, nguyên vẹn?', 3);

    -- 3. Transaction Data (Check Results)
    -- Check Result 1: FEX-001 is OK
    INSERT INTO dbo.CheckResults (DeviceID, UserID, TemplateID, CheckTimestamp, OverallStatus, CheckCycleDays) VALUES
    (@Device1_ID, @InspectorUser_ID, @TemplateFEX_ID, DATEADD(day, -30, GETUTCDATE()), 'OK', 30);
    SET @CheckResult1_ID = SCOPE_IDENTITY();
    
    SELECT @Item1_ID = ItemID FROM dbo.ChecklistItems WHERE TemplateID = @TemplateFEX_ID AND ItemOrder = 1;
    SELECT @Item2_ID = ItemID FROM dbo.ChecklistItems WHERE TemplateID = @TemplateFEX_ID AND ItemOrder = 2;
    SELECT @Item3_ID = ItemID FROM dbo.ChecklistItems WHERE TemplateID = @TemplateFEX_ID AND ItemOrder = 3;
    SELECT @Item4_ID = ItemID FROM dbo.ChecklistItems WHERE TemplateID = @TemplateFEX_ID AND ItemOrder = 4;

    INSERT INTO dbo.CheckResultDetails (CheckResultID, ItemID, Status) VALUES
    (@CheckResult1_ID, @Item1_ID, 'OK'),
    (@CheckResult1_ID, @Item2_ID, 'OK'),
    (@CheckResult1_ID, @Item3_ID, 'OK'),
    (@CheckResult1_ID, @Item4_ID, 'OK');

    -- Check Result 2: FEX-002 is NG
    INSERT INTO dbo.CheckResults (DeviceID, UserID, TemplateID, CheckTimestamp, OverallStatus, CheckCycleDays) VALUES
    (@Device2_ID, @InspectorUser_ID, @TemplateFEX_ID, DATEADD(day, -15, GETUTCDATE()), 'NG', 30);
    SET @CheckResult2_ID = SCOPE_IDENTITY();

    INSERT INTO dbo.CheckResultDetails (CheckResultID, ItemID, Status, NG_Reason, NG_ImagePath) VALUES
    (@CheckResult2_ID, @Item1_ID, 'OK', NULL, NULL),
    (@CheckResult2_ID, @Item2_ID, 'NG', 'Đồng hồ đã tụt xuống vạch đỏ.', '/images/ng/fex002_20250730.jpg'),
    (@CheckResult2_ID, @Item3_ID, 'OK', NULL, NULL),
    (@CheckResult2_ID, @Item4_ID, 'OK', NULL, NULL);

    PRINT 'Demo data inserted successfully.';
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    -- Raiserror will pass the error up to the client.
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorState INT = ERROR_STATE();

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    PRINT 'An error occurred, transaction rolled back.';
END CATCH;
GO

PRINT 'Script finished.';
GO
