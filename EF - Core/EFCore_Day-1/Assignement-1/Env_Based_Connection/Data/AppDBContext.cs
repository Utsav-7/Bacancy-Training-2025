using Env_Based_Connection.Models;
using Microsoft.EntityFrameworkCore;

namespace Env_Based_Connection.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}

        public DbSet<Marks> Marks { get; set; }
    }
}
