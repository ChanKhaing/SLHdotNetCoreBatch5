using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5Test.Shared
{
    public class AdoDotnetTestService
    {
        private readonly string _connectionstring;

        public  AdoDotnetTestService(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public DataTable Query(string query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (sqlParameters is not  null)
            {
                foreach (var Sqlparameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(Sqlparameter.Name, Sqlparameter.Value);
                }
            }
          
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            connection.Close();
            return dt;
        }
    }


    public class SqlParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
