using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesApi_DAL.Repository
{
    public class RepositoryJoke : IRepositoryJoke
    {
        private readonly AppDbContext _context;

        public RepositoryJoke(AppDbContext context)
        {
            _context = context;
        }

        public List<Joke> GetAllJokes()
        {
            return _context.Jokes.ToList();
        }

        public Joke GetJokeById(int id)
        {
            var joke = _context.Jokes
                .Include(_ => _.Category)
                .AsNoTracking()
                .Where(_ => _.Id == id)
                .FirstOrDefault();

            return joke;
        }

        public async Task<Joke> CreateJoke(Joke joke)
        {
            try
            {
                if (joke != null)
                {
                    var obj = _context.Add(joke);
                    await _context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool JokeExists(int id)
        {
            return _context.Jokes.Any(e => e.Id == id);
        }

        public void Update(Joke joke)
        {
            _context.Entry(joke).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
