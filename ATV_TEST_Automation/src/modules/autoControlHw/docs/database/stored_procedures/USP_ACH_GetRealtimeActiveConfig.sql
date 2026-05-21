USE [TestDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      pt.long
-- Updated date: 2024-05-20 (OPTIMIZED VERSION: Returning ALL matching packages)
-- Description: Lấy cấu hình phần cứng RFID và liệt kê TẤT CẢ các Package khớp từ Matrix.
-- =============================================

alter PROCEDURE [dbo].[USP_ACH_GetRealtimeActiveConfig]
    @TesterNames NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Xác định danh sách máy mục tiêu
    DECLARE @TargetTesters TABLE (testername NVARCHAR(100) PRIMARY KEY);

    INSERT INTO @TargetTesters (testername)
    SELECT DISTINCT UPPER(LTRIM(RTRIM(m.TesterName)))
    FROM TestDB.dbo.ACH_TesterHardwareMaster m
    JOIN TestDB.dbo.ACH_TesterHardwareMatrix ma ON m.MasterID = ma.MasterID
    WHERE 
        m.DoubleCheckStatus = 'REGISTERED'
        AND ma.Status = 'ACTIVE'
        AND (@TesterNames IS NULL OR @TesterNames = '' 
             OR m.TesterName IN (SELECT LTRIM(RTRIM(value)) FROM STRING_SPLIT(@TesterNames, ','))
             OR UPPER(LTRIM(RTRIM(m.TesterName))) IN (SELECT UPPER(LTRIM(RTRIM(value))) FROM STRING_SPLIT(@TesterNames, ',')));

    -- 2. Lấy RFID thô mới nhất
    ;WITH LatestRFID AS
    (
        SELECT 
            t.testername,
            UPPER(LTRIM(RTRIM(ISNULL(r.board, '')))) AS TB_Code,
            ISNULL(r.changekit, '') AS CK_MP_Raw
        FROM @TargetTesters t
        OUTER APPLY 
        (
            SELECT TOP (1) board, changekit
            FROM [CIMitar_Data].[dbo].[RFIDInfo]
            WHERE UPPER(LTRIM(RTRIM(hostnm))) = t.testername
            ORDER BY upttime DESC
        ) r
    ),
    ParsedRFID AS
    (
        SELECT 
            testername,
            TB_Code,
            UPPER(MAX(CASE WHEN s.value LIKE '%CK%' THEN LTRIM(RTRIM(s.value)) END)) AS CK_Code,
            UPPER(MAX(CASE WHEN s.value LIKE '%MP%' THEN LTRIM(RTRIM(s.value)) END)) AS MP_Code
        FROM LatestRFID
        OUTER APPLY STRING_SPLIT(REPLACE(REPLACE(REPLACE(CK_MP_Raw, ',', '/'), ' ', '/'), '\', '/'), '/') s
        GROUP BY testername, TB_Code
    ),
    -- 3. Đối soát: Tìm Package dựa trên MP_Code trong bảng kit [CIMitar_HCC].[dbo].[Hw_Kit]
    Matches AS (
        SELECT 
            r.testername, 
            CASE 
                WHEN k.hclocation IS NULL THEN 'N/A'
                WHEN k.sites = 512 THEN 'NAND' 
                ELSE 'Toggle' 
            END AS PackageName,
            r.TB_Code, 
            r.CK_Code, 
            r.MP_Code
        FROM ParsedRFID r
        LEFT JOIN [CIMitar_HCC].[dbo].[Hw_Kit] k ON r.MP_Code = UPPER(LTRIM(RTRIM(k.hclocation)))
    )
    -- Trả về kết quả cuối cùng (Unpivot TB, CK, MP thành các dòng)
    SELECT 
        testername, 
        PackageName, 
        Hw.Type AS HardwareType, 
        ISNULL(NULLIF(Hw.Code, ''), 'N/A') AS HardwareCode
    FROM Matches
    CROSS APPLY (VALUES ('TB', TB_Code), ('CK', CK_Code), ('MP', MP_Code)) Hw(Type, Code)
END
GO
