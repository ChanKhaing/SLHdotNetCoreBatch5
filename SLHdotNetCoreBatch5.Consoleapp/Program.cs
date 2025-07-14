//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("This is a .NET 8.0 console application using C# 12.0 language features.");
//Console.ReadLine();



using SLHdotNetCoreBatch5.Consoleapp;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


Console.WriteLine("Hello world i am testing C# with query");

// Fixed CS1001 and CS1002 by completing the SqlConnection declaration and adding a semicolon







//string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
//SqlConnection connection = new SqlConnection(connectionString);
//connection.Open();

//Console.WriteLine("Enter your BlogId ");
//string blogId = Console.ReadLine();
//Console.WriteLine("your BlogId is " + blogId);


//////read data start*****

//string query = @"SELECT [BlogId]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//      ,[DeleteFlag]
//  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";






//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//cmd.Parameters.AddWithValue("@BlogId", blogId);
//DataTable dt = new DataTable();
//adapter.Fill(dt);
//Console.WriteLine("Data read successfully. Number of rows: " + dt.Rows.Count);
//Console.WriteLine("connection start to end ");
//Console.WriteLine("Connection closing....");

//connection.Close();

//if (dt.Rows.Count == 0)
//{
//    Console.WriteLine("No data found.");
//    return;
//}

//DataRow dr = dt.Rows[0];
//Console.WriteLine(dr["BlogId"]);
//Console.WriteLine(dr["BlogTitle"]);
//Console.WriteLine(dr["BlogAuthor"]);
//Console.WriteLine(dr["BlogContent"]);
        

AdoDotNetExample adodotnetExample = new AdoDotNetExample();
//adodotnetExample.read();
//adodotnetExample.create();
adodotnetExample.edit();

Console.ReadKey();















