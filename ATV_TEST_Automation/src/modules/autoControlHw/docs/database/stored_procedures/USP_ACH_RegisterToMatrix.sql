USE [TestDB]
GO

CREATE PROCEDURE [dbo].[USP_ACH_RegisterToMatrix]
    @MasterID INT,
    @MFG_BadgeNo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION
            
            -- 1. Cập nhật trạng thái trong bảng Master
            UPDATE TestDB.dbo.ACH_TesterHardwareMaster
            SET DoubleCheckStatus = 'REGISTERED',
                MFG_BadgeNo = @MFG_BadgeNo,
                UpdatedAt = GETDATE()
            WHERE MasterID = @MasterID;

            -- 2. Thêm hoặc cập nhật vào bảng Matrix vận hành
            -- Nếu đã tồn tại MasterID này trong Matrix (re-register), cập nhật lại thông tin
            IF EXISTS (SELECT 1 FROM TestDB.dbo.ACH_TesterHardwareMatrix WHERE MasterID = @MasterID)
            BEGIN
                UPDATE TestDB.dbo.ACH_TesterHardwareMatrix
                SET Status = 'ACTIVE',
                    PublishedBy = @MFG_BadgeNo,
                    PublishedAt = GETDATE()
                WHERE MasterID = @MasterID;
            END
            ELSE
            BEGIN
                INSERT INTO TestDB.dbo.ACH_TesterHardwareMatrix (MasterID, Status, PublishedBy, PublishedAt)
                VALUES (@MasterID, 'ACTIVE', @MFG_BadgeNo, GETDATE());
            END

        COMMIT TRANSACTION
        
        SELECT 0 AS Result, 'Success' AS Message;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT 1 AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO