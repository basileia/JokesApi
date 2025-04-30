using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Repository
{
    public class RepositoryJokeLike : RepositoryBase<JokeLike>, IRepositoryJokeLike
    {
        public RepositoryJokeLike(AppDbContext context) : base(context) { }

        public bool HasUserLikedJoke(int jokeId, string ipAddress, string userAgent)
        {
            return _context.JokeLikes.Any(l =>
                l.JokeId == jokeId &&
                l.IpAddress == ipAddress &&
                l.UserAgent == userAgent);
        }       

        public int GetLikeCount(int jokeId)
        {
            return _context.JokeLikes.Count(l => l.JokeId == jokeId);
        }
    }
}
