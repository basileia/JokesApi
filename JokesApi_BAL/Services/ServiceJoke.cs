using AutoMapper;
using JokesApi_BAL.Models;
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

        public Result<JokeModel, Error> GetJokeById(int id)
        {
            var joke = _repositoryJoke.GetJokeById(id);
            
            if (joke == null)
            {
                return JokeErrors.JokeNotFound;
            }

            var jokeModel = _mapper.Map<JokeModel>(joke);
            return jokeModel;
        }

        public async Task<Result<Joke, Error>> AddJoke(JokeModel jokeModel)
        {
            var joke = _mapper.Map<Joke>(jokeModel);

            if (_repositoryJoke.JokeExists(joke.Id))
            {
                return JokeErrors.JokeExists;
            }

            if (!_repositoryCategory.CategoryExists(joke.CategoryId))
            {
                return CategoryErrors.CategoryNotFound;
            }

            joke.CreatedAt = DateTime.Now;
            return await _repositoryJoke.CreateJoke(joke);          
        }

        //public Result<JokeModel, Error> UpdateJoke(int id, JokeModel jokeModel)
        //{
        //    if (id != jokeModel.Id)
        //    {
        //        return JokeErrors.JokeBadRequest;
        //    }

        //    var existingJoke = GetJokeById(id);

        //    if (existingJoke.Error != null)
        //    {
        //        return JokeErrors.JokeNotFound;
        //    }

        //    if (!_repositoryCategory.CategoryExists(jokeModel.CategoryId))
        //    {
        //        return CategoryErrors.CategoryNotFound;
        //    }

        //    var joke = _mapper.Map<Joke>(jokeModel);
        //    joke.CreatedAt = DateTime.Now;
        //    _repositoryJoke.Update(joke);

        //    return GetJokeById(id);
        //}

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
