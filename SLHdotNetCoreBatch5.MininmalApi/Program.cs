//using Microsoft.EntityFrameworkCore;
//using SLHdotNetCoreBatch5.database.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();


//app.MapGet("/blogs", () =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().ToList();

//    return Results.Ok(new { item });
//})
//.WithName("GetBlogs")
//.WithOpenApi();

////Edit
//app.MapGet("/blogs/{id}", (int id) => 
//{    

//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item is null)
//    {
//        return Results.NotFound();
//    }
//    return Results.Ok(new { item });
//}).WithName("GetBlog")
//   .WithOpenApi();


//app.MapPost("/blogs", (TblBlog blog) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.Add(blog);
//    db.SaveChanges();
//    return Results.Ok(new { item = item.Entity, message = "Blog created successfully!" });
//})
//.WithName("CreateBlog")
//.WithOpenApi();


//app.MapPut("/blogs/{id}", (int id, TblBlog blog) => {
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item is null)
//    {
//        return Results.NotFound();
//    }
//    item.BlogTitle = blog.BlogTitle;
//    item.BlogAuthor = blog.BlogAuthor;
//    item.BlogContent = blog.BlogContent;

//    db.Entry(item).State = EntityState.Modified;
//    db.SaveChanges();

//    return Results.Ok();

//}).WithName("UpdateBlog")
//   .WithOpenApi();

//app.MapDelete("/blogs/{id}", (int id) =>
//{
//    AppDbContext db = new AppDbContext();
//    var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
//    if (item is null)
//    {
//        return Results.NotFound(); 
//    }
//    db.Entry(item).State = EntityState.Deleted;
//    db.SaveChanges();
//    return Results.Ok();
//}).WithName("DeleteBlog")
//   .WithOpenApi();

//app.MapPost("/blogs", (TblBlog blog) =>
//{
//    // Simulate creating a blog post
//    blog.DeleteFlag ??= false;
//    // Here you would typically save the blog to a database
//    return Results.Ok(blog);
//})

app.UseBlogEndpoint();
//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}

