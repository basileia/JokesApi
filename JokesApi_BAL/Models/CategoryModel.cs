using System.ComponentModel.DataAnnotations;

namespace JokesApi_BAL.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<JokeModel>? Jokes { get; }
    }
}
