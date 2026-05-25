using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using static ATV_Common_WebAPI.Common.Services.DataService;
using static ATV_Common_WebAPI.Common.Utilities.OtherUtility;

namespace ATV_Common_WebAPI.Common.Services
{
    public class DataService : IDataService, ILoggerService
    {
        private readonly IDictionary<string, DatabaseUtility> _dbUtilities;

        public DataService(IDictionary<string, DatabaseUtility> dbUtilities)
        {
            _dbUtilities = dbUtilities;
        }

        public class RequestSqlCommand
        {
            public string? dbKey { get; set; } = "CIMitar";
            public required string RequestValidateCode { get; set; }
            public required string SQLQuery { get; set; }
            public bool? LogSave { get; set; } = true;
        }

        public class RequestStoreProcedure
        {
            public string? dbKey { get; set; } = "CIMitar";
            public required string RequestValidateCode { get; set; }
            public required string StoreProcedureName { get; set; }
            public required List<string> ParametersList { get; set; }
            public required List<object> ArgumentList { get; set; }
            public bool? LogSave { get; set; } = true;
        }

        public class RequestSC
        {
            public string? dbKey { get; set; } = "CIMitar";
            public required string scQuery { get; set; }
            public bool? logSave { get; set; } = true;
        }

        public class RequestSP
        {
            public string? dbKey { get; set; } = "CIMitar";
            public required string spName { get; set; }
            public required Dictionary<string, object> spQuery { get; set; }
            public bool? logSave { get; set; } = true;
        }

        public async Task<string> GetRequestValidateCode()
        {
            DataTable dataTable = await _dbUtilities["CIMitar"].GetDataTableByQueryAsync("SELECT TOP 1 validate_code FROM ATV_Common.dbo.Common_API_Data_Method_Request_Validate_Code ORDER BY create_time DESC;");
            using (dataTable)
            {
                string requestValidateCode = string.Empty;
                if (dataTable.Rows.Count > 0)
                {
                    requestValidateCode = dataTable.Rows[0]["validate_code"].ToString();
                    if (string.IsNullOrEmpty(requestValidateCode)) requestValidateCode = string.Empty;
                }
                return requestValidateCode;
            }
        }

        public static List<Dictionary<string, object>> ReturnListMessage(string returnKey, string returnValue)
        {
            return new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object> { { returnKey, returnValue} }
                };
        }

        public async Task<List<Dictionary<string, object>>> CallSqlCommand(RequestSqlCommand requestSqlCommand)
        {
            if (requestSqlCommand == null) return new List<Dictionary<string, object>>();

            try
            {
                var dbUtility = _dbUtilities[requestSqlCommand.dbKey];
                if (dbUtility == null) return ReturnListMessage("Error", "Invalid database key");

                if (requestSqlCommand.RequestValidateCode != await GetRequestValidateCode())
                {
                    return ReturnListMessage("Error", "Request Validate Code is not correct");
                }

                using (var dataTable = await dbUtility.GetDataTableByQueryAsync(requestSqlCommand.SQLQuery))
                {
                    return DataConverterUtility.ConvertDataTableToList(dataTable);
                }
            }
            catch (Exception ex)
            {
                return ReturnListMessage("Error", ex.Message);
            }
        }

