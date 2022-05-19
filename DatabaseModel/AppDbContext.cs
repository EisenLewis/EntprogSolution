using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-SSAA20D\\SQLEXPRESS;" +
            //    "Database=EntprogOTIS1;Integrated Security=SSPI;" +
            //    "TrustServerCertificate=true");
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
