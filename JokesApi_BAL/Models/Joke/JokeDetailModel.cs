using System.ComponentModel.DataAnnotations;

namespace JokesApi_BAL.Models.Joke
{
    public class JokeDetailModel
    {
        [Key]
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public required int CategoryId { get; set; }
    }
}
