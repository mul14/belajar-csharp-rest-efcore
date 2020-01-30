using Microsoft.EntityFrameworkCore;

namespace BelajarMembuatRESTServer.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
