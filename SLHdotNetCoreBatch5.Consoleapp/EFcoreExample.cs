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
            var lst = db.Blogs.ToList();

            //var blogs = db.Blogs.Where(b => b.DeleteFlag == 0).ToList();
            foreach (var blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }
        }
        
        //public void create(string title, string author, string content)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var blog = new BlogEfcoreDataModel
        //        {
        //            BlogTitle = title,
        //            BlogAuthor = author,
        //            BlogContent = content,
        //            DeleteFlag = 0
        //        };
        //        db.Blogs.Add(blog);
        //        db.SaveChanges();
        //    }
        //}

    }
}
