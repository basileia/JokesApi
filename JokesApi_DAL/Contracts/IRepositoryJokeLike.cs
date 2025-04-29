using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryJokeLike : IRepositoryBase<JokeLike>
    {
        bool HasUserLikedJoke(int jokeId, string ipAddress);        
        int GetLikeCount(int jokeId);
    }
}
