//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("This is a .NET 8.0 console application using C# 12.0 language features.");
//Console.ReadLine();



using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello world i am testing C# with query");

// Fixed CS1001 and CS1002 by completing the SqlConnection declaration and adding a semicolon
string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; 
Console.WriteLine("Connection string : " + connectionString);
SqlConnection connection =new SqlConnection(connectionString);
connection.Open();
Console.WriteLine("Connection opening.....");

string query = @"
SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";

SqlCommand cmd = new SqlCommand(query,connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd); //what is this?
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//when you are using datareader like you are in libaray and you can read whatever you want no limit book but you can't take home
//if you are using datareader you should take care connection don't lost but runtime fast 
SqlDataReader reader = cmd.ExecuteReader();
while(reader.Read())
{
    Console.WriteLine(reader["BlogId"]);
    Console.WriteLine(reader["BlogTitle"]);
    Console.WriteLine(reader["BlogAuthor"]);
    Console.WriteLine(reader["BlogContent"]);
}
Console.WriteLine("This is table gui view is okay or not okay ");





Console.WriteLine("Connection closing....");
connection.Close();
//when you using dataadapter just like you can borrow a book from libaray but you take a little not all
//you can write this connection close upon or under you don't care
//foreach(DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);

//}

Console.ReadKey();