using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Services
{
    public class ServiceJoke
    {
        private readonly IRepositoryJoke _repositoryJoke;
        private readonly IRepositoryCategory _repositoryCategory;
        private readonly IMapper _mapper;

        public ServiceJoke(IRepositoryJoke repositoryJoke, IRepositoryCategory repositoryCategory, IMapper mapper)
        {
            _repositoryJoke = repositoryJoke;
            _repositoryCategory = repositoryCategory;
            _mapper = mapper;
        }

        public List<JokeModel> GetAllJokes()
        {
            var jokes = _repositoryJoke.GetAllJokes();
            var jokesModel = _mapper.Map<List<Joke>, List<JokeModel>>(jokes);
            return jokesModel;
        }

        public JokeModel GetJokeById(int id)
        {
            var joke = _repositoryJoke.GetJokeById(id);
            var jokeModel = _mapper.Map<JokeModel>(joke);
            return jokeModel;
        }

        public async Task<Joke> AddJoke(JokeModel jokeModel)
        {
            var joke = _mapper.Map<Joke>(jokeModel);

            if (_repositoryJoke.JokeExists(joke.Id))
            {
                throw new Exception("Joke Id already exists.");
            }

            if (!_repositoryCategory.CategoryExists(joke.CategoryId))
            {
                throw new Exception ("Category not found.");
            }

            if (joke == null)
            {
                throw new ArgumentNullException(nameof(joke));
            }
            else
            {
                joke.CreatedAt = DateTime.Now;
                return await _repositoryJoke.CreateJoke(joke);
            }
        }

        public void UpdateJoke(JokeModel jokeModel)
        {
            if (jokeModel == null)
            {
                throw new ArgumentNullException(nameof(jokeModel));
            }

            if (!_repositoryCategory.CategoryExists(jokeModel.CategoryId))
            {
                throw new Exception("Category not found.");
            }

            var joke = _mapper.Map<Joke>(jokeModel);
            joke.CreatedAt = DateTime.Now;
            _repositoryJoke.Update(joke);
        }

        public void DeleteJoke(int id)
        {
            _repositoryJoke.Delete(id);
        }
    }
}
