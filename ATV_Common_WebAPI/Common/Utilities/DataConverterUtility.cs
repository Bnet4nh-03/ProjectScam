using System.Data;
using System.Text.Json;

namespace ATV_Common_WebAPI.Common.Utilities;

public static class DataConverterUtility
{
    public static object ConvertJsonElement(JsonElement jsonElement)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.String:
                return jsonElement.GetString();
            case JsonValueKind.Number:
                if (jsonElement.TryGetInt32(out int intValue))
                    return intValue;
                if (jsonElement.TryGetInt64(out long longValue))
                    return longValue;
                if (jsonElement.TryGetDouble(out double doubleValue))
                    return doubleValue;
                return jsonElement.GetDecimal();
            case JsonValueKind.True:
            case JsonValueKind.False:
                return jsonElement.GetBoolean();
            case JsonValueKind.Null:
                return DBNull.Value;
            default:
                return jsonElement.GetRawText();
        }
    }

    public static List<Dictionary<string, object>> ConvertDataTableToList(DataTable dataTable)
    {
        using (dataTable) // Dispose the DataTable when finished
        {
            // Convert DataTable to a list of dictionaries.
            var lstData = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    dict.Add(column.ColumnName, row[column]);
                }
                lstData.Add(dict);
            }

            return lstData;
        }
    }

    public static List<object> ConvertDataSetToList(DataSet dataSet)
    {
        using (dataSet) // Dispose the DataSet when finished
        {
            // Create a list of dictionaries to hold the data.
            var listData = new List<object>();

            // Iterate through each table in the DataSet.
            foreach (DataTable table in dataSet.Tables)
            {
                // Convert each table to a list of dictionaries.
                var tableData = new List<Dictionary<string, object>>();

                foreach (DataRow row in table.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn column in table.Columns)
                    {
                        dict.Add(column.ColumnName, row[column]);
                    }
                    tableData.Add(dict);
                }

                // Add the table data to the overall list data.
                listData.Add(new { TableName = table.TableName, Data = tableData });
            }

            return listData;
        }
    }
}
