using SLHdotNetCoreBatch5Test.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.ConsoleApp3
{
    public class AdoDotnetExample
    {

    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123"; //
        private readonly AdoDotnetService _adoDotnetService;

        public AdoDotnetExample()
        {
            _adoDotnetService = new AdoDotnetService(_connectionString);
        }

        public void Run()
        {
            string query = @"SELECT [BlogId]
           ,[BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag]
           FROM [dbo].[Tbl_Blog]";
            var dt = _adoDotnetService.Query(query);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);
            }
        }
    }
}
