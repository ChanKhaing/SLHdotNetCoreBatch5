using Microsoft.EntityFrameworkCore;
using SLHdotNetCoreBatch5.database.Models;

namespace SLHdotNetCoreBatch5.MininmalApi2.Endpoints.Blogs
{
    public static class BlogsEndpoint
    {
        //public static string Test(this int i)  //this is understand this keyworad chage to BlogsEndpoint.Test(9) 9.Test
        //{
        //    return i.ToString();
        //}

        public static void UseBlogEndPoint(this IEndpointRouteBuilder app)
        {



            app.MapGet("/blogs", () => {
                AppDbContext db = new AppDbContext();
                var blogs = db.TblBlogs.AsNoTracking().Where(x => x.DeleteFlag == false).ToList();

                return Results.Ok(blogs);
            })
            .WithName("GetBlogs")
            .WithOpenApi();


            app.MapGet("/blogs/{id}", (int id) => {
                AppDbContext db = new AppDbContext();
                var blog = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

                if (blog is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(blog);
            })
            .WithName("GetBlogById")
            .WithOpenApi();

            app.MapPost("/blogs", (TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                var result = db.SaveChanges();

                return Results.Ok(result);
            })
            .WithName("CreateBlog")
            .WithOpenApi();


            app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                var existingBlog = db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);

                if (existingBlog is null)
                {
                    return Results.NotFound();
                }
                existingBlog.BlogTitle = blog.BlogTitle;
                existingBlog.BlogAuthor = blog.BlogAuthor;
                existingBlog.BlogContent = blog.BlogContent;
                db.Entry(existingBlog).State = EntityState.Modified;
                db.SaveChanges();
                return Results.Ok(existingBlog);
            })
            .WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();
                var existingBlog = db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);

                if (existingBlog is null)
                {
                    return Results.NotFound();
                }

                db.Entry(existingBlog).State = EntityState.Deleted;
                db.SaveChanges();
                return Results.Ok("Deleted successfully");
            })
            .WithName("DeleteBlog")
            .WithOpenApi();


        }

    }
}
