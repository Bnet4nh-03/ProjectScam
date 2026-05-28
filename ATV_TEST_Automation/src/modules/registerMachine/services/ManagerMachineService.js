export default class ManagerMachineService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }

    async getTesterNotRun() {
        const strQuery = `
            SELECT
                t.*,
                tc.flag_run,
                tc.flag_manual,
                tc.flag_dash,
                tc.menucode,
                tc.handlerid,
                tc.language,
                tc.use_tpa,
                h.rfidnm
            FROM [CIMitar_Master].[dbo].[Tester] t
            LEFT JOIN [CIMitar_Master].[dbo].[TesterEnv] tc
                ON t.testerid = tc.testerid
            LEFT JOIN [CIMitar_Master].[dbo].[Handler] h
                ON tc.handlerid = h.handlerid
            WHERE NOT EXISTS (
                SELECT 1
                FROM [CIMitar_Log].[dbo].[RfidHistory] rh
                WHERE rh.hostnm = t.emeshost
            )

            ORDER BY t.testerid DESC;`

        return await this.apiClient.callSc(strQuery, "CIMitar");
    }

}
