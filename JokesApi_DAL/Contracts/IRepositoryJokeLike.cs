using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryJokeLike : IRepositoryBase<JokeLike>
    {
        int GetLikeCount(int jokeId);
        bool WasRecentlyLiked(int jokeId, TimeSpan delay);
    }
}
