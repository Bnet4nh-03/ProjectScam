export default class DoubleCheckService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    /**
     * Lấy danh sách các yêu cầu đang chờ phê duyệt (PENDING) dành cho một Approver cụ thể
     * @param {string} badgeNo 
     */
    async getListPending(badgeNo) {
        const strQuery = `
            SELECT 
                m.MasterID as id,
                c.customername as customer,
                d.DeviceCode as device,
                p.PackageName as package,
                t.testername as tester,
                m.Pitch as pitch,
                m.HandlerRecipe as recipe,
                FORMAT(m.CreatedAt, 'yyyy-MM-dd HH:mm') as date,
                t.testername as platform,
                CASE WHEN m.Pitch < 0.4 THEN 'High Precision' ELSE 'Standard' END as level,
                u.username as requester,
                m.DoubleCheckStatus as status
            FROM TestDB.dbo.ACH_TesterHardwareMaster m
            JOIN [CIMitar_Master].[dbo].[Customer] c ON m.CustomerID = c.customercode
            JOIN TestDB.dbo.ACH_Device d ON m.DeviceID = d.DeviceID
            JOIN TestDB.dbo.ACH_Package p ON m.PackageID = p.PackageID
            JOIN [CIMitar_Master].[dbo].[Tester] t ON m.TesterID = t.testerid
            LEFT JOIN [ATV_Common].[dbo].[Common_API_User] u ON m.CreatedBy = CAST(u.badgeno AS NVARCHAR)
            WHERE m.DoubleCheckStatus = 'PENDING'
            AND m.ApproverBadgeNo = '${badgeNo}'
            ORDER BY m.CreatedAt DESC`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách linh kiện phần cứng đã mapping theo MasterID
     * @param {number} masterId 
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
     * Lấy danh sách file đính kèm theo MasterID
     * @param {number} masterId 
     */
    async getAttachments(masterId) {
        const strQuery = `
            SELECT 
                FileName, 
                FileSize, 
                FileType, 
                FilePath 
            FROM TestDB.dbo.ACH_MasterAttachments 
            WHERE MasterID = ${masterId}`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Gửi quyết định phê duyệt hoặc từ chối
     * @param {number} masterId 
     * @param {string} status 'APPROVED' hoặc 'REJECTED'
     * @param {string} comment 
     * @param {string} badgeNo 
     */
    async submitDecision(masterId, status, comment, badgeNo) {
        const params = {
            "@MasterID": masterId,
            "@Status": status,
            "@Comment": comment,
            "@ApproverBadgeNo": badgeNo
        };
        // Giả định có SP xử lý việc update status và chuyển data sang bảng Matrix nếu APPROVED
        return await this.apiClient.callSp("[TestDB]..[USP_ACH_ProcessDoubleCheck]", params);
    }
}
