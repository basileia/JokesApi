using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_BAL.Models.Category;
using JokesApi_BAL.Models.Errors;
using JokesApi_BAL.Models.Joke;
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
            var jokes = _repositoryJoke.GetAll();
            return _mapper.Map<List<Joke>, List<JokeModel>>(jokes);
        }

        public Result<JokeDetailModel, Error> GetJokeById(int id)
        {
            var joke = _repositoryJoke.GetJokeById(id);
            
            if (joke == null)
            {
                return JokeErrors.JokeNotFound;
            }

            return _mapper.Map<JokeDetailModel>(joke);
        }

        public Result<Joke, Error> AddJoke(CreateJokeModel jokeModel)
        {
            var joke = _mapper.Map<Joke>(jokeModel);

            if (_repositoryJoke.JokeExists(joke.Content))
            {
                return JokeErrors.JokeExists;
            }

            if (joke.CategoryId.HasValue && !_repositoryCategory.CategoryExists(joke.CategoryId.Value))
            {
                return CategoryErrors.CategoryNotFound;
            }

            joke.CreatedAt = DateTime.Now;
            return  _repositoryJoke.Add(joke);          
        }

        public Result<JokeDetailModel, Error> UpdateJoke(int id, UpdateJokeModel jokeModel)
        {
            if (id != jokeModel.Id)
                return JokeErrors.JokeBadRequest;

            var existingJokeResult = GetJokeById(id);
            if (existingJokeResult.Error != null)
                return JokeErrors.JokeNotFound;

            var existingJoke = existingJokeResult.Value; 

            if (_repositoryJoke.GetJokeByContent(jokeModel.Content, id) != null)
                return JokeErrors.JokeExists;

            if (jokeModel.CategoryId.HasValue && jokeModel.CategoryId != existingJoke.CategoryId &&
                !_repositoryCategory.CategoryExists(jokeModel.CategoryId.Value))
            {
                return CategoryErrors.CategoryNotFound;
            }

            var joke = _mapper.Map<Joke>(jokeModel);
            _repositoryJoke.Update(joke);

            return GetJokeById(id);
        }

        public Result<bool, Error>? DeleteJoke(int id)
        {
            var existingJoke = GetJokeById(id);

            if (existingJoke.Error != null)
            {
                return JokeErrors.JokeNotFound;
            }

            _repositoryJoke.Delete(id);
            return true;
        }
    }
}
