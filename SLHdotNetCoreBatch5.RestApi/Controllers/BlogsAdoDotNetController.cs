using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using SLHdotNetCoreBatch5.RestApi.ViewModels;
using System.Collections.Generic;

namespace SLHdotNetCoreBatch5.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
        //[HttpGet]
        //public IActionResult GetBlogs()
        //{
        //    List<BlogsViewModel> lst = new List<BlogsViewModel>();
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();

        //    string query = @"SELECT [BlogId]
        //   ,[BlogTitle]
        //   ,[BlogAuthor]
        //   ,[BlogContent]
        //   ,[DeleteFlag]
        //   FROM [dbo].[Tbl_Blog]";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    //DataTable dt = new DataTable();
        //    //adapter.Fill(dt);


        //    ////when you are using datareader like you are in libaray and you can read whatever you want no limit book but you can't take home
        //    ////if you are using datareader you should take care connection don't lost but runtime fast 
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Console.WriteLine(reader["BlogId"]);
        //        Console.WriteLine(reader["BlogTitle"]);
        //        Console.WriteLine(reader["BlogAuthor"]);
        //        Console.WriteLine(reader["BlogContent"]);

        //        lst.Add(new BlogsViewModel
        //        {
        //            Id = Convert.ToInt32(reader["BlogId"]),
        //            //Title = reader["BlogTitle"].ToString(),
        //            Title = Convert.ToString(reader["BlogTitle"]),
        //            Author = Convert.ToString(reader["BlogAuthor"]),
        //            Content = Convert.ToString(reader["BlogContent"]),
        //            DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
        //        });
        //    }
        //    connection.Close();
        //    return Ok(lst);
        //}





        //[HttpGet]
        //public IActionResult GetBlog() {


        //    //List<dynamic> blogs = new List<dynamic>();
        //    List<BlogsViewModel> blogs = new List<BlogsViewModel>();  //something you write wrong output when lopping you don't knows

        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();
        //    string query = @"SELECT [BlogId]
        //                      ,[BlogTitle]
        //                      ,[BlogAuthor]
        //                      ,[BlogContent]
        //                      ,[DeleteFlag]
        //                  FROM [dbo].[Tbl_Blog]";

        //    SqlCommand cmd = new SqlCommand(query,connection);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //     while (reader.Read())
        //    {
        //        Console.WriteLine(reader["BlogId"]);
        //        Console.WriteLine(reader["BlogTitle"]);
        //        Console.WriteLine(reader["BlogAuthor"]);
        //        Console.WriteLine(reader["BlogContent"]);
        //        blogs.Add(new BlogsViewModel
        //        {
        //            Id = Convert.ToInt32(reader["BlogId"]),
        //            //Title = reader["BlogTitle"].ToString(),
        //            Title = Convert.ToString(reader["BlogTitle"]),
        //            Author = Convert.ToString(reader["BlogAuthor"]),
        //            Content = Convert.ToString(reader["BlogContent"]),
        //            DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
        //        });
        //        //dynamic blog = new System.Dynamic.ExpandoObject();

        //        //blog.BlogId = reader["BlogId"];
        //        //blog.BlogTitle = reader["BlogTitle"];
        //        //blog.BlogAuthor = reader["BlogAuthors"];
        //        //blog.BlogContent = reader["BlogContent"];
        //        //blog.DeleteFlag = reader["DeleteFlag"];

        //        //blogs.Add(blog);
        //    }

        //    connection.Close();




        //    return Ok(blogs);
        //}

    
    }
}
