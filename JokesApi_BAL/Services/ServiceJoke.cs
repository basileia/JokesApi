using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Http;

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
            
            if (joke == null)
            {
                throw new BadHttpRequestException("Invalid Id");
            }

            var jokeModel = _mapper.Map<JokeModel>(joke);
            return jokeModel;
        }

        public async Task<Joke> AddJoke(JokeModel jokeModel)
        {
            var joke = _mapper.Map<Joke>(jokeModel);

            if (_repositoryJoke.JokeExists(joke.Id))
            {
                throw new BadHttpRequestException("Joke Id already exists.");
            }

            if (!_repositoryCategory.CategoryExists(joke.CategoryId))
            {
                throw new BadHttpRequestException("Category not found.");
            }

            joke.CreatedAt = DateTime.Now;
            return await _repositoryJoke.CreateJoke(joke);
          
        }

        public void UpdateJoke(int id, JokeModel jokeModel)
        {
            if (id != jokeModel.Id)
            {
                throw new BadHttpRequestException("The id in the path must be the same as the joke id.");
            }

            var existingJoke = GetJokeById(id);

            if (existingJoke == null)
            {
                throw new BadHttpRequestException("Joke not found");
            }

            if (!_repositoryCategory.CategoryExists(jokeModel.CategoryId))
            {
                throw new BadHttpRequestException("Category not found.");
            }

            var joke = _mapper.Map<Joke>(jokeModel);
            joke.CreatedAt = DateTime.Now;
            _repositoryJoke.Update(joke);
        }

        public void DeleteJoke(int id)
        {
            var existingJoke = GetJokeById(id);

            if (existingJoke == null)
            {
                throw new BadHttpRequestException("Joke not found");
            }

            _repositoryJoke.Delete(id);
        }
    }
}
