USE [TestDB]
GO

CREATE PROCEDURE [dbo].[USP_ACH_ProcessDoubleCheck]
    @MasterID INT,
    @Status NVARCHAR(50), -- WAIT REGISTER, REJECTED
    @Comment NVARCHAR(MAX),
    @ApproverBadgeNo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Cập nhật trạng thái và thông tin phê duyệt
        UPDATE TestDB.dbo.ACH_TesterHardwareMaster
        SET DoubleCheckStatus = @Status,
            ApprovalComment = @Comment,
            ApproverBadgeNo = @ApproverBadgeNo,
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