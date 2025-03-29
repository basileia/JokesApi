using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryJoke : IRepositoryBase<Joke>
    {
        Joke GetJokeById(int id);
        Task<Joke> CreateJoke(Joke joke);
        bool JokeExists(int id);
        void Update(Joke joke);
        void Delete(int id);
    }
}
