using System.ComponentModel.DataAnnotations;

namespace JokesApi_BAL.Models
{
    public class JokeModel
    {
        [Key]
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public required int CategoryId { get; set; }
    }
}
