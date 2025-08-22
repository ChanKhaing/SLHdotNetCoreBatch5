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
            }
            else
            {
                Console.WriteLine("No user found with the given ID.");
            }
          

        }

    }
}
