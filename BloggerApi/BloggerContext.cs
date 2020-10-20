using BloggerCore;
using BloggerDomain;
using Microsoft.EntityFrameworkCore;

namespace BloggerApi
{
    public class BloggerContext : DbContext, IUnitOfWork
    {
        private const string dbConnectionString = @"Server=.;Database=Blogger;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                        .HasMany(p => p.Comments)
                        .WithOne(c => c.Post)
                        .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
                        .HasMany(p => p.Likes)
                        .WithOne(l => l.Post)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
