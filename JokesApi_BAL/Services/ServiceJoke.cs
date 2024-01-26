using AutoMapper;
using JokesApi_BAL.Models;
using JokesApi_DAL.Contracts;
using JokesApi_DAL.Entities;
using JokesApi_DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesApi_BAL.Services
{
    public class ServiceJoke
    {
        private readonly IRepositoryJoke _repositoryJoke;
        private readonly IMapper _mapper;

        public ServiceJoke(IRepositoryJoke repositoryJoke, IMapper mapper)
        {
            _repositoryJoke = repositoryJoke;
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
    }
}
