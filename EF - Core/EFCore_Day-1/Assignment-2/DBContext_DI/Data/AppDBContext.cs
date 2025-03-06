using DBContext_DI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContext_DI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){ }

        public DbSet<Sport> Sports { get; set; }
    }
}
