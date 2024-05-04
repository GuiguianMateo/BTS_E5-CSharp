using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AppLourdAVS.DBLib.Class
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=avs;user=root;password=;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
