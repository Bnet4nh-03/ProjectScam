-- ==========================================================
-- 1. DANH MỤC GỐC (LOOKUP DATA)
-- ==========================================================

CREATE TABLE TestDB.dbo.ACH_Device (
    DeviceID INT IDENTITY(1,1) PRIMARY KEY,
    DeviceCode NVARCHAR(100) NOT NULL UNIQUE,
    CustomerID INT NOT NULL 
);

CREATE TABLE TestDB.dbo.ACH_Package (
    PackageID INT IDENTITY(1,1) PRIMARY KEY,
    PackageName NVARCHAR(100) NOT NULL UNIQUE
);

-- ==========================================================
-- 2. QUẢN LÝ ĐĂNG KÝ (TRANSACTION DATA)
-- ==========================================================

CREATE TABLE TestDB.dbo.ACH_TesterHardwareMaster (
    MasterID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,                   
    DeviceID INT NOT NULL,                    
    PackageID INT NOT NULL,                   
    TesterID INT NOT NULL,
    TesterName NVARCHAR(100), -- Thêm cột lưu tên máy tại thời điểm đăng ký                    
    Pitch FLOAT,
    HandlerRecipe NVARCHAR(255),

    -- Quy trình Double Check
    DoubleCheckStatus NVARCHAR(50) DEFAULT 'PENDING', 
    ApproverBadgeNo NVARCHAR(50),                      
    ApprovalComment NVARCHAR(MAX),

    -- Quy trình Matrix Registration (MFG)
    MFG_BadgeNo NVARCHAR(50),
    MFG_Comment NVARCHAR(MAX),

    -- Audit Trail
    CreatedBy NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Master_Device FOREIGN KEY (DeviceID) REFERENCES TestDB.dbo.ACH_Device(DeviceID),
    CONSTRAINT FK_Master_Package FOREIGN KEY (PackageID) REFERENCES TestDB.dbo.ACH_Package(PackageID)
);

CREATE TABLE TestDB.dbo.ACH_MasterHardwareMapping (
    MappingID INT IDENTITY(1,1) PRIMARY KEY,
    MasterID INT NOT NULL,
    HardwareType NVARCHAR(50) NOT NULL, -- (64, 13, 74)
    HardwareID NVARCHAR(50), -- ID linh kiện từ hệ thống CIMitar
    HardwareCode NVARCHAR(100) NOT NULL, -- Tên linh kiện tại thời điểm đăng ký (Hardware Name)
    Qty INT DEFAULT 1,
    CONSTRAINT FK_Mapping_Master FOREIGN KEY (MasterID) REFERENCES TestDB.dbo.ACH_TesterHardwareMaster(MasterID)
);

CREATE TABLE TestDB.dbo.ACH_MasterAttachments (
    AttachmentID INT IDENTITY(1,1) PRIMARY KEY,
    MasterID INT NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FileSize NVARCHAR(50),
    FileType NVARCHAR(20),
    FilePath NVARCHAR(MAX) NOT NULL,
    UploadedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Attach_Master FOREIGN KEY (MasterID) REFERENCES TestDB.dbo.ACH_TesterHardwareMaster(MasterID)
);

-- ==========================================================
-- 3. VẬN HÀNH (OPERATIONAL DATA)
-- ==========================================================

CREATE TABLE TestDB.dbo.ACH_TesterHardwareMatrix (
    MatrixID INT IDENTITY(1,1) PRIMARY KEY,
    MasterID INT NOT NULL UNIQUE,
    Status NVARCHAR(50) DEFAULT 'ACTIVE', 
    PublishedBy NVARCHAR(100),
    PublishedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Matrix_Master FOREIGN KEY (MasterID) REFERENCES TestDB.dbo.ACH_TesterHardwareMaster(MasterID)
);
