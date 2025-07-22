using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLHdotNetCoreBatch5.database.Models;

namespace SLHdotNetCoreBatch5.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetBlogs()
        {   
            //AppDbContext db = new AppDbContext();
            // Simulate fetching blogs from a database or service
            var blogs = _db.TblBlogs.AsNoTracking().ToList();
            //return Ok(new { message = "Get post" });
            return Ok(blogs);
        }



        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            // Simulate creating a blog post
            blog.DeleteFlag ??= false;
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
           return Ok(blog);
        }

        //This method is used to show the original data when you are editing your post
        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            // Simulate fetching a blog post by ID
            //var blog = _db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) 
            {
                return NotFound(new { message = $"BlogPost with ID {id} not found." });
            }
            return Ok(item);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id); 
            if (item is null)
              {
                return NotFound();
            }

            // Keep original state unless new value is provided
            var originalDeleteFlag = item.DeleteFlag;

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            // Update DeleteFlag only if blog.DeleteFlag is not null
            item.DeleteFlag = blog.DeleteFlag ?? originalDeleteFlag;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }  

       




        [HttpGet("softdelte/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound(new { message = $"BlogPost with ID {id} not found." });
            }
            item.DeleteFlag = true;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        
        }





        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            // Simulate deleting a blog post by ID
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if(item is null)            
            {
                return NotFound(new { message = $"BlogPost with ID {id} not found." });
            }
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
            return Ok(new { message = $"Delete post with ID {id} succesfuly but i can't let this if you want to delete you can use softdelete" });
        }




    }
}