        public async Task<string> CallSqlCommandGetJsonString(RequestSqlCommand requestSqlCommand)
        {
            if (requestSqlCommand == null) return "Error: requestSqlCommand is NULL";

            try
            {
                var dbUtility = _dbUtilities[requestSqlCommand.dbKey];
                if (dbUtility == null) return "Error: Invalid database key";

                if (requestSqlCommand.RequestValidateCode != await GetRequestValidateCode())
                {
                    return "Error: Request Validate Code is not correct";
                }

                using (var dataTable = await dbUtility.GetDataTableByQueryAsync(requestSqlCommand.SQLQuery))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(DataConverterUtility.ConvertDataTableToList(dataTable));
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<List<object>> CallStoreProcedure(RequestStoreProcedure requestSP)
        {
            if (requestSP == null) return new List<object>();
            if (requestSP.ParametersList.Count != requestSP.ArgumentList.Count)
                return new List<object> { ReturnListMessage("Error", "Parameter list and argument list is not equal") };

            var sqlParamList = new List<SqlParameter>();
            for (int i = 0; i < requestSP.ParametersList.Count; i++)
            {
                if (requestSP.ParametersList[i][0].ToString() != "@")
                    return new List<object> { ReturnListMessage("Error", $"Parameter list variable '{requestSP.ParametersList[i]}' is not start by @") };

                var argument = requestSP.ArgumentList[i];
                if (argument is JsonElement jsonElement)
                {
                    argument = DataConverterUtility.ConvertJsonElement(jsonElement);
                }

                var sqlDbType = GetSqlDbType(argument);
                sqlParamList.Add(new SqlParameter(requestSP.ParametersList[i].ToString(), sqlDbType) { Value = argument });
            }

            try
            {
                var dbUtility = _dbUtilities[requestSP.dbKey];
                if (dbUtility == null) return new List<object> { ReturnListMessage("Error", "Invalid database key") };

                if (requestSP.RequestValidateCode != await GetRequestValidateCode())
                {
                    return new List<object> { ReturnListMessage("Error", "Request Validate Code is not correct") };
                }

                using (var dataSet = await dbUtility.GetDataSetByStoredProcedureAsync(requestSP.StoreProcedureName, sqlParamList))
                {
                    return DataConverterUtility.ConvertDataSetToList(dataSet);
                }
            }
            catch (Exception ex)
            {
                return new List<object> { ReturnListMessage("Error", ex.Message) };
            }
        }

        public async Task<string> CallStoreProcedureGetJsonString(RequestStoreProcedure requestSP, string? returnType = "str")
        {
            if (requestSP == null) return "Error: requestSP is NULL";
            if (requestSP.ParametersList.Count != requestSP.ArgumentList.Count)
                return "Error: Parameter list and argument list is not equal";

            var sqlParamList = new List<SqlParameter>();
            for (int i = 0; i < requestSP.ParametersList.Count; i++)
            {
                if (requestSP.ParametersList[i][0].ToString() != "@")
                    return $"Error: Parameter list variable '{requestSP.ParametersList[i]}' is not start by @";

                var argument = requestSP.ArgumentList[i];
                if (argument is JsonElement jsonElement)
                {
                    argument = DataConverterUtility.ConvertJsonElement(jsonElement);
                }

                var sqlDbType = GetSqlDbType(argument);
                sqlParamList.Add(new SqlParameter(requestSP.ParametersList[i].ToString(), sqlDbType) { Value = argument });
            }

            try
            {
                var dbUtility = _dbUtilities[requestSP.dbKey];
                if (dbUtility == null) return "Error: Invalid database key";

                if (requestSP.RequestValidateCode != await GetRequestValidateCode())
                {
                    return "Error: Request Validate Code is not correct";
                }

                using (var dataSet = await dbUtility.GetDataSetByStoredProcedureAsync(requestSP.StoreProcedureName, sqlParamList))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(DataConverterUtility.ConvertDataSetToList(dataSet));
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task SetDbCallLog(ClientInfo clientInfo, RequestSqlCommand? sqlCommand, RequestStoreProcedure? requestStoreProcedure)
        {
            var sqlParamList = new List<SqlParameter>
            {
                new SqlParameter("@client_ip", clientInfo.ClientIP),
                new SqlParameter("@client_hostname", clientInfo.ClientHostname),
                new SqlParameter("@user_agent", clientInfo.UserAgent)
            };

            if (sqlCommand != null)
            {
                sqlParamList.AddRange(
                [
                    new SqlParameter("@sql_query", sqlCommand.SQLQuery),
                    new SqlParameter("@request_validate_code", sqlCommand.RequestValidateCode)
                ]);
            }

            if (requestStoreProcedure != null)
            {
                string joinedParameters = string.Join(",", requestStoreProcedure.ParametersList);
                string joinedArguments = string.Join(",", requestStoreProcedure.ArgumentList.Select(arg => arg.ToString()));
                sqlParamList.AddRange(
                [
                    new SqlParameter("@sp_name", requestStoreProcedure.StoreProcedureName),
                    new SqlParameter("@sp_param", joinedParameters),
                    new SqlParameter("@sp_argument", joinedArguments),
                    new SqlParameter("@request_validate_code", requestStoreProcedure.RequestValidateCode)
                ]);
            }

            await _dbUtilities["CIMitar"].GetDataSetByStoredProcedureAsync("ATV_Common.dbo.USP_Set_Common_API_Data_Method_DB_Call_Log", sqlParamList);
        }

        public async Task SetDbCallLogEnCo(ClientInfo clientInfo, RequestSC? requestSC, RequestSP? requestSP)
        {
            var sqlParamList = new List<SqlParameter>
            {
                new SqlParameter("@client_ip", clientInfo.ClientIP),
                new SqlParameter("@client_hostname", clientInfo.ClientHostname),
                new SqlParameter("@user_agent", clientInfo.UserAgent)
            };

            if (requestSC != null)
            {
                sqlParamList.AddRange(
                [
                    new SqlParameter("@sql_query", requestSC.scQuery),
                    new SqlParameter("@request_validate_code", "DB_EnCo")
                ]);
            }

            if (requestSP != null)
            {
                string joinedParameters = string.Join(",", requestSP.spQuery.Keys);
                string joinedArguments = string.Join(",", requestSP.spQuery.Values.Select(arg => arg.ToString()));
                sqlParamList.AddRange(
                [
                    new SqlParameter("@sp_name", requestSP.spName),
                    new SqlParameter("@sp_param", joinedParameters),
                    new SqlParameter("@sp_argument", joinedArguments),
                    new SqlParameter("@request_validate_code", "DB_EnCo")
                ]);
            }

            await _dbUtilities["CIMitar"].GetDataSetByStoredProcedureAsync("ATV_Common.dbo.USP_Set_Common_API_Data_Method_DB_Call_Log", sqlParamList);
        }

        public void Log(string? appInfo = "", string? className = "", string? methodName = "", string? functionName = "", string? logInfo = "")
        {
            var sqlParamList = new List<SqlParameter>
            {
                new SqlParameter("@app_info", appInfo),
                new SqlParameter("@class_name", className),
                new SqlParameter("@method_name", methodName),
                new SqlParameter("@function_name", functionName),
                new SqlParameter("@log_info", logInfo)
            };

            var dataSet = _dbUtilities["CIMitar"].GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Set_Common_API_Log", sqlParamList);
        }

        private SqlDbType GetSqlDbType(object value)
        {
            if (value == null)
            {
                return SqlDbType.Variant;
            }

            if (value is JsonElement jsonElement)
            {
                switch (jsonElement.ValueKind)
                {
                    case JsonValueKind.String:
                        return SqlDbType.NVarChar;
                    case JsonValueKind.Number:
                        return SqlDbType.Decimal; 
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        return SqlDbType.Bit;
                    case JsonValueKind.Null:
                        return SqlDbType.Variant;
                    default:
                        return SqlDbType.Variant;
                }
            }

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Boolean: return SqlDbType.Bit;
                case TypeCode.Byte: return SqlDbType.TinyInt;
                case TypeCode.Int16: return SqlDbType.SmallInt;
                case TypeCode.Int32: return SqlDbType.Int;
                case TypeCode.Int64: return SqlDbType.BigInt;
                case TypeCode.Single: return SqlDbType.Real;
                case TypeCode.Double: return SqlDbType.Float;
                case TypeCode.Decimal: return SqlDbType.Decimal;
                case TypeCode.DateTime: return SqlDbType.DateTime;
                case TypeCode.String: return SqlDbType.NVarChar;
                default: return SqlDbType.Variant;
            }
        }

        public async Task<List<Dictionary<string, object>>> CallSC(RequestSC requestSC)
        {
            if (requestSC == null)
            {
                throw new ArgumentNullException(nameof(requestSC));
            }

            try
            {
                if (!_dbUtilities.TryGetValue(requestSC.dbKey, out var dbUtility) || dbUtility == null)
                {
                    throw new Exception("Invalid database key");
                }

                using (var dataTable = await dbUtility.GetDataTableByQueryAsync(requestSC.scQuery))
                {
                    return DataConverterUtility.ConvertDataTableToList(dataTable);
                }
            }
            catch (Exception ex)
            {
                // Re-throw the exception to be handled by the middleware
                throw new Exception("An error occurred while calling the SQL command.", ex);
            }
        }

        public async Task<List<object>> CallSP(RequestSP requestSP)
        {
            if (requestSP == null)
            {
                throw new ArgumentNullException(nameof(requestSP));
            }

            var sqlParamList = new List<SqlParameter>();
            foreach (var spQuery in requestSP.spQuery)
            {
                if (spQuery.Key[0] != '@')
                {
                    throw new FormatException($"Parameter list variable '{spQuery.Key}' must start with @");
                }

                var argument = spQuery.Value;
                if (argument is JsonElement jsonElement)
                {
                    argument = DataConverterUtility.ConvertJsonElement(jsonElement);
                }

                var sqlDbType = GetSqlDbType(argument);
                sqlParamList.Add(new SqlParameter(spQuery.Key, sqlDbType) { Value = argument });
            }

            try
            {
                if (!_dbUtilities.TryGetValue(requestSP.dbKey, out var dbUtility) || dbUtility == null)
                {
                    throw new Exception("Invalid database key");
                }

                using (var dataSet = await dbUtility.GetDataSetByStoredProcedureAsync(requestSP.spName, sqlParamList))
                {
                    return DataConverterUtility.ConvertDataSetToList(dataSet);
                }
            }
            catch (Exception ex)
            {
                // Re-throw the exception to be handled by the middleware
                throw new Exception("An error occurred while calling the stored procedure.", ex);
            }
        }
    }
}