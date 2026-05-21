export default class DeleteKitsService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    /**
     * Lấy dữ liệu ma trận tương thích (Hỗ trợ Multi-select filtering)
     * Đã tối ưu hóa: Sử dụng trực tiếp TesterName và HardwareCode (lưu tên linh kiện)
     * @param {Object} params - { customerCodes, deviceIds, packageIds, testerIds }
     */
    async getCompatibilityMatrix(params = {}) {
        const { customerCodes, deviceIds, packageIds, testerIds } = params;

        const buildInClause = (values, column, isString = false) => {
            if (!values || !Array.isArray(values) || values.length === 0) return "";
            const formattedValues = isString ? values.map(v => `'${v}'`).join(',') : values.join(',');
            return ` AND ${column} IN (${formattedValues})`;
        };

        const baseWhere = "WHERE m.DoubleCheckStatus = 'REGISTERED'";
        const cWhere = buildInClause(customerCodes, 'm.CustomerID', true);
        const dWhere = buildInClause(deviceIds, 'm.DeviceID');
        const pWhere = buildInClause(packageIds, 'm.PackageID');
        const tWhere = buildInClause(testerIds, 'm.TesterID');

        const strQuery = `
            SELECT
                d.DeviceCode,
                p.PackageName,
                m.MasterID,
                m.TesterName as testername,
                U.username,
                m.Pitch,
                m.HandlerRecipe,
                hw.HardwareType,
                hw.HardwareCode AS HardwareName
            FROM TestDB.dbo.ACH_TesterHardwareMaster m
                JOIN TestDB.dbo.ACH_Device d ON m.DeviceID = d.DeviceID
                JOIN TestDB.dbo.ACH_Package p ON m.PackageID = p.PackageID
                LEFT JOIN TestDB.dbo.ACH_MasterHardwareMapping hw ON m.MasterID = hw.MasterID
                LEFT JOIN [ATV_Common].[dbo].[Common_API_User] U ON m.CreatedBy = U.badgeno
            ${baseWhere} ${cWhere} ${dWhere} ${pWhere} ${tWhere}
            ORDER BY d.DeviceCode, p.PackageName, m.TesterName`;

        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Delete kits by MasterID (call Stored Procedure)
     * @param {Array} masterIds
     */
    async deleteByMasterIDs(masterIds = []) {

        if (!masterIds.length) return;

        // gọi từng ID (theo SP hiện tại)
        const calls = masterIds.map(id => {
            const strQuery = `
                EXEC [TestDB].[dbo].[USP_ACH_DeleteHardwareMasterByMasterID]
                    @MasterID = ${id}
            `;
            return this.apiClient.callSc(strQuery, "CIMitar");
        });

        return await Promise.all(calls);
    }


    /**
     * Lấy cấu hình Active thực tế hiện tại của các máy từ bảng RFIDInfo (Realtime)
     * @param {Object} params - { testerNames }
     */
    async getActiveConfigurations(params = {}) {
        const { testerNames } = params;
        const namesStr = (testerNames && testerNames.length > 0) ? `'${testerNames.join(',')}'` : 'NULL';
        const strQuery = `EXEC [TestDB].[dbo].[USP_ACH_GetRealtimeActiveConfig] @TesterNames = ${namesStr}`;
        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

    /**
     * Lấy tất cả options cho bộ lọc dựa trên các giá trị đã chọn (Cascading Filters - Hỗ trợ Multi-select)
     * @param {Object} params - { customerCodes, deviceIds, packageIds, testerIds }
     */
    async getAvailableFilters(params = {}) {
        const { customerCodes, deviceIds, packageIds, testerIds } = params;

        const baseWhere = "WHERE m.DoubleCheckStatus = 'REGISTERED'";

        const buildInClause = (values, column, isString = false) => {
            if (!values || !Array.isArray(values) || values.length === 0) return "";
            const formattedValues = isString ? values.map(v => `'${v}'`).join(',') : values.join(',');
            return ` AND ${column} IN (${formattedValues})`;
        };

        const cWhere = buildInClause(customerCodes, 'm.CustomerID', true);
        const dWhere = buildInClause(deviceIds, 'm.DeviceID');
        const pWhere = buildInClause(packageIds, 'm.PackageID');

        const queries = {
            customers: `
                SELECT DISTINCT c.customercode as code, c.customername as name
                FROM TestDB.dbo.ACH_TesterHardwareMaster m
                JOIN [CIMitar_Master].[dbo].[Customer] c ON m.CustomerID = c.customercode
                ${baseWhere}
                ORDER BY c.customername`,
            devices: `
                SELECT DISTINCT d.DeviceID as code, d.DeviceCode as name
                FROM TestDB.dbo.ACH_TesterHardwareMaster m
                JOIN TestDB.dbo.ACH_Device d ON m.DeviceID = d.DeviceID
                ${baseWhere} ${cWhere}
                ORDER BY d.DeviceCode`,
            packages: `
                SELECT DISTINCT p.PackageID as code, p.PackageName as name
                FROM TestDB.dbo.ACH_TesterHardwareMaster m
                JOIN TestDB.dbo.ACH_Package p ON m.PackageID = p.PackageID
                ${baseWhere} ${cWhere} ${dWhere}
                ORDER BY p.PackageName`,
            testers: `
                SELECT DISTINCT m.TesterID as code, m.TesterName as name
                FROM TestDB.dbo.ACH_TesterHardwareMaster m
                ${baseWhere} ${cWhere} ${dWhere} ${pWhere}
                ORDER BY m.TesterName`
        };

        const [customers, devices, packages, testers] = await Promise.all([
            this.apiClient.callSc(queries.customers, "CIMitar"),
            this.apiClient.callSc(queries.devices, "CIMitar"),
            this.apiClient.callSc(queries.packages, "CIMitar"),
            this.apiClient.callSc(queries.testers, "CIMitar")
        ]);

        return { customers, devices, packages, testers };
    }

}
