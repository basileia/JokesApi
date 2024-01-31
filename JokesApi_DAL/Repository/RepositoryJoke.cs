using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

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

        public void Update(Joke joke)
        {
            _context.Entry(joke).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var joke = _context.Jokes.Find(id);
            if (joke != null)
            {
                _context.Jokes.Remove(joke);
                _context.SaveChanges();
            }
        }

        public bool JokeExists(int id)
        {
            return _context.Jokes.Any(e => e.Id == id);
        }
    }
}
