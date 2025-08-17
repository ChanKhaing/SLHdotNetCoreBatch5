using Microsoft.EntityFrameworkCore;
using SLHdotNetCoreBatch5.Consoleapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHdotNetCoreBatch5.Consoleapp
{
    public class AppDbContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if(!optionsBuilder.IsConfigured)
            {
                // This is the connection string to connect to the SQL Server database.

                string connectionString = "Data Source=.;Initial Catalog=DotNetTrainngBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);

            }






        }


      


        //public DbSet<BlogEfcoreDataModel> Blogs { get; set; }
        public DbSet<EfcoreBlogDataModel> Blogs { get; set; }

    }
}
