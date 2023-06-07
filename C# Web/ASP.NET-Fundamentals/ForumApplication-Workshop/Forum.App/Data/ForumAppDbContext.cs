using Forum.App.Data.Models;
using Forum.App.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Forum.App.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var postSeeder = new PostSeeder();
            Post[] seededPosts = postSeeder.GeneratePosts();

            modelBuilder.Entity<Post>().HasData(seededPosts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
