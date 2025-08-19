// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SLHdotNetCoreBatch5.ConsoleApp3;
using SLHdotNetCoreBatch5.database.Models;

//Console.WriteLine("Hello, World!");
//AppDbContext db = new AppDbContext();
//   var lst          = db.TblBlogs.Where(x => x.DeleteFlag == false).ToList();
//foreach (var blog in lst)
//{
//    Console.WriteLine(blog.BlogId);
//    Console.WriteLine(blog.BlogTitle);
//    Console.WriteLine(blog.BlogAuthor);
//    Console.WriteLine(blog.BlogContent);
//}


//AdoDotnetExample adodotnet = new AdoDotnetExample();
//adodotnet.Run();

var contentModel = new contentModel
{
    Id = 1,
    Name = "Chan Chan",
    title = "Title",
    author = "Author",
};

//var jsonstr = JsonConvert.SerializeObject(contentModel,Formatting.Indented);

var jsonstr = contentModel.ToJson();
Console.WriteLine(jsonstr);


string json2 = """{ "Id": 1,"Name": "Chankhine", "title": "Title","author": "Author" }   """;
var blog = JsonConvert.DeserializeObject<contentModel>(json2);

Console.WriteLine(blog.ToJson());

public class contentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string title { get; set; }
    public  string author { get; set; }

}

public static class Extensions
{
    public static string ToJson(this object obj)
    {
     string jsonstr = JsonConvert.SerializeObject(obj, Formatting.Indented);

        return jsonstr;
    }
}