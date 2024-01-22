using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_DAL.Data

{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        
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
