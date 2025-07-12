using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.Consoleapp
{
    public class AdoDotNetExample
    {
        public void read() 
           {


            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //read data start*****
            string query = @"SELECT [BlogId]
           ,[BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag]
           FROM [dbo].[Tbl_Blog]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //read data end******
           

            ////when you are using datareader like you are in libaray and you can read whatever you want no limit book but you can't take home
            ////if you are using datareader you should take care connection don't lost but runtime fast 
            //SqlDataReader reader = cmd.ExecuteReader();
            //while(reader.Read())
            //{
            //    Console.WriteLine(reader["BlogId"]);
            //    Console.WriteLine(reader["BlogTitle"]);
            //    Console.WriteLine(reader["BlogAuthor"]);
            //    Console.WriteLine(reader["BlogContent"]);
            //}
            //Console.WriteLine("This is table gui view is okay or not okay ");


            Console.WriteLine("Connection closing....");
            connection.Close();

                }


    }
}
