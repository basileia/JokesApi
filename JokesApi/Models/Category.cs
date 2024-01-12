using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace JokesApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public ICollection<Joke> Jokes { get; } = new List<Joke>();  
    }
}
