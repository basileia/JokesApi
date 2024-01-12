using JokesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApi.Data


{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Joke> Jokes { get; set; }
    }
}
