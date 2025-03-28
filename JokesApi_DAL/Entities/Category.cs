using System.ComponentModel.DataAnnotations;

namespace JokesApi_DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Joke> Jokes { get; set; } = new List<Joke>();
    }
}
