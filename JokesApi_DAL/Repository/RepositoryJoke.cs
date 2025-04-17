using JokesApi_DAL.Contracts;
using JokesApi_DAL.Data;
using JokesApi_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JokesApi_DAL.Repository
{
    public class RepositoryJoke : RepositoryBase<Joke>, IRepositoryJoke
    {
        public RepositoryJoke(AppDbContext context) : base(context) { }
                
        public Joke GetJokeById(int id)
        {
            var joke = _context.Jokes
                .Include(_ => _.Category)
                .AsNoTracking()
                .Where(_ => _.Id == id)
                .FirstOrDefault();

            return joke;
        }
        
        public void Update(Joke joke)
        {
            _context.Entry(joke).State = EntityState.Modified;
            _context.SaveChanges();
        }          

        public bool JokeExists(string content)
        {
            return _context.Jokes.Any(e => e.Content == content);
        }

        public Joke? GetJokeByContent(string content, int excludeId)
        {
            return GetByProperty(j => j.Content == content && j.Id != excludeId);
        }

        public int GetCount()
        {
            return _context.Jokes.Count();
        }

        public Joke? GetRandom()
        {
            var count = GetCount();
            if (count == 0) 
            {
                return null;
            }

            var randomIndex = Random.Shared.Next(0, count);

            return _context.Jokes
                .Include(j => j.Category)
                .AsNoTracking()
                .OrderBy(j => j.Id)
                .Skip(randomIndex)
                .FirstOrDefault();
        }
    }
}
