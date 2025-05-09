﻿using JokesApi_BAL.Models.Errors;
using JokesApi_BAL.Models.JokeLike;
using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;

namespace JokesApi_BAL.Services
{
    public class ServiceJokeLike
    {
        private readonly IRepositoryJokeLike _repositoryJokeLike;
        private readonly IRepositoryJoke _repositoryJoke;

        public ServiceJokeLike(IRepositoryJokeLike repositoryJokeLike, IRepositoryJoke repositoryJoke)
        {
            _repositoryJokeLike = repositoryJokeLike;
            _repositoryJoke = repositoryJoke;
        }

        public Result<int, Error> GetLikeCount(int jokeId)
        {
            var joke = _repositoryJoke.GetById(jokeId);
            if (joke == null)
            {
                return JokeErrors.JokeNotFound;
            }

            return _repositoryJokeLike.GetLikeCount(jokeId);
        }

        public Result<int, Error> AddLike(JokeLikeUpdateModel jokeLikeModel)
        {
            TimeSpan delay = TimeSpan.FromSeconds(2);
            if (_repositoryJokeLike.WasRecentlyLiked(jokeLikeModel.JokeId, delay))
            {
                return JokeLikeErrors.AlreadyLiked;
            }
            var jokeResult = _repositoryJoke.GetById(jokeLikeModel.JokeId);
            if (jokeResult == null)
            {
                return JokeErrors.JokeNotFound;
            }

            var jokeLike = new JokeLike
            {
                JokeId = jokeLikeModel.JokeId,               
                CreatedAt = DateTime.Now
            };

            _repositoryJokeLike.Add(jokeLike);
            var likeCount = GetLikeCount(jokeLikeModel.JokeId);
            return likeCount;
        }        
    }
}
