export default class MasterRegistrationService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    /**
     * Lấy danh sách người phê duyệt Double Check
     * @param {string} department 
     * @param {number|string} badgeNo 
     */
    async getListDoubleCheckApprove(department, badgeNo) {
        const strQuery = `SELECT
                            badgeno AS code,
                            user_id + ' - ' + username + ' (' + email + ') - ' + user_title + ' - ' + user_group AS name
                        FROM [ATV_Common].[dbo].[Common_API_User]
                        WHERE onflag = 1`;
                        // AND user_group = '${department}'
                        // AND badgeno <> ${badgeNo}`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách loại linh kiện (Component Types)
     */
    async getListComponentTypes() {
        const strQuery = `SELECT 
                                typeid AS code,
                                typedesc AS name
                            FROM [CIMitar_HCC].[dbo].[Desc_HwType_Detail]
                            WHERE typeid IN (64, 13, 74)
                            ORDER BY
                                CASE typeid
                                    WHEN 64 THEN 1
                                    WHEN 13 THEN 2
                                    WHEN 74 THEN 3
                                END`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách khách hàng
     */
    async getListCustomer() {
        const strQuery = `SELECT 
                            customercode as code, 
                            customername as name
                        FROM [CIMitar_Master].[dbo].[Customer]
                        WHERE activate = 1`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách Tester
     */
    async getListTester() {
        const strQuery = `SELECT testerid as code,
                            testername as name
                        FROM [CIMitar_Master].[dbo].[Tester]
                        ORDER BY testername`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách Device từ DB nội bộ
     */
    async getListDevice() {
        const strQuery = `SELECT 
                            DeviceID as code, 
                            DeviceCode as [name] 
                        FROM TestDB.dbo.ACH_Device
                        ORDER BY DeviceCode`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách Package từ DB nội bộ
     */
    async getListPackage() {
        const strQuery = `SELECT 
                            PackageID as code, 
                            PackageName as [name] 
                        FROM TestDB.dbo.ACH_Package
                        ORDER BY PackageName`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy danh sách Hardware dựa trên loại linh kiện
     * @param {number} typeCode 
     */
    async getListHardware(typeCode) {
        let strQuery = "";
        switch (typeCode) {
            case 64: // TB
                strQuery = `SELECT id as code, 
                            hclocation as name 
                        FROM [CIMitar_HCC].[dbo].[Hw_Board]
                        WHERE typeid = ${typeCode}`;
                break;
            case 13: // CK
            case 74: // MP
                strQuery = `SELECT id as code, 
                            hclocation as name 
                        FROM [CIMitar_HCC].[dbo].[Hw_Kit]
                        WHERE typeid = ${typeCode}`;
                break;
            default:
                return [];
        }
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Submit dữ liệu đăng ký Master Hardware sử dụng Stored Procedure
     * @param {Object} masterData 
     * @param {string} createdBy 
     */
    async submitMasterRegistration(masterData, createdBy) {
        const hardwareJson = masterData.hardwareList.map(item => ({
            HardwareType: item.type.code,
            HardwareID: item.code.code,
            HardwareName: item.code.name
        }));

        const params = {
            "@CustomerID": masterData.customer.code,
            "@DeviceID": masterData.device.code || null,
            "@DeviceCode": masterData.device.name,
            "@PackageID": masterData.package.code || null,
            "@PackageName": masterData.package.name,
            "@TesterID": masterData.tester.code,
            "@TesterName": masterData.tester.name,
            "@Pitch": masterData.pitch,
            "@HandlerRecipe": masterData.handlerRecipe,
            // "@ApproverBadgeNo": masterData.approver,
            "@CreatedBy": createdBy,
            "@FlowOrder" :0,
            "@FlowID" :27,
            "@HardwareJson": JSON.stringify(hardwareJson),
            "@AttachmentsJson": JSON.stringify(masterData.attachments)
        };
        // Sử dụng callSp với tiền tố @ cho tham số
        return await this.apiClient.callSp("[TestDB]..[USP_ACH_RegisterHardwareMaster]", params);
    }

    /**
     * Lấy lịch sử đăng ký của bản thân
     */
    async getMyHistory(badgeNo) {
        const strQuery = `
            SELECT 
                m.MasterID as id,
                c.customername as customer,
                d.DeviceCode as device,
                p.PackageName as package,
                t.testername as tester,
                m.Pitch as pitch,
                m.HandlerRecipe as recipe,
                m.DoubleCheckStatus as status,
                m.ApprovalComment as rejectReason,
                m.MFG_Comment as returnReason,
                FORMAT(m.CreatedAt, 'yyyy-MM-dd HH:mm') as date
            FROM TestDB.dbo.ACH_TesterHardwareMaster m
            JOIN [CIMitar_Master].[dbo].[Customer] c ON m.CustomerID = c.customercode
            JOIN TestDB.dbo.ACH_Device d ON m.DeviceID = d.DeviceID
            JOIN TestDB.dbo.ACH_Package p ON m.PackageID = p.PackageID
            JOIN [CIMitar_Master].[dbo].[Tester] t ON m.TesterID = t.testerid
            WHERE m.CreatedBy = '${badgeNo}'
            ORDER BY m.CreatedAt DESC`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }
}
