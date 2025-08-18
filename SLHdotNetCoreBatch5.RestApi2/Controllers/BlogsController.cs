using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLHdotNetCoreBatch5.database.Models;

namespace SLHdotNetCoreBatch5.RestApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.TblBlogs.AsNoTracking().Where(x => x.DeleteFlag == false).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound(new { message = $"BlogPost with ID {id} not found." });
            }
            return Ok(item);


        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);


            if (item is null)
            {
                return NotFound();
            }
            // Update the blog post with new values
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }




        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            if (blog is null)
            {
                return BadRequest("Blog data is null");
            }
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
            return Ok(blog);
        }

        //[HttpPut]
        //public IActionResult UpdateBlog()
        //{
        //    return Ok();
        //}

        [HttpDelete]
        public IActionResult DeleteBlog()
        {
            return Ok();
        }



    }
}


//remember when you start to open this host before run the project
