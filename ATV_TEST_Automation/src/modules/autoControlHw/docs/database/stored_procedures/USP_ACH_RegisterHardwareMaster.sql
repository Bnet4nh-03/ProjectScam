USE [TestDB]
GO

CREATE PROCEDURE [dbo].[USP_ACH_RegisterHardwareMaster]
    @CustomerID NVARCHAR(50),
    @DeviceID INT = NULL,
    @DeviceCode NVARCHAR(100) = NULL,
    @PackageID INT = NULL,
    @PackageName NVARCHAR(100) = NULL,
    @TesterID INT,
    @TesterName NVARCHAR(100) = NULL,
    @Pitch FLOAT,
    @HandlerRecipe NVARCHAR(255),
    @ApproverBadgeNo NVARCHAR(50),
    @CreatedBy NVARCHAR(100),
    @HardwareJson NVARCHAR(MAX),    
    @AttachmentsJson NVARCHAR(MAX) 
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION
            
            IF (@DeviceID IS NULL OR @DeviceID = 0) AND (@DeviceCode IS NOT NULL AND @DeviceCode <> '')
            BEGIN
                SELECT TOP 1 @DeviceID = DeviceID FROM TestDB.dbo.ACH_Device WHERE DeviceCode = @DeviceCode;
                IF @DeviceID IS NULL
                BEGIN
                    INSERT INTO TestDB.dbo.ACH_Device (DeviceCode, CustomerID) 
                    VALUES (@DeviceCode, TRY_CONVERT(INT, @CustomerID));
                    SET @DeviceID = SCOPE_IDENTITY();
                END
            END

            IF (@PackageID IS NULL OR @PackageID = 0) AND (@PackageName IS NOT NULL AND @PackageName <> '')
            BEGIN
                SELECT TOP 1 @PackageID = PackageID FROM TestDB.dbo.ACH_Package WHERE PackageName = @PackageName;
                IF @PackageID IS NULL
                BEGIN
                    INSERT INTO TestDB.dbo.ACH_Package (PackageName) VALUES (@PackageName);
                    SET @PackageID = SCOPE_IDENTITY();
                END
            END

            IF @DeviceID IS NULL OR @PackageID IS NULL
            BEGIN
                THROW 50001, 'Device or Package information is invalid.', 1;
            END

            DECLARE @NewMasterID INT;
            INSERT INTO TestDB.dbo.ACH_TesterHardwareMaster (
                CustomerID, DeviceID, PackageID, TesterID, TesterName,
                Pitch, HandlerRecipe, ApproverBadgeNo, CreatedBy, 
                CreatedAt, UpdatedAt, DoubleCheckStatus
            )
            VALUES (
                @CustomerID, @DeviceID, @PackageID, @TesterID, @TesterName,
                @Pitch, @HandlerRecipe, @ApproverBadgeNo, @CreatedBy,
                GETDATE(), GETDATE(), 'PENDING'
            );
            
            SET @NewMasterID = SCOPE_IDENTITY();

            INSERT INTO TestDB.dbo.ACH_MasterHardwareMapping (MasterID, HardwareType, HardwareID, HardwareCode, Qty)
            SELECT 
                @NewMasterID,
                JSON_VALUE(value, '$.HardwareType'),
                JSON_VALUE(value, '$.HardwareID'),
                JSON_VALUE(value, '$.HardwareName'),
                1
            FROM OPENJSON(@HardwareJson);

            INSERT INTO TestDB.dbo.ACH_MasterAttachments (MasterID, FileName, FileSize, FileType, FilePath, UploadedAt)
            SELECT 
                @NewMasterID,
                JSON_VALUE(value, '$.FileName'),
                JSON_VALUE(value, '$.FileSize'),
                JSON_VALUE(value, '$.FileType'),
                JSON_VALUE(value, '$.FilePath'),
                GETDATE()
            FROM OPENJSON(@AttachmentsJson);

        COMMIT TRANSACTION
        
        SELECT 0 AS Result, 'Success' AS Message, @NewMasterID AS MasterID;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT 1 AS Result, ERROR_MESSAGE() AS Message, NULL AS MasterID;
    END CATCH
END
GO