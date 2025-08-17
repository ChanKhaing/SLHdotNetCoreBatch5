using Microsoft.EntityFrameworkCore;
using SLHdotNetCoreBatch5.ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.ConsoleApp2
{
    public class EfcoreExample
    {
        public void readtest()
        {   
            AppDbcontext db= new AppDbcontext();
            //Blogdbcontext db = new Blogdbcontext();
            //var lst = db.TestBlogs.ToList();
            var lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();
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
            EfcoreBlogDataModels blog = new EfcoreBlogDataModels
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            AppDbcontext db = new AppDbcontext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Creating successful" : "try again ");


        }


        //public void edit()
        //{
        //    Console.WriteLine("Enter your id and search");
        //    //int id = Console.ReadLine();
        //    string testid = Console.ReadLine();
        //    AppDbcontext db = new AppDbcontext();

        //    var blog = db.Blogs.FirstOrDefault(x => x.BlogId == testid).ToList();
        //    if (blog is null)
        //    {
        //        Console.WriteLine("No Data found");
        //        return;
        //    }
        //    Console.WriteLine(blog.BlogId);
        //    Console.WriteLine(blog.BlogTitle);
        //    Console.WriteLine(blog.BlogAuthor);
        //    Console.WriteLine(blog.BlogContent);

        //}

        public void edit(int testid)
        {
            AppDbcontext db = new AppDbcontext();

            var blog = db.Blogs.FirstOrDefault(x => x.BlogId == testid);
            if (blog is null)
            {
                Console.WriteLine("No Data found");
                return;
            }
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);

        }


        public void Update(int id, string title, string author, string content)
        {
            AppDbcontext db = new AppDbcontext();
            var item = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
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

            //db.Blogs.Update(item);
            //var result = db.SaveChanges();
            //Console.WriteLine(result == 1 ? "Blog updated successfully." : "Failed to update blog.");

            db.Entry(item).State = EntityState.Modified;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");
        }

    }
}
