using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppLourdAVS.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AppLourdAVS.Wpf
{
    public class AppLourdAVSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurez ici votre connexion à la base de données
            optionsBuilder.UseSqlServer("Server=localhost;Database=megacasting;user=root;password=;");

        }
    }
}
