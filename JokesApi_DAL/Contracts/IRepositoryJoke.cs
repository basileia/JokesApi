using JokesApi_DAL.Entities;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryJoke : IRepositoryBase<Joke>
    {
        Joke GetJokeById(int id);
        bool JokeExists(string content);
        void Update(Joke joke);
        Joke? GetJokeByContent(string content, int excludeId);
        int GetCount();
        Joke? GetRandom();
    }
}
