using Microsoft.EntityFrameworkCore;
using Method_Library.Models;

namespace Method_Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Languages> Languages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Snippets> Snippets { get; set; }
    }
}