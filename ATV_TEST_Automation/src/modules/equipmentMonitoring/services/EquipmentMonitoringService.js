export default class EquipmentMonitoringService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }


    async getTotalJamList(from_date, to_date, platform_type) {
        let param;
        param = {
            "@From_date" : from_date,
            "@To_date": to_date,
            "@Platform_type": platform_type
            }
        const resp = await this.apiClient.callSp("[TestDB]..[USP_PmMonitor_Get_Total_JAM_List]", param)
        
        return resp[0]['data']
    }


}
