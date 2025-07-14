//// See https://aka.ms/new-console-template for more information
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

// Fixed CS1001 and CS1002 by completing the SqlConnection declaration and adding a semicolon





//error need to debug start

string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

Console.WriteLine("Enter your BlogId ");
string id = Console.ReadLine();

//Console.WriteLine("your BlogId is " + id);



string query = @"DELETE FROM [dbo].[Tbl_Blog]
 WHERE BlogId = @blogid";

SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
cmd.Parameters.AddWithValue("@BlogId", id);




int result = cmd.ExecuteNonQuery();
connection.Close();
Console.WriteLine(result == 1 ? "Delete Successful" : "no data found");
//Error debug end *****8


//DataTable dt = new DataTable();
//adapter.Fill(dt);
//Console.WriteLine("Data read successfully. Number of rows: " + dt.Rows.Count);
//Console.WriteLine("connection start to end ");
//Console.WriteLine("Connection closing....");


//AdoDotNetExample adodotnetExample = new AdoDotNetExample();
//adodotnetExample.read();
//adodotnetExample.create();
//adodotnetExample.edit();

//Console.ReadKey();



//Console.WriteLine("Blog Id: ");
//string id = Console.ReadLine();

//Console.WriteLine("Blog Title: ");
//string title = Console.ReadLine();

//Console.WriteLine("Blog Author: ");
//string author = Console.ReadLine();

//Console.WriteLine("Blog Content: ");
//string content = Console.ReadLine();

//SqlConnection connection = new SqlConnection(connectionString);
//connection.Open();

//string query = $@"UPDATE [dbo].[Tbl_Blog]
//   SET [BlogTitle] = @BlogTitle
//      ,[BlogAuthor] = @BlogAuthor
//      ,[BlogContent] = @BlogContent
//      ,[DeleteFlag] = 0
// WHERE BlogId = @BlogId";

//SqlCommand cmd = new SqlCommand(query, connection);
//cmd.Parameters.AddWithValue("@BlogId", id);
//cmd.Parameters.AddWithValue("@BlogTitle", title);
//cmd.Parameters.AddWithValue("@BlogAuthor", author);
//cmd.Parameters.AddWithValue("@BlogContent", content);

//int result = cmd.ExecuteNonQuery();

//connection.Close();

//Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");














