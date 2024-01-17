using JokesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace JokesApi.Dtos
{
    public class JokeDto
    {
        [Key]
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public required int CategoryId { get; set; }

    }
}
