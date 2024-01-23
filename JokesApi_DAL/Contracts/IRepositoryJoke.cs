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
        Task<ActionResult<IEnumerable<Joke>>> GetAllJokes();
        Task<Joke> GetJokeById(int id);
    }
}
