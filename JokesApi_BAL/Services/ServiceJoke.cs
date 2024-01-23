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

        public ServiceJoke(IRepositoryJoke repositoryJoke )
        {
            _repositoryJoke = repositoryJoke;
        }

        public async Task<ActionResult<IEnumerable<Joke>>> GetAllJokes()
        {
            return await _repositoryJoke.GetAllJokes();
        }

        public async Task<Joke> GetJokeById(int id)
        {
            return await _repositoryJoke.GetJokeById(id);
        }
    }
}
