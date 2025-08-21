using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.Consoleapp
{
    public class AdoDotnet
    {
        public void Read()
        {
            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();
            string query = @"SELECT [UserId]
                              ,[UserName]
                              ,[Address]
                              ,[Email]
                              ,[BlackList]
                          FROM [dbo].[Tbl_User]";
            SqlCommand cmd = new SqlCommand(query, sqlconnection);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogId"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);
            //    //Console.WriteLine(dr["DeleteFlag"]);
            //}

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["UserName"]);
                Console.WriteLine(dr["Address"]);
                Console.WriteLine(dr["Email"]);
                Console.WriteLine(dr["BlackList"]);


            }

            sqlconnection.Close();

        }


        public void Read(int id)
        {
            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();
            string query = @"SELECT [UserId]
                              ,[UserName]
                              ,[Address]
                              ,[Email]
                              ,[BlackList]
                          FROM [dbo].[Tbl_User] where UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, sqlconnection);
            cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
           if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["UserName"]);
                Console.WriteLine(dr["Address"]);
                Console.WriteLine(dr["Email"]);
                Console.WriteLine(dr["BlackList"]);
            }
            else
            {
                Console.WriteLine("No user found with the given ID.");
            }

            sqlconnection.Close();

        }


        //public void Create(String username,string address,string email,bool ? blacklist = false) 
        //{
        //    string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    string query = @"INSERT INTO [dbo].[Tbl_User]
        //                       ([UserName]
        //                       ,[Address]
        //                       ,[Email]
        //                       ,[BlackList]        )
        //                 VALUES
        //                       (@UserName
        //                       ,@Address
        //                       ,@Email,
        //                        @BlackList
        //                       )";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@UserName", username);
        //    cmd.Parameters.AddWithValue("@Address", address);
        //    cmd.Parameters.AddWithValue("@Email", email);
        //    cmd.Parameters.AddWithValue("@BlackList", blacklist);

        //    int result = cmd.ExecuteNonQuery();

        //    Console.WriteLine(result == 1 ? "Created user successfully" : "You Can not created and try again"); ;


        //    connection.Close();
        //}


        //public void Create(string blogtitle, string blogauthor, string blogcontent, bool deleteflag = false) 
        //{

        //    string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    string query = @"INSERT INTO [dbo].[Tbl_Blog]
        //                   ([BlogTitle]
        //                   ,[BlogAuthor]
        //                   ,[BlogContent]
        //                   ,[DeleteFlag])
        //             VALUES
        //                  (@BlogTitle,
        //                   @BlogAuthor,
        //                   @BlogContent,
        //                   @DeleteFlag
        //                   )";
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@BlogTitle", blogtitle);
        //    cmd.Parameters.AddWithValue("@BlogAuthor", blogauthor);
        //    cmd.Parameters.AddWithValue("@BlogContent", blogcontent);
        //    cmd.Parameters.AddWithValue("@DeleteFlag", deleteflag);
        //    int result =      cmd.ExecuteNonQuery();
        //    Console.WriteLine(result == 1 ? "Created blog successfully" : "Can not Created");
        //    connection.Close();


        //}


        //public void Update(int id, string username, string address, string email, bool? blacklist = false)
        public void Update(int id)
        {
            //string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //

            string connectionString = "Data Source =.;Initial Catalog = DotNetTrainngBatch5;User ID = sa; Password =sasa@123";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = @"SELECT [UserId]
                              ,[UserName]
                              ,[Address]
                              ,[Email]
                              ,[BlackList]
                          FROM [dbo].[Tbl_User] where UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["UserName"]);
                Console.WriteLine(dr["Address"]);
                Console.WriteLine(dr["Email"]);
                Console.WriteLine(dr["BlackList"]);

            }
            else
            {
                Console.WriteLine("No user found with the given ID.");
                return;
            }



            connection.Close();
        
        
        
        
        
        
        }




        //public void Read()
        //{ 
        //string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
        // SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    string query = @"SELECT [BlogId]
        //              ,[BlogTitle]
        //              ,[BlogAuthor]
        //              ,[BlogContent]
        //              ,[DeleteFlag]
        //          FROM [dbo].[Tbl_Blog]";
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);

        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        Console.WriteLine(dr["BlogId"]);
        //        Console.WriteLine(dr["BlogTitle"]);
        //    }
        //    connection.Close();
        //}

    }
}
