using JokesApi_BAL.Models.Joke;
using System.ComponentModel.DataAnnotations;

namespace JokesApi_BAL.Models.Category
{
    public class CategoryDetailModel
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<JokeModel> Jokes { get; set; }
    }
}
