using System.Data;
using System.Data.SqlClient;

namespace ATV_Common_WebAPI.Common.Utilities
{
    public class DatabaseUtility
    {
        private readonly string _connectionString;

        public DatabaseUtility(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Method to get DataTable using a SQL query
        public DataTable GetDataTableByQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty", nameof(query));

            DataTable dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        // Method to get DataSet using a stored procedure
        public DataSet GetDataSetByStoredProcedure(string storedProcedureName, List<SqlParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(storedProcedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty", nameof(storedProcedureName));

            DataSet dataSet = new DataSet();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.StoredProcedure })
            using (var adapter = new SqlDataAdapter(command))
            {
                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                connection.Open();
                adapter.Fill(dataSet);
            }
            return dataSet;
        }

        // Method to async get DataTable using a SQL query
        public async Task<DataTable> GetDataTableByQueryAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty", nameof(query));

            DataTable dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }

        // Method to async get DataSet using a stored procedure
        public async Task<DataSet> GetDataSetByStoredProcedureAsync(string storedProcedureName, List<SqlParameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(storedProcedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty", nameof(storedProcedureName));

            DataSet dataSet = new DataSet();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(storedProcedureName, connection) { CommandType = CommandType.StoredProcedure })
            using (var adapter = new SqlDataAdapter(command))
            {
                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                await connection.OpenAsync();
                adapter.Fill(dataSet);
            }
            return dataSet;
        }


    }
}
