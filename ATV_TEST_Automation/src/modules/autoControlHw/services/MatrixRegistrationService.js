export default class MatrixRegistrationService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    /**
     * Lấy danh sách các yêu cầu đã được APPROVED nhưng chưa đăng ký vào Matrix
     */
    async getListApproved() {
        const strQuery = `
            SELECT 
                m.MasterID as id,
                c.customername as customer,
                d.DeviceCode as device,
                p.PackageName as package,
                t.testername as tester,
                m.Pitch as pitch,
                m.HandlerRecipe as recipe,
                FORMAT(m.UpdatedAt, 'yyyy-MM-dd HH:mm') as date,
                t.testername as platform,
                CASE WHEN m.Pitch < 0.4 THEN 'High Precision' ELSE 'Standard' END as level,
                u.username as requester,
                m.DoubleCheckStatus as status,
                ua.username as approverName,
                m.ApprovalComment as approvalComment
            FROM TestDB.dbo.ACH_TesterHardwareMaster m
            JOIN [CIMitar_Master].[dbo].[Customer] c ON m.CustomerID = c.customercode
            JOIN TestDB.dbo.ACH_Device d ON m.DeviceID = d.DeviceID
            JOIN TestDB.dbo.ACH_Package p ON m.PackageID = p.PackageID
            JOIN [CIMitar_Master].[dbo].[Tester] t ON m.TesterID = t.testerid
            LEFT JOIN [ATV_Common].[dbo].[Common_API_User] u ON m.CreatedBy = CAST(u.badgeno AS NVARCHAR)
            LEFT JOIN [ATV_Common].[dbo].[Common_API_User] ua ON m.ApproverBadgeNo = CAST(ua.badgeno AS NVARCHAR)
            WHERE m.DoubleCheckStatus = 'WAIT REGISTER'
            AND NOT EXISTS (
                SELECT 1 FROM TestDB.dbo.ACH_TesterHardwareMatrix mx WHERE mx.MasterID = m.MasterID
            )
            ORDER BY m.UpdatedAt DESC`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách linh kiện phần cứng đã mapping (Tương tự DoubleCheck)
     */
    async getHardwareMapping(masterId) {
        const strQuery = `
            SELECT
                d.typedesc AS type,
                m.HardwareCode as code
            FROM TestDB.dbo.ACH_MasterHardwareMapping m
            LEFT JOIN [CIMitar_HCC].[dbo].[Desc_HwType_Detail] d
                ON d.typeid = TRY_CONVERT(BIGINT, m.HardwareType)
            WHERE m.MasterID = ${masterId}`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách file đính kèm (Tương tự DoubleCheck)
     */
    async getAttachments(masterId) {
        const strQuery = `
            SELECT FileName, FileSize, FileType, FilePath 
            FROM TestDB.dbo.ACH_MasterAttachments 
            WHERE MasterID = ${masterId}`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Thực hiện đăng ký vào Matrix
     */
    async registerToMatrix(masterId, badgeNo) {
        const params = {
            "@MasterID": masterId,
            "@RegisteredBy": badgeNo
        };
        return await this.apiClient.callSp("[TestDB]..[USP_ACH_RegisterToMatrix]", params);
    }

    /**
     * Trả về cho bên TEST xử lý lại
     */
    async returnToTest(masterId, badgeNo, comment) {
        const params = {
            "@MasterID": masterId,
            "@MFG_BadgeNo": badgeNo,
            "@Comment": comment
        };
        return await this.apiClient.callSp("[TestDB]..[USP_ACH_ReturnToTest]", params);
    }
}
