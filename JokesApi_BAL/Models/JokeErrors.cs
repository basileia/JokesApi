namespace JokesApi_BAL.Models
{
    public static class JokeErrors
    {
        public static readonly Error JokeNotFound = new("Jokes.NotFound", "Joke not found");
        public static readonly Error JokeExists = new("Jokes.AlreadyExists", "Joke already exists");
        public static readonly Error JokeBadRequest = new("Jokes.DifferentIds", "The id in the path must be the same as the joke id.");
    }
}
