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
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JokeLike>()
                .HasOne(jl => jl.Joke)
                .WithMany(j => j.Likes)
                .HasForeignKey(jl => jl.JokeId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Joke> Jokes { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<JokeLike> JokeLikes { get; set; } = default!;
    }
}
