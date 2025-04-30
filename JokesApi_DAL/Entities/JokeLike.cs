namespace JokesApi_DAL.Entities
{
    public class JokeLike
    {
        public int Id { get; set; }
        public int JokeId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Joke Joke { get; set; } = default!;
    }
}
