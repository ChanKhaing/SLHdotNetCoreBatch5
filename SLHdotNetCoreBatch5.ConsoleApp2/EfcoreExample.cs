using System;
using System.Collections.Generic;
using System.Linq;
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
            var lst = db.Blogs.ToList();
            foreach (var blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }
        }

    }
}
