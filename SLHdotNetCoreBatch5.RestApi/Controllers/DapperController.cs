using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SLHdotNetCoreBatch5.RestApi.DataModels;
using SLHdotNetCoreBatch5.RestApi.ViewModels;
using System.Data;
using Dapper;


namespace SLHdotNetCoreBatch5.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        //[HttpGet]
        //public IActionResult GetBlog()
        //{


        //    List<dynamic> blogs = new List<dynamic>();
        //    //List<BlogsViewModel> blogs = new List<BlogsViewModel>();  //something you write wrong output when lopping you don't knows

        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    string query = @"SELECT [BlogId]
        //                      ,[BlogTitle]
        //                      ,[BlogAuthor]
        //                      ,[BlogContent]
        //                      ,[DeleteFlag]
        //                  FROM [dbo].[Tbl_Blog]";
        //    using (IDbConnection Db = new SqlConnection(_connectionString))
        //    {
        //        string query1 = "select * from tbl_blog where DeleteFlag = 0;";
        //        //var lst = Db.Query<dynamic>(query1).ToList();
        //        var lst = Db.Query(query1).ToList();
        //        //var lst = Db.Query<BlogDataModel>(query).ToList(); //purpose to add blogdatamodel mean output worng name to add in foreach show 
        //        foreach (var item in lst)

        //        {
        //            Console.WriteLine(item.BlogId);
        //            Console.WriteLine(item.BlogTitle);
        //            Console.WriteLine(item.BlogAuthor);
        //            Console.WriteLine(item.BlogContent);
        //        }
        //    }

        //    return Ok();
        //}


        [HttpGet]
        public IActionResult GetBlog()
        {
            List<dynamic> blogs;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [BlogId],
                                [BlogTitle],
                                [BlogAuthor],
                                [BlogContent],
                                [DeleteFlag]
                         FROM [dbo].[Tbl_Blog]
                         WHERE DeleteFlag = 0";

                blogs = db.Query(query).ToList(); // Dapper returns IEnumerable<dynamic> when no type is specified
            }

            return Ok(blogs); // Return the dynamic list as JSON
        }
    }
}
