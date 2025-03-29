namespace JokesApi_BAL.Models.Joke
{
    public class CreateJokeModel
    {
        public required string Content { get; set; }
        public int? CategoryId { get; set; }
    }
}
