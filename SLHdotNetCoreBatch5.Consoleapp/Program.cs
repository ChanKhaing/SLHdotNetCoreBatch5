﻿//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("This is a .NET 8.0 console application using C# 12.0 language features.");
//Console.ReadLine();



using SLHdotNetCoreBatch5.Consoleapp;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//using Microsoft.Data.SqlClient;


Console.WriteLine("Hello world i am testing C# with query");


//string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; 

//SqlConnection connection = new SqlConnection(connectionString);
//connection.Open();

////read data start*****
//string query = @"SELECT [BlogId]
//           ,[BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent]
//           ,[DeleteFlag]
//           FROM [dbo].[Tbl_Blog]";

//SqlCommand cmd = new SqlCommand(query, connection);
////SqlDataAdapter adapter = new SqlDataAdapter(cmd);
////DataTable dt = new DataTable();
////adapter.Fill(dt);
////read data end******


//////when you are using datareader like you are in libaray and you can read whatever you want no limit book but you can't take home
//////if you are using datareader you should take care connection don't lost but runtime fast 
//SqlDataReader reader = cmd.ExecuteReader();
//while (reader.Read())
//{
//    Console.WriteLine(reader["BlogId"]);
//    Console.WriteLine(reader["BlogTitle"]);
//    Console.WriteLine(reader["BlogAuthor"]);
//    Console.WriteLine(reader["BlogContent"]);
//}
////Console.WriteLine("This is table gui view is okay or not okay ");


//Console.WriteLine("Connection closing....");
//connection.Close();


//AdoDotNetExample adodotnetExample = new AdoDotNetExample();
//adodotnetExample.read();
//adodotnetExample.create();
//adodotnetExample.edit();


//DapperExample dapperExample = new DapperExample();
//dapperExample.read();
//dapperExample.create("ddddd", "dddddd", "ddddf");
//Console.ReadKey();


EfcoreExample efcoreExample = new EfcoreExample();
//efcoreExample.read();
//efcoreExample.create("New Blog Title", "New Author", "This is the content of the new blog.");   
efcoreExample.Edit(7); // Replace 1 with the actual BlogId you want to edit














