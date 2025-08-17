// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SLHdotNetCoreBatch5.ConsoleApp2;

//using SLHdotNetCoreBatch5.database.Models;
using System.Collections.Generic;

//Console.WriteLine("Hello, World!");
//// Example of using Entity Framework Core to read data from a database and this is database first approach.
//AppDbContext db = new AppDbContext();
//var items =  db.TblBlogs.ToList();
//foreach (var blog in items)
//{
//    Console.WriteLine(blog.BlogId);
//    Console.WriteLine(blog.BlogTitle);
//    Console.WriteLine(blog.BlogAuthor);
//    Console.WriteLine(blog.BlogContent);
//}


EfcoreExample efcoreExample = new EfcoreExample();
//efcoreExample.readtest();
//efcoreExample.create("blogtitle2", "blogauthor2", "blogauthor3");
//efcoreExample.edit(2);
efcoreExample.Update(2, "tilte2", "author2", "content2");
//var content = new ContentModel
//{
//    Id = 1,
//    Title = "About new Technology",
//    Author = "Chan",
//    Content = "Don't try to be copy and paste developer "
//};

////serialize the object to JSON and it mean encode the object to JSON format
////string strJson = JsonConvert.SerializeObject(content);

//string strjson  = content.Tojson();
//Console.WriteLine(strjson);
////Console.ReadLine();


////how to convert json to C# object 
////jsont  mean json text
////decode the JSON text to C# object
//string jsont = """{"id":1,"title":"Test Title","author":"Test Author","content":"Test Content"}""";
//var jsonToObj = JsonConvert.DeserializeObject<ContentModel>(jsont);
//Console.WriteLine(jsonToObj.Title);
//Console.ReadKey();




//public class ContentModel
//{
//    public int Id { get; set; }
//    public string? Title { get; set; }
//    public string? Author { get; set; }
//    public string? Content { get; set; }

//}


////Extension ,devcode, helper

//public static class Devcode
//{
//    //    public static string ToJson(this object obj)
//    //    {
//    //        return JsonConvert.SerializeObject(obj);
//    //    }

//    public static string Tojson(this object obj)
//    {
//        string JsonFromstr = JsonConvert.SerializeObject(obj);
//        return JsonFromstr;
//    }

    
//}

