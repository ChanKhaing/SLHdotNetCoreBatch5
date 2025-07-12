//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("This is a .NET 8.0 console application using C# 12.0 language features.");
//Console.ReadLine();



using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


Console.WriteLine("Hello world i am testing C# with query");

// Fixed CS1001 and CS1002 by completing the SqlConnection declaration and adding a semicolon

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

if (result > 0)
{
    Console.WriteLine("New blog post inserted successfully.");
}
else
{
    Console.WriteLine("Failed to insert new blog post.");
}



//Console.ReadKey();










//string query1 = @"INSERT INTO [dbo].[Tbl_Blog]
//           ([BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent]
//           ,[DeleteFlag])
//     VALUES
//           (@blogTitle
//           ,@blogAuthor
//           ,@blogContent
//           ,0)";


//SqlCommand cmd1 =new SqlCommand(query1, connection);
//cmd1.Parameters.AddWithValue("@blogTitle", BlogTitle);
//cmd1.Parameters.AddWithValue("@blogAuthor", BlogAuthor);
//cmd1.Parameters.AddWithValue("@blogContent", BlogContent);


//int result = cmd1.ExecuteNonQuery();

//Console.WriteLine(result == 1 ? "Saving successful" : "Saving Failed");






