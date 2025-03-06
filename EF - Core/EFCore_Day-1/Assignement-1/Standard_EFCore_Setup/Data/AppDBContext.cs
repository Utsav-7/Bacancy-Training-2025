using Microsoft.EntityFrameworkCore;
using Standard_EFCore_Setup.Models;

namespace Standard_EFCore_Setup.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {   
        }

        public DbSet<Student> Students { get; set; }
    }
}
