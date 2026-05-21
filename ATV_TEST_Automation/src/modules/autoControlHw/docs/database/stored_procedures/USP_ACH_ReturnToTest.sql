USE [TestDB]
GO

CREATE PROCEDURE [dbo].[USP_ACH_ReturnToTest]
    @MasterID INT,
    @MFG_BadgeNo NVARCHAR(50),
    @Comment NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Cập nhật trạng thái về RETURNED để Engineer có thể sửa lại
        UPDATE TestDB.dbo.ACH_TesterHardwareMaster
        SET DoubleCheckStatus = 'RETURNED',
            MFG_BadgeNo = @MFG_BadgeNo,
            MFG_Comment = @Comment,
            UpdatedAt = GETDATE()
        WHERE MasterID = @MasterID;

        IF @@ROWCOUNT = 0
        BEGIN
            SELECT 1 AS Result, 'MasterID not found' AS Message;
            RETURN;
        END

        SELECT 0 AS Result, 'Success' AS Message;

    END TRY
    BEGIN CATCH
        SELECT 1 AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO