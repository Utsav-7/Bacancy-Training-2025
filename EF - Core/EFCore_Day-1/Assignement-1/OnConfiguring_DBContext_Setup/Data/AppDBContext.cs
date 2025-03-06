
using Microsoft.EntityFrameworkCore;
using OnConfiguring_DBContext_Setup.Models;

namespace OnConfiguring_DBContext_Setup.Data
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Classes> Classes { get; set; }
    }
}
