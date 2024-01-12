namespace JokesApi.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
