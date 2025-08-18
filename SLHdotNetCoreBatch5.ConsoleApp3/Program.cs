// See https://aka.ms/new-console-template for more information
using SLHdotNetCoreBatch5.database.Models;

Console.WriteLine("Hello, World!");
AppDbContext db = new AppDbContext();
   var lst          = db.TblBlogs.Where(x => x.DeleteFlag == false).ToList();
foreach (var blog in lst)
{
    Console.WriteLine(blog.BlogId);
    Console.WriteLine(blog.BlogTitle);
    Console.WriteLine(blog.BlogAuthor);
    Console.WriteLine(blog.BlogContent);
}