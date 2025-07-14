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


        public void create()
        {

            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //



            Console.WriteLine("Enter your BlogTitle");
            string BlogTitle = Console.ReadLine();
            Console.WriteLine(BlogTitle);

            Console.WriteLine("Enter your BlogAuthor");
            string BlogAuthor = Console.ReadLine();
            Console.WriteLine(BlogAuthor);



            Console.WriteLine("Enter your BlogContent");
            string BlogContent = Console.ReadLine();
            Console.WriteLine(BlogContent);

            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            string query1 = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
          ( @BlogTitle,
           @BlogAuthor ,
           @BlogContent
           ,0)";
            SqlCommand cmd1 = new SqlCommand(query1, connection1);
            cmd1.Parameters.AddWithValue("@BlogTitle", BlogTitle);

            cmd1.Parameters.AddWithValue("@BlogAuthor", BlogAuthor);
            cmd1.Parameters.AddWithValue("@BlogContent", BlogContent);

            int result = cmd1.ExecuteNonQuery();
            connection1.Close();

            Console.WriteLine(result == 1 ? "Saving successful" : "Saving Failed");
        }


        public void edit() 
        {



            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Enter your BlogId ");
            string blogId = Console.ReadLine();
            Console.WriteLine("your BlogId is " + blogId);


            ////read data start*****

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";






            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
        
            
            Console.WriteLine("Data read successfully. Number of rows: " + dt.Rows.Count);
            Console.WriteLine("connection start to end ");
            Console.WriteLine("Connection closing....");

            connection.Close();


            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }


        public void update()
        {
            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Enter your BlogId ");
            string id = Console.ReadLine();

            //Console.WriteLine("your BlogId is " + id);


            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();


            string query = @"UPDATE [dbo].[Tbl_Blog]
           SET[BlogTitle] = @blogTitle,
           [BlogAuthor] = @blogAuthor,
           [BlogContent] = @blogContent,
           [DeleteFlag] = 0
           WHERE BlogId = @blogid";





            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BlogId", id);


            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result == 1 ? "Update successful" : "Saving Failed");








        }


    }


    }

