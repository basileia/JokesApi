using JokesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApi.Data


{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joke>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Jokes)
                .HasForeignKey(e => e.CategoryId);
        }

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
