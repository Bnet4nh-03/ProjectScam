using System.Data;
using System.Data.SqlClient;
using ATV_Common_WebAPI.Common.Utilities;
using ATV_Common_WebAPI.TEST.KIOXIA.Interfaces;

namespace ATV_Common_WebAPI.TEST.KIOXIA.Services
{
    public class GetLotInfoService : IKioxiaService
    {
        private readonly DatabaseUtility _dbUtil;

        public GetLotInfoService(DatabaseUtility dbUtil)
        {
            _dbUtil = dbUtil;
        }

        public async Task<List<object>> GetPKGSort_COMBINE_INF(string lotno)
        {
            var sqlParamList = new List<SqlParameter>
            {
                new SqlParameter("@lotno", lotno)
            };

            DataSet dataSet = await _dbUtil.GetDataSetByStoredProcedureAsync("CIMitar_Master.dbo.USP_KIOXIA_GetPKGSORT_COMBINE_INF", sqlParamList);

            int quantity = 0;
            string message = string.Empty;

            try
            {
                if (dataSet.Tables[0]?.Rows.Count > 0)
                {
                    var dataRow = dataSet.Tables[0].Rows[0];
                    quantity = int.Parse(dataRow["Qty"].ToString().Trim());
                    message = dataRow["Message"].ToString().Trim();
                }
                return new List<object> { new { Qty = quantity, Message = message } };
            }
            catch (Exception ex)
            {
                return new List<object> { new { Qty = -1, ex.Message } };
            }
        }
    }
}