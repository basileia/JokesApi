using System.ComponentModel.DataAnnotations;

namespace JokesApi_DAL.Entities
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
