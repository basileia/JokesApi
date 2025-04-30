using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Repository
{
    public class RepositoryJokeLike : RepositoryBase<JokeLike>, IRepositoryJokeLike
    {
        public RepositoryJokeLike(AppDbContext context) : base(context) { }          

        public int GetLikeCount(int jokeId)
        {
            return _context.JokeLikes.Count(l => l.JokeId == jokeId);
        }

        public bool WasRecentlyLiked(int jokeId, TimeSpan delay)
        {
            var threshold = DateTime.Now - delay;
            return _context.JokeLikes.Any(l =>
                l.JokeId == jokeId &&
                l.CreatedAt > threshold);
        }
    }
}
