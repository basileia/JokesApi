using System.ComponentModel.DataAnnotations;

namespace JokesApi.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
