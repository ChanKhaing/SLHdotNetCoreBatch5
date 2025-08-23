using Microsoft.IdentityModel.Tokens;
using SLHdotNetCoreBatch5Test.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//this is using adodotnettest serive use 
namespace SLHdotNetCoreBatch5.ConsoleApp3
{
    public class AdoDotnetServiceOne
    {
        private readonly AdoDotnetTestService _adoDotnetTestservie;
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //

        public AdoDotnetServiceOne()
        {
            _adoDotnetTestservie = new AdoDotnetTestService(_connectionString);
        }


        public void Read()
        {
            string query = @"SELECT [BlogId]
           ,[BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag]
           FROM [dbo].[Tbl_Blog]";

          var result =   _adoDotnetTestservie.Query(query);
            foreach (DataRow dr in result.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);
            }

        }

        public void Edit()
        {
            Console.WriteLine("Enter your id");
            string id = Console.ReadLine();

            string query = @"SELECT [BlogId]
           ,[BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag]
           FROM [dbo].[Tbl_Blog] where BlogId = @blogId";

            var dt = _adoDotnetTestservie.Query(query,new SqlParameterModel
            {
                Name= "@blogid",
                Value =id
            });
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }
            else
            {
                Console.WriteLine("No user found with the given ID.");
            }
          

        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                       ([BlogTitle]
                       ,[BlogAuthor]
                       ,[BlogContent]
                       ,[DeleteFlag])

                       VALUES
                      (@BlogTitle,
		              @BlogAuthor,
		              @BlogContent,
                      0
		              )";
            Console.WriteLine("Enter your BlogTitle");
            string blogtitle = Console.ReadLine();
            Console.WriteLine("Enter your BlogAuthor");
            string blogauthor = Console.ReadLine();
            Console.WriteLine("Enter your BlogContent");
            string blogcontent = Console.ReadLine();

            if (blogtitle.IsNullOrEmpty())
            {
                 blogtitle = "default blog title";
            }
            if (blogauthor.IsNullOrEmpty()) 
            {
                blogauthor = "default blog author";
            }
            if (blogcontent.IsNullOrEmpty()) {
                blogcontent = "default blog content";
            }

            var result = _adoDotnetTestservie.Execute(query,
             new SqlParameterModel
             {
                 Name = "@BlogTitle",
                 Value = blogtitle

             },
              new SqlParameterModel
              {
                  Name = "@BlogAuthor",
                  Value = blogauthor
              },
            new SqlParameterModel
            {
                Name = "@BlogContent",
                Value = blogcontent
            });

            Console.WriteLine(result == 1 ? "Created successfully" : "Cant created successful");
        }

        public void Update() 
        {
            Console.WriteLine("Enter your id");
            string id = Console.ReadLine();

            string query = @"SELECT [BlogId]
           ,[BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag]
           FROM [dbo].[Tbl_Blog] where BlogId = @blogId";

            var dt = _adoDotnetTestservie.Query(query, new SqlParameterModel
            {
                Name = "@blogid",
                Value = id
            });
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No user found with the given ID.");
                return;
            } 
            else {
                DataRow dr = dt.Rows[0];
                Console.WriteLine("Enter your BlogTitle");
                string blogtitle = Console.ReadLine();

                Console.WriteLine("Enter your BlogAuthor");
                string blogauthor = Console.ReadLine();

                Console.WriteLine("Enter your BlogContent");
                string blogcontent = Console.ReadLine();

                string query2 = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId =@BlogId";

                if (blogtitle.IsNullOrEmpty())
                {
                    blogtitle = dr["BlogTitle"].ToString();
                }
                if (blogauthor.IsNullOrEmpty())
                {
                    blogauthor = dr["BlogAuthor"].ToString();

                }
                if (blogcontent.IsNullOrEmpty())
                {
                    blogcontent = dr["BlogContent"].ToString();
                }

                var result = _adoDotnetTestservie.Execute(query2,
                              new SqlParameterModel
                              {
                                  Name = "@BlogId",
                                  Value = id

                              },
                            new SqlParameterModel
                            {
                                Name = "@BlogTitle",
                                Value = blogtitle

                            },
                             new SqlParameterModel
                             {
                                 Name = "@BlogAuthor",
                                 Value = blogauthor
                             },
                           new SqlParameterModel
                           {
                               Name = "@BlogContent",
                               Value = blogcontent
                           });
                Console.WriteLine(result == 1 ? "Updated successfully" : "Can not updated");
            }


        }

    }
}
