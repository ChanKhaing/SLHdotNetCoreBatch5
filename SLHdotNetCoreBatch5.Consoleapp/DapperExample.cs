﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SLHdotNetCoreBatch5.Consoleapp.Models;

namespace SLHdotNetCoreBatch5.Consoleapp
{
    public class DapperExample
    {

        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123";

        public void read()
        {
            // Dapper is a micro ORM that simplifies data access in .NET applications.
            // It allows you to execute SQL queries and map results to C# objects easily.
            //string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //

            //using (IDbConnection Db = new SqlConnection(connectionString))
            using (IDbConnection Db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0;";
                //var lst = Db.Query<dynamic>(query).ToList();
                //var lst = db.Query(query).ToList();
                var lst = Db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)

                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
            {

            }
        }

        public void create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
          ( @BlogTitle,
           @BlogAuthor ,
           @BlogContent
           ,0)";

            //if we are not using dto just like we are not using model class
            //data transfer object we can use dynamic and it can be error on variable assign 

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {   
                    //BlogTtle = title,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content


                });

                if (result > 0)
                {
                    Console.WriteLine("Data inserted successfully.");
                }
                else
                {
                    Console.WriteLine("Data insertion failed.");
                }


            }


        }









    }
}

