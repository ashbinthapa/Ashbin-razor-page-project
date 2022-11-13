using AshbinWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AshbinWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        
    }
}
