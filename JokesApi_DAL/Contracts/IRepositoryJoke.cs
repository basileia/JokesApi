using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesApi_DAL.Contracts
{
    public interface IRepositoryJoke
    {
        List<Joke> GetAllJokes();
        Joke GetJokeById(int id);
        Task<Joke> CreateJoke(Joke joke);
        bool JokeExists(int id);
        void Update(Joke joke);
    }
}
