using SLHdotNetCoreBatch5.Consoleapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.Consoleapp
{
   public class EfcoreExample
    {

        public void read()
        {
            // Entity Framework Core is an ORM that allows you to work with databases using C# objects.
            // It provides a higher-level abstraction for data access compared to ADO.NET and Dapper.
            
               AppDbContext db = new AppDbContext();
            //var lst = db.Blogs.ToList();
            var lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();


            //var blogs = db.Blogs.Where(b => b.DeleteFlag => 0 == false).ToList();   this is ai suggestion and it is no work
            foreach (var blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }
        }   

        public void create(string title, string author, string content)
        {
            BlogEfcoreDataModel blog = new BlogEfcoreDataModel
            {
              BlogTitle = title,
              BlogAuthor = author,
              BlogContent = content,

            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            var result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Blog created successfully." : "Failed to create blog.");



        }


        public void Edit(int id)
        {
        
            AppDbContext db = new AppDbContext();
            //var lst = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);



        }


    }
}
