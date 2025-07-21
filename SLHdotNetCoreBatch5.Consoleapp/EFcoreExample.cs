using Microsoft.EntityFrameworkCore;
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

        //The edit method is show one data why the reason is when you are using facebook to upload your post you are missing something .
        //This time when you are not updated or fill something you will see first your uploaded post(original data with mistake).
        //you don't see anything how can you uplodad(update) or edit you post.so you need to see first thing is your original post
        public void Edit(int id)
        {
        
            AppDbContext db = new AppDbContext();
            //var lst = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
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

        //public void Update(int id, string title, string author, string content)
        //{
        //    AppDbContext db = new AppDbContext();
        //    var item = db.Blogs
        //        .AsNoTracking()
        //        .FirstOrDefault(x => x.BlogId == id);
        //    if (item is null)
        //    {
        //        Console.WriteLine("No data found.");
        //        return;
        //    }

        //    if (!string.IsNullOrEmpty(title))
        //    {
        //        item.BlogTitle = title;
        //    }
        //    if (!string.IsNullOrEmpty(author))
        //    {
        //        item.BlogAuthor = author;
        //    }
        //    if (!string.IsNullOrEmpty(content))
        //    {
        //        item.BlogContent = content;
        //    }

        //    //db.Blogs.Update(item);
        //    //var result = db.SaveChanges();
        //    //Console.WriteLine(result == 1 ? "Blog updated successfully." : "Failed to update blog.");

        //    db.Entry(item).State = EntityState.Modified;
        //    var result = db.SaveChanges();
        //    Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");
        //}

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }

            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }

            if (!string.IsNullOrEmpty(content))

            {
                item.BlogContent = content;
            }
            db.Entry(item).State = EntityState.Modified;
            var result = db.SaveChanges();  
            Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");




        }


        public void softdelete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            item.DeleteFlag = !item.DeleteFlag; // Toggle the DeleteFlag value
            db.Entry(item).State = EntityState.Modified;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Softdelete successful" : "Softdelete fail");





        }


        public void delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Delete successful" : "Delete fail");





        }










    }
}
