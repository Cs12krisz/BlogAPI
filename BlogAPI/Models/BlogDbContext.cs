using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() { }

        public BlogDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Blogger> blogger {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=blogapi;user=root;password=");
        }
    }
}
