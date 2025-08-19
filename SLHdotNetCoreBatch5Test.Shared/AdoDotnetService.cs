using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SLHdotNetCoreBatch5Test.Shared
{
    public class AdoDotnetService
    {

        private readonly string _connectionString;

        public AdoDotnetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable Query(string query)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            connection.Close();

            return dt;

        }
    }
}
