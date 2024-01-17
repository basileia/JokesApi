using System.ComponentModel.DataAnnotations;

namespace JokesApi.Dtos
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<JokeDto>? Jokes { get; }
    }
}
