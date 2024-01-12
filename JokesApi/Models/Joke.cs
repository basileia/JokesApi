using System.Reflection.Metadata;

namespace JokesApi.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = null!; 
    }
}
